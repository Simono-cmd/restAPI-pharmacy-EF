using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AddPrescriptionAsync(PrescriptionInsertDTO dto)
    {
        if (dto.DueDate < dto.Date)
            throw new ArgumentException("DueDate must be greater or equal to Date.");

        if (dto.Medicaments.Count > 10)
            throw new ArgumentException("Prescription cannot contain more than 10 medicaments.");

        var existingPatient = await _context.Patients.FindAsync(dto.Patient.IdPatient);
        if (existingPatient == null)
        {
            existingPatient = new Patient
            {
                FirstName = dto.Patient.FirstName,
                LastName = dto.Patient.LastName,
                Birthdate = dto.Patient.Birthdate
            };

            _context.Patients.Add(existingPatient);
            await _context.SaveChangesAsync();
        }

        foreach (var med in dto.Medicaments)
        {
            var exists = await _context.Medicaments.FindAsync(med.IdMedicament);
            if(exists == null)
                throw new ArgumentException("Medicament not found.");
        }

        var prescription = new Prescription()
        {
            IdPatient = existingPatient.IdPatient,
            Date = dto.Date,
            DueDate = dto.DueDate,
            IdDoctor = dto.IdDoctor,
            Prescription_Medicaments = new List<PrescriptionMedicament>()
        };

        foreach (var med in dto.Medicaments)
        {
            prescription.Prescription_Medicaments.Add(new PrescriptionMedicament()
            {
                IdMedicament = med.IdMedicament,
                Dose = med.Dose,
                Details = med.Details
            });
        }
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<PatientDetailsDTO> GetPatientDetailsAsync(int id)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Prescription_Medicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == id);

        if (patient == null)
            return null;

        return new PatientDetailsDTO
        {
            Patient = new PatientDTO
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate
            },
            Prescriptions = patient.Prescriptions
                .OrderBy(pr => pr.DueDate)
                .Select(pr => new PrescriptionDTO
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Doctor = new DoctorDTO
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName,
                    },
                    Medicaments = pr.Prescription_Medicaments.Select(pm => new MedicamentDTO
                    {
                        IdMedicament = pm.Medicament.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Details
                    }).ToList()
                }).ToList()
        };
    }

    
}
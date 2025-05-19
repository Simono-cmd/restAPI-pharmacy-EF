using Microsoft.EntityFrameworkCore;
using Tutorial5.Models;

namespace Tutorial5.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Doctors
    modelBuilder.Entity<Doctor>().HasData(
        new Doctor
        {
            IdDoctor = 1,
            FirstName = "Adam",
            LastName = "Kowalski",
            Email = "adam.kowalski@clinic.com"
        },
        new Doctor
        {
            IdDoctor = 2,
            FirstName = "Ewa",
            LastName = "Nowak",
            Email = "ewa.nowak@clinic.com"
        }
    );

    // Patients
    modelBuilder.Entity<Patient>().HasData(
        new Patient
        {
            IdPatient = 1,
            FirstName = "Jan",
            LastName = "Nowak",
            Birthdate = new DateTime(1990, 1, 1)
        },
        new Patient
        {
            IdPatient = 2,
            FirstName = "Anna",
            LastName = "Kowalczyk",
            Birthdate = new DateTime(1985, 3, 15)
        }
    );

    // Medicaments
    modelBuilder.Entity<Medicament>().HasData(
        new Medicament
        {
            IdMedicament = 1,
            Name = "Apap",
            Description = "Painkiller",
            Type = "Tablet"
        },
        new Medicament
        {
            IdMedicament = 2,
            Name = "Ibuprom",
            Description = "Anti-inflammatory",
            Type = "Tablet"
        },
        new Medicament
        {
            IdMedicament = 3,
            Name = "Amoxicillin",
            Description = "Antibiotic",
            Type = "Capsule"
        }
    );

    // Prescriptions
    modelBuilder.Entity<Prescription>().HasData(
        new Prescription
        {
            IdPrescription = 1,
            Date = new DateTime(2023, 12, 1),
            DueDate = new DateTime(2023, 12, 31),
            IdDoctor = 1,
            IdPatient = 1
        },
        new Prescription
        {
            IdPrescription = 2,
            Date = new DateTime(2024, 1, 5),
            DueDate = new DateTime(2024, 1, 20),
            IdDoctor = 2,
            IdPatient = 2
        }
    );

    // PrescriptionMedicaments (many-to-many)
    modelBuilder.Entity<PrescriptionMedicament>().HasData(
        new PrescriptionMedicament
        {
            IdPrescription = 1,
            IdMedicament = 1,
            Dose = 2,
            Details = "Take twice a day"
        },
        new PrescriptionMedicament
        {
            IdPrescription = 1,
            IdMedicament = 2,
            Dose = 1,
            Details = "Once in the morning"
        },
        new PrescriptionMedicament
        {
            IdPrescription = 2,
            IdMedicament = 3,
            Dose = 3,
            Details = "After meals"
        }
    );
}

}
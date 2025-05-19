using Tutorial5.DTOs;
namespace Tutorial5.Services;

public interface IDbService
{
    Task<bool> AddPrescriptionAsync(PrescriptionInsertDTO dto);
    Task<PatientDetailsDTO> GetPatientDetailsAsync(int id);

}
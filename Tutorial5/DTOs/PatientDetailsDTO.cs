namespace Tutorial5.DTOs;

public class PatientDetailsDTO
{
    public PatientDTO Patient { get; set; }
    public List<PrescriptionDTO> Prescriptions { get; set; }
}
using Tutorial5.Models;
namespace Tutorial5.DTOs;

public class PrescriptionInsertDTO
{
    public PatientDTO Patient { get; set; }
    public List<PrescriptionMedicamentDTO> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
}

public class PrescriptionMedicamentDTO
{
    public int IdMedicament {get; set;}
    public int? Dose { get; set; }
    public string Details {get; set;}
}
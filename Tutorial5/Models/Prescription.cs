using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tutorial5.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [ForeignKey(nameof(Patient))]
    public int IdPatient { get; set; }

    [ForeignKey(nameof(Doctor))]
    public int IdDoctor { get; set; }

    public Patient Patient { get; set; }

    public Doctor Doctor { get; set; }

    public ICollection<PrescriptionMedicament> Prescription_Medicaments { get; set; }
}
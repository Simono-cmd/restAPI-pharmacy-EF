using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tutorial5.Models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }

    [MaxLength(100)]
    public string Type { get; set; }

    public ICollection<PrescriptionMedicament> Prescription_Medicaments { get; set; }
}
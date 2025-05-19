using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tutorial5.Models;

[Table("Patient")]
public class Patient
{
    [Key]
    public int IdPatient { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    public DateTime Birthdate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}
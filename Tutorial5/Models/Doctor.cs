using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tutorial5.Models;
    
[Table("Doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    [Required, MaxLength(100)]
    public string Email { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}
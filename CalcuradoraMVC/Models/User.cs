using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CalcuradoraMVC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(12,ErrorMessage = "La contraseña debe tener 12 dígitos<br>")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Al menos una letra mayúscula.<br>Al menos una letra minúscula.<br>Al menos un número.<br>Al menos un carater especial.")]
        public string Password { get; set; }
        
        public ICollection<Operations>? lasOperaciones { get; set; }

    }
}

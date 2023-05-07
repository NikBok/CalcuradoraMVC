using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CalcuradoraMVC.Models
{
    public class Operations
    {
        [Key]    
        public int Id { get; set; }
        public string Expresion { get; set; }
        public string  Resultado { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

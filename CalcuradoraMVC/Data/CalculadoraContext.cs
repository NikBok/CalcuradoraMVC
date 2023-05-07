using CalcuradoraMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CalcuradoraMVC.Data
{
    public class CalculadoraContext : DbContext
    {
        public CalculadoraContext(DbContextOptions<CalculadoraContext> options) : base(options)
        {

        }

        public DbSet<Operations> Operaciones { get; set; }
        public DbSet<User> Usuarios { get; set; }
    }

}

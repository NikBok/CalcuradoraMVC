using CalcuradoraMVC.Data;
using CalcuradoraMVC.Models;

namespace CalcuradoraMVC.Repositories
{
    public class HistorialRepository : IHistorialRepository
    {
        private CalculadoraContext _context;

        public HistorialRepository(CalculadoraContext context)
        {
            _context = context;
        }

        public void DeleteOperation(int id)
        {
            var operation = _context.Operaciones.SingleOrDefault(c => c.Id == id);
            _context.Operaciones.Remove(operation);
            _context.SaveChanges();
        }

        public IEnumerable<Operations> GetOperations()
        {
            return _context.Operaciones.ToList();
        }
    }
}

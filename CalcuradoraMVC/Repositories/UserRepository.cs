using CalcuradoraMVC.Data;
using CalcuradoraMVC.Models;
namespace CalcuradoraMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CalculadoraContext _context;
        public UserRepository(CalculadoraContext context)
        {
            _context = context;
        }
        public void AddUser(User theUser)
        {
            if (!_context.Usuarios.Any(u => u.Username == theUser.Username))
            {
                _context.Add(theUser);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Ya existe un usuario con ese nombre de usuario.");
            }
        }

        public bool AlreadyExists(User theUser)
        {
            if (_context.Usuarios.Any(u => u.Username == theUser.Username))
            { 
                return true;
            }
            return false;
        }

        public User GetUserById(int id)
        {
           return _context.Usuarios.FirstOrDefault(u => u.Id == id);         
        }

        public User IsCorrect(User theUser)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Username == theUser.Username && u.Password == theUser.Password);
        }     
    }
}

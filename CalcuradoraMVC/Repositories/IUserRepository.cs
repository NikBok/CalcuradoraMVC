using CalcuradoraMVC.Models;
namespace CalcuradoraMVC.Repositories
{
    public interface IUserRepository
    {
        User IsCorrect(User theUser);
        Boolean AlreadyExists(User theUser);
        void AddUser (User theUser);

        User GetUserById (int id);
        
    }
}

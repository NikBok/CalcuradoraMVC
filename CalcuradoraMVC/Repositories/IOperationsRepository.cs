using CalcuradoraMVC.Models;

namespace CalcuradoraMVC.Repositories
{
    public interface IOperationsRepository
    {
        void SaveAnOperation(Operations operacion);
    }
}

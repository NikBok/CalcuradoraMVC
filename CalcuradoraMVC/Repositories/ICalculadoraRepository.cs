using CalcuradoraMVC.Models;

namespace CalcuradoraMVC.Repositories
{
    public interface ICalculadoraRepository
    {
        void SaveAnOperation(Operations operacion);
    }
}

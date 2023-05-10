using CalcuradoraMVC.Data;
using CalcuradoraMVC.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalcuradoraMVC.Repositories
{
    public interface IHistorialRepository
    {
        IEnumerable<Operations> GetOperations(int?  userId);
        void DeleteOperation(int id);
    }
}

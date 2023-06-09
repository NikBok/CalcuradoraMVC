﻿using System.Linq;
using CalcuradoraMVC.Data;
using CalcuradoraMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
namespace CalcuradoraMVC.Repositories
{
    public class CalculadoraRepository : ICalculadoraRepository
    {
        private CalculadoraContext _context;
        public CalculadoraRepository(CalculadoraContext context)
        {
            _context = context;
        }

        public void SaveAnOperation(Operations operacion)
        {
            _context.Add(operacion);
            _context.SaveChanges();
        }
    }
    
}

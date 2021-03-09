using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> Customer { get; }

        IGenericRepository<Days> Days { get; }

        IGenericRepository<Hours> Hours { get; }

        IGenericRepository<Employee> Employee { get; }

        Task Save();
        

    }
}

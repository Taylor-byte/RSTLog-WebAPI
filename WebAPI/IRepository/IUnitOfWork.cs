using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        //interface which the Unit of work impliments for each of the models/DTOs
        IGenericRepository<Customer> Customer { get; }

        IGenericRepository<Audit> Audit { get; }

        IGenericRepository<TransType> TransType { get; }

        IGenericRepository<Employee> Employee { get; }

        Task Save();
        

    }
}

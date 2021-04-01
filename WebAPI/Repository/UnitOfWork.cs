using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Customer> _customer;

        //private IGenericRepository<Days> _days;

       // private IGenericRepository<Hours> _hours;

        private IGenericRepository<Employee> _employee;

        private IGenericRepository<Audit> _audit;

        private IGenericRepository<TransType> _transType;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;

            

        }

        public IGenericRepository<Customer> Customer => _customer ??= new GenericRepository<Customer>(_context);

        public IGenericRepository<Audit> Audit => _audit ??= new GenericRepository<Audit>(_context);

        public IGenericRepository<TransType> TransType => _transType ??= new GenericRepository<TransType>(_context);

        public IGenericRepository<Employee> Employee => _employee ??= new GenericRepository<Employee>(_context);


        public void Dispose()
        {
            //garbage collect any unused memory
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

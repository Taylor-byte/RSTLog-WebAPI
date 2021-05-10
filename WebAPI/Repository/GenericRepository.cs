using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.IRepository;
using WebAPI.Models;
//using X.PagedList;
using WebAPI.Paging;
using WebAPI.Repository.RepositoryExtensions;

namespace WebAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;

            _db = _context.Set<T>();


        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                //include foreign keys in get
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            //filter for expression such as give me all with id of 1
            if(expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                //include foreign keys in get
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<PagedList<Audit>> GetAudits(RequestParams requestParams)
        {

            var audits = await _context.Audit.Include("TransType")
               //.Search(requestParams.SearchTerm)
               .ToListAsync();

            return PagedList<Audit>
                .ToPagedList(audits, requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task<PagedList<Customer>> GetCustomers(RequestParams requestParams)
        {
            var customers = await _context.Customer
                .Search(requestParams.SearchTerm)
                .ToListAsync();

            return PagedList<Customer>
                .ToPagedList(customers, requestParams.PageNumber, requestParams.PageSize);

        }



        //public Task<X.PagedList.IPagedList> GetPagedList(RequestParams requestParams, List<string> includes = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IPagedList> GetPagedList(RequestParams requestParams, List<string> includes = null)
        //{
        //    IQueryable<T> query = _db;

        //    if (includes != null)
        //    {
        //        //include foreign keys in get
        //        foreach (var includeProperty in includes)
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }


        //    return await query.AsNoTracking()
        //        .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);

        //}

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        //Task<X.PagedList.PagedList<CustomerDTO>> IGenericRepository<T>.GetCustomers(RequestParams requestParams)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.DTOs;
//using X.PagedList;
using WebAPI.Models;
using WebAPI.Paging;

namespace WebAPI.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
        );

        Task<PagedList<Customer>> GetCustomers(RequestParams requestParams);

        Task<PagedList<Audit>> GetAudits(RequestParams requestParams);

        //Task<IEnumerable<TransType>> GetTransTypes();
        //Task<TransType> GetTransType(int departmentId);

        //Task<IPagedList> GetPagedList(
        //    RequestParams requestParams,
        //    List<string> includes = null
        //    );

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);

        Task Insert(T entity);

        Task InsertRange(IEnumerable<T> entities);

        Task Delete(int id);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository.RepositoryExtensions
{
    public static class RepositoryCustomerExtentions
    {

        public static IQueryable<Customer> Search(this IQueryable<Customer> customers, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return customers;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return customers.Where(c => c.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Customer> Sort(this IQueryable<Customer> customers,
            string orderByQueryString)
        {

            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return customers.OrderBy(e => e.Name);

            var orderParams = orderByQueryString.Trim().Split(",");
            var propertyInfos = typeof(Customer)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return customers.OrderBy(e => e.Name);


            return customers.OrderBy(orderQuery);


        }

    }
}

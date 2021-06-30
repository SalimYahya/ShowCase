using Microsoft.EntityFrameworkCore;
using ShowCase.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Specifications
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null) { query = query.Where(specification.Criteria); }
            if (specification.OrderBy != null) { query = query.OrderBy(specification.OrderBy); }
            if (specification.OrderByDescending != null) { query = query.OrderByDescending(specification.OrderByDescending); }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}

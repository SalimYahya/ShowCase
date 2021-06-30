using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Contracts
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, Object>>> Includes { get; }
        List<string> IncludeStrings { get; }

        Expression<Func<T, Object>> OrderBy { get; }
        Expression<Func<T, Object>> OrderByDescending { get; }
    }
}

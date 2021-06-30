using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Contracts
{
    public interface IRepositoryBase<T1, T2> where T1 : class
    {
        Task<T1> GetByIdAsync(T2 id);
        Task<IEnumerable<T1>> GetAllAsync();
        Task<IEnumerable<T1>> FindAsync(Expression<Func<T1, bool>> predicate);
        IEnumerable<T1> FindWithSpecificationPattern(ISpecification<T1> specification = null);
        
        Task<T1> AddAsync(T1 entity);
        Task<IEnumerable<T1>> AddRangeAsync(IEnumerable<T1> entities);
        
        void Update(T1 entity);
        
        void Remove(T1 entity);
        void RemoveRange(IEnumerable<T1> entities);

        Task SaveAsync();
    }
}

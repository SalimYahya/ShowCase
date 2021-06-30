using Microsoft.EntityFrameworkCore;
using ShowCase.Data;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Repository
{
    public class RepositoryBase<T1, T2> : IRepositoryBase<T1, T2> where T1 : class
    {
        private readonly AppDbContext _appDbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<T1> AddAsync(T1 entity)
        {
            await _appDbContext.Set<T1>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T1>> AddRangeAsync(IEnumerable<T1> entities)
        {
            await _appDbContext.Set<T1>().AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T1>> GetAllAsync()
        {
            return await _appDbContext.Set<T1>().ToListAsync();
        }

        public async Task<T1> GetByIdAsync(T2 id)
        {
            return await _appDbContext.Set<T1>().FindAsync(id);
        }

        public void Update(T1 entity)
        {
            _appDbContext.Set<T1>().Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<T1>> FindAsync(System.Linq.Expressions.Expression<Func<T1, bool>> predicate)
        {
            return await _appDbContext.Set<T1>().Where(predicate).ToListAsync();
        }

        public void Remove(T1 entity)
        {
            if (entity != null)
            {
                _appDbContext.Set<T1>().Remove(entity);
            }
        }

        public void RemoveRange(IEnumerable<T1> entities)
        {
            if (entities != null)
            {
                _appDbContext.RemoveRange(entities);
            }
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<T1> FindWithSpecificationPattern(ISpecification<T1> specification = null)
        {
            return SpecificationEvaluator<T1>.GetQuery(_appDbContext.Set<T1>().AsQueryable(), specification);
        }
    }
}

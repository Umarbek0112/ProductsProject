using Microsoft.EntityFrameworkCore;
using ProductsProject.Data.DbContex;
using ProductsProject.Data.IRepositoriy;
using ProductsProject.Domain.Commons;
using System.Linq.Expressions;

namespace ProductsProject.Data.Repositoriy
{
    public class GenericRepositoriy<T> : IGenericRepositoriy<T> where T : Auditable
    {
        private readonly ProductsProjectDbContex _dbContex;
        private readonly DbSet<T> _dbSet;

        public GenericRepositoriy(ProductsProjectDbContex dbContex)
        {
            _dbContex = dbContex;
            _dbSet = dbContex.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).Entity;

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await GetAsync(x => x.Id == id);
            if (deleted is null)
                return false;

            _dbSet.Remove(deleted);
            return true;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            var getAll = expression is null ? _dbSet : _dbSet.Where(expression);

            if (!isTracking)
                _dbSet.AsNoTracking();

            if (includes != null)
                foreach (var include in includes)
                    if (!string.IsNullOrEmpty(include))
                        getAll = getAll.Include(include);

            return getAll;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
            => await GetAll(expression, includes, isTracking).FirstOrDefaultAsync();

        public T Update(T entity)
             => _dbSet.Update(entity).Entity;

        public async Task SaveChangesAsync()
            => await _dbContex.SaveChangesAsync();

        
    }
}

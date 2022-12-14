using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace V2_Final500W.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UniversityDbContext _dbContext;
        //private readonly DbSet<T> table;

        public GenericRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
           // table = _dbContext.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
            Expression<Func<T, object>>[] includes = null)
        {
            var data = expression == null ? _dbContext.Set<T>().AsQueryable() : _dbContext.Set<T>().Where(expression);

            if (includes != null)
            {
                data = includes.Aggregate(data, (item, include) => item.Include(include));
            }

            return await data.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByIdAsync2(int? id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
          
        }

        //public async Task<T> GetByColAsync(string colName, int colValue)
        //{

        //    return await _dbContext.Set<T>().First(p => p.colName == colValue);
        //}

        public async Task AddAsync(T obj)
        {
            await _dbContext.Set<T>().AddAsync(obj);
            _dbContext.Entry(obj).State = EntityState.Added;
        }

        public async Task Update(T obj)
        {
             _dbContext.Set<T>().Update(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }
        //public async Task Update(T obj)
        //{
        //    _dbContext.Set<T>().Update(obj);
        //    _dbContext.Entry(obj).State = EntityState.Modified;
        //}

        public void Delete(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
        }
        public bool GetByIdAsyncBool(int? id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                return true;
            }
            return false;
            
        }

        public async Task Delete2(T obj)
        {
            _dbContext.Set<T>().Remove(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }



        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


    }
}
using Microsoft.AspNetCore.Hosting;
using System.Linq.Expressions;

namespace V2_Final500W.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
            Expression<Func<T, object>>[] includes = null);

        Task<T> GetByIdAsync(int id);
        Task AddAsync(T obj);
        Task Update(T obj);
        void Delete(int id);
        Task SaveAsync();
 
    }


}

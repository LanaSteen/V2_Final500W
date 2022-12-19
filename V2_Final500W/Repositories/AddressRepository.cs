//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using V2_Final500W.Models;

//namespace V2_Final500W.Repositories
//{
//    public class AddressRepository : IAddressRepository
//    {
//        private readonly UniversityDbContext _dbContext;

//        public AddressRepository(UniversityDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<Address> GetByIdAsync(int id)
//        {
//            return await _dbContext.Addresses.Where(x => x.Id == id).FirstOrDefaultAsync();
//        }

//        public async Task<List<Address>> GetAllAsync()
//        {
//            return await _dbContext.Addresses.ToListAsync();
//        }

//        public void Update(Address address)
//        {
//            _dbContext.Addresses.Update(address);
//            _dbContext.Entry(address).State = EntityState.Modified;
//        }

//        public async Task AddAsync(Address address)
//        {
//            await _dbContext.Addresses.AddAsync(address);
//            _dbContext.Entry(address).State = EntityState.Added;
//        }

//        public async Task<List<Address>> GetWithFilterAsync(Expression<Func<Address, bool>> expression = null)
//        {
//            if (expression != null)
//            {
//                return await _dbContext.Addresses.Where(expression).ToListAsync();
//            }

//            return await _dbContext.Addresses.ToListAsync();
//        }

//        public async Task SaveAsync()
//        {
//            await _dbContext.SaveChangesAsync();
//        }
//    }
//}

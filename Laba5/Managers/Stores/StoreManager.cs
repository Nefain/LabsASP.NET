using Laba5.Storage;
using Laba5.Storage.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.Stores
{
    public class StoreManager : IStoreManager
    {
        private readonly StoreDataContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public StoreManager(StoreDataContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<Store> AddStore(CreateOrUpdateStoreRequest request)
        {
            var entity = new Store
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                TypeStore = request.TypeStore,
                MainStore = request.MainStore,
                ProductId = request.ProductId
            };
            
            _dbContext.Stores.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyCollection<Store>> GetAll()
        {
            var query = _dbContext.Stores
                                  .Include(st => st.Products)
                                  .OrderBy(st => st.TypeStore)
                                  .AsNoTracking();
            var entities = await query.ToListAsync();

            return entities;
        }
        public async Task<Store> EditStore(Guid id, CreateOrUpdateStoreRequest request)
        {
            var entity = await _dbContext.Stores.FirstOrDefaultAsync(g => g.Id == id);
            entity.Name = request.Name;
            entity.TypeStore = request.TypeStore;
            entity.MainStore = request.MainStore;
            entity.ProductId = request.ProductId;

            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Product>>GetAllProduct()
        {
            var query = _dbContext.Products.AsNoTracking();
            var entities = await query.ToListAsync();

            return entities;
        }
        public async Task<Store> GetById(Guid id)
        {
            return await _dbContext.Stores.Include(st => st.Products)
                                          .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<Store> DataRemove(Guid id)
        {
            var entity = await _dbContext.Stores.Include(st => st.Products)
                                                .FirstOrDefaultAsync(g => g.Id == id);
            _dbContext.Stores.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return null;
        }
    }
}

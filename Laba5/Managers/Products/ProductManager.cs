using Laba5.Storage;
using Laba5.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.Products
{
    public class ProductManager : IProductManager
    {
        private readonly StoreDataContext _dbContext;
        public ProductManager(StoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProduct(CreateOrUpdateProductsRequest request)
        {
            var entity = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                TypeProductId = request.TypeProductId
            };

            _dbContext.Products.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<Product> EditProduct(Guid id, CreateOrUpdateProductsRequest request)
        {
            var entity = await _dbContext.Products.Include(st => st.TypeProducts)
                                                  .FirstOrDefaultAsync(g => g.Id == id);
            entity.Name = request.Name;
            entity.Price = request.Price;
            entity.TypeProductId = request.TypeProductId;

            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<Product>> GetAll()
        {
            var query = _dbContext.Products.Include(st => st.TypeProducts)
                                           .AsNoTracking();

            var entities = await query.ToListAsync();

            return entities;
        }
        public async Task<IEnumerable<TypeProduct>> GetAllTypeProduct()
        {
            var query = _dbContext.TypeProducts.AsNoTracking();
            var entities = await query.ToListAsync();

            return entities;
        }
        public async Task<Product> GetById(Guid id)
        {
            return await _dbContext.Products.Include(st => st.TypeProducts)
                                            .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<Product> DataRemove(Guid id)
        {
            var entity = await _dbContext.Products.Include(st => st.TypeProducts)
                                                  .FirstOrDefaultAsync(g => g.Id == id);
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return null;
        }
    }
}

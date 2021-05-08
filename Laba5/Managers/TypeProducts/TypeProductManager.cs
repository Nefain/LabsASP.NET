using Laba5.Storage;
using Laba5.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.TypeProducts
{
    public class TypeProductManager : ITypeProductManager
    {
        private readonly StoreDataContext _dbContext;
        public TypeProductManager(StoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TypeProduct> AddTypeProduct(CreateOrUpdateTypeProductRequest request)
        {
            var entity = new TypeProduct
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            _dbContext.TypeProducts.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<TypeProduct> EditTypeProduct(Guid id, CreateOrUpdateTypeProductRequest request)
        {
            var entity = await _dbContext.TypeProducts.FirstOrDefaultAsync(g => g.Id == id);
            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IReadOnlyCollection<TypeProduct>> GetAll()
        {
            var query = _dbContext.TypeProducts.AsNoTracking();
            var entities = await query.ToListAsync();

            return entities;
        }
        public async Task<TypeProduct> GetById(Guid id)
        {
            return await _dbContext.TypeProducts.FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<TypeProduct> DataRemove(Guid id)
        {
            var entity = await _dbContext.TypeProducts.FirstOrDefaultAsync(g => g.Id == id);
            _dbContext.TypeProducts.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return null;
        }
    }
}

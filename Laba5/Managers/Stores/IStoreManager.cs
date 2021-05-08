using Laba5.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.Stores
{
    public interface IStoreManager
    {
        Task<Store> AddStore(CreateOrUpdateStoreRequest request);
        Task<IReadOnlyCollection<Store>> GetAll();
        Task<Store> EditStore(Guid id, CreateOrUpdateStoreRequest request);
        Task<Store> GetById(Guid id);
        Task<Store> DataRemove(Guid id);
        Task<IEnumerable<Product>> GetAllProduct();
    } 
}

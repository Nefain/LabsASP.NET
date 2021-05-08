using Laba5.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.Products
{
    public interface IProductManager
    {
        Task<IReadOnlyCollection<Product>> GetAll();
        Task<Product> AddProduct(CreateOrUpdateProductsRequest request);
        Task<Product> EditProduct(Guid id, CreateOrUpdateProductsRequest request);
        Task<Product> GetById(Guid id);
        Task<Product> DataRemove(Guid id);
        Task<IEnumerable<TypeProduct>> GetAllTypeProduct();
    }
}

using System;
using Laba5.Storage.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.TypeProducts
{
    public interface ITypeProductManager
    {
        Task<TypeProduct> AddTypeProduct(CreateOrUpdateTypeProductRequest request);
        Task<IReadOnlyCollection<TypeProduct>> GetAll();
        Task<TypeProduct> EditTypeProduct(Guid id, CreateOrUpdateTypeProductRequest request);
        Task<TypeProduct> GetById(Guid id);
        Task<TypeProduct> DataRemove(Guid id);
    }
}

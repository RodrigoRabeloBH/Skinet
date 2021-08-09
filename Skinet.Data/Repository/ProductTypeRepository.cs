using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repository
{
    public class ProductTypeRepository : SkinetRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(SkinetContext context) : base(context) { }
    }
}
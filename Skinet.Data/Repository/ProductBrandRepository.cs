using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repository
{
    public class ProductBrandRepository : SkinetRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(SkinetContext context) : base(context) { }

    }
}
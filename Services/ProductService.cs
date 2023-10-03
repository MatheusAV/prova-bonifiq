using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService : IProductService
    {
		protected readonly TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

        public ItemList<Product> ListProducts(int page)
        {
            int pageSize = 10;
            var customers = _ctx.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            bool hasNext = _ctx.Products.Count() > page * pageSize;

            return new ItemList<Product> { HasNext = hasNext, TotalCount = _ctx.Products.Count(), Items = customers };
        }
    }
}

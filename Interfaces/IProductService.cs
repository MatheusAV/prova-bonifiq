using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IProductService
    {
        ItemList<Product> ListProducts(int page);
    }
}

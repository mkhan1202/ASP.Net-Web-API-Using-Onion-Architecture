using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Model;

namespace Domain_Layer.IRepository
{
    public interface IProductRepository
    {
        Task<ProductModel> CreateProduct(ProductModel product);
        Task<ProductModel?> UpdateProduct(ProductModel product);
        Task<bool> DeleteProduct(Guid id);
        Task<ProductModel?> GetProductById(Guid id);
        Task<IEnumerable<ProductModel>> GetAllProducts();
    }
}

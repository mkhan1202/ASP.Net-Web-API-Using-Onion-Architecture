using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Model;

namespace Domain_Layer.IRepository
{
    internal interface IProductRepository
    {
        Task<ProductModel> CreateProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<ProductModel> DeleteProduct(ProductModel product);
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> GetAllProductByName();
    }
}

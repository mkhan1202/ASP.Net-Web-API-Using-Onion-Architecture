using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.IRepository;
using Domain_Layer.Model;

namespace Infrastructure_Layer.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<ProductModel> CreateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> DeleteProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetAllProductByName()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}

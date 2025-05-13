using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application_Layer.DTOs.ProductDTO;
using Application_Layer.IService;

namespace Application_Layer.Service
{
    public class ProductService : IProductService
    {
        public Task<ProductCreateDTO> CreateProduct(ProductCreateDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreateDTO> DeleteProduct(ProductCreateDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreateDTO> GetAllProductByName()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreateDTO> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreateDTO> UpdateProduct(ProductCreateDTO product)
        {
            throw new NotImplementedException();
        }
    }
}

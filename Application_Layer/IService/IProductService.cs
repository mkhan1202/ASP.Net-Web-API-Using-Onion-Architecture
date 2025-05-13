using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application_Layer.DTOs.ProductDTO;

namespace Application_Layer.IService
{
    public interface IProductService
    {
        Task<ProductCreateDTO> CreateProduct(ProductCreateDTO product);
        Task<ProductCreateDTO> UpdateProduct(ProductCreateDTO product);
        Task<ProductCreateDTO> DeleteProduct(ProductCreateDTO product);
        Task<ProductCreateDTO> GetProductById(int id);
        Task<ProductCreateDTO> GetAllProductByName();
    }
}

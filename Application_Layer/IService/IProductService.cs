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
        Task<ProductReadDTO> CreateProduct(ProductCreateDTO product);
        Task<ProductReadDTO?> UpdateProduct(Guid id, ProductUpdateDTO product);
        Task<bool> DeleteProduct(Guid id);
        Task<ProductReadDTO?> GetProductById(Guid id);
        Task<IEnumerable<ProductReadDTO>> GetAllProduct();
    }
}

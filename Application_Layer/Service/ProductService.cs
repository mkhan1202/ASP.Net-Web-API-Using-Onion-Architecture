using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application_Layer.DTOs.ProductDTO;
using Application_Layer.IService;
using Domain_Layer.IRepository;
using Domain_Layer.Model;
namespace Application_Layer.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repos;
        public ProductService(IProductRepository repos)
        {
            _repos = repos;
        }
        public async Task<ProductCreateDTO> CreateProduct(ProductCreateDTO productDto)
        {
            var product = new ProductModel
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                PurchasePrice = productDto.PurchasePrice,
                SellPrice = productDto.SellPrice,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _repos.CreateProduct(product);

            return new ProductCreateDTO
            {
                Name = product.Name,
                PurchasePrice = product.PurchasePrice,
                SellPrice = product.SellPrice,
            };
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var findProduct= await _repos.GetProductById(id);
            if(findProduct != null)
            {
                await _repos.DeleteProduct(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductReadDTO>> GetAllProduct()
        {
            var products = await _repos.GetAllProducts();

            return products.Select(p => new ProductReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                PurchasePrice = p.PurchasePrice,
                SellPrice = p.SellPrice,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }

        public async Task<ProductReadDTO?> GetProductById(Guid id)
        {
            var products = await _repos.GetProductById(id);

            if (products != null) 
            {
                return new ProductReadDTO
                {
                    Id = products.Id,
                    Name = products.Name,
                    PurchasePrice = products.PurchasePrice,
                    SellPrice = products.SellPrice,
                    CreatedAt = products.CreatedAt,
                    UpdatedAt = products.UpdatedAt
                };
            }
            return null;
        }

        public async Task<ProductUpdateDTO?> UpdateProduct(Guid id, ProductUpdateDTO product)
        {
            var findProduct = await _repos.GetProductById(id);
            if (findProduct != null)
            {
                findProduct.Name = product.Name;
                findProduct.PurchasePrice = product.PurchasePrice;
                findProduct.SellPrice = product.SellPrice;
                findProduct.UpdatedAt = DateTime.UtcNow;

                await _repos.UpdateProduct(findProduct, id);
                return new ProductUpdateDTO
                {
                    Name = product.Name,
                    PurchasePrice = product.PurchasePrice,
                    SellPrice = product.SellPrice,
                };
            }

            return null;
        }
    }
}

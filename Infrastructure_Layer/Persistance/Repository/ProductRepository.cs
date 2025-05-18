using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.IRepository;
using Domain_Layer.Model;
using Infrastructure_Layer.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            ProductModel? findProduct = await _context.Products.FindAsync(id);
            if (findProduct != null)
            {
                _context.Remove(findProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductModel?> GetProductById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductModel?> UpdateProduct(ProductModel product)
        {
            ProductModel? findProduct = await _context.Products.FindAsync(product.Id);

            if (findProduct != null)
            {
                findProduct.Name = product.Name;
                findProduct.SellPrice = product.SellPrice;
                findProduct.PurchasePrice = product.PurchasePrice;
                findProduct.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return findProduct;
            }

            return null;
        }
    }
}

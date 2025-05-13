using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTOs.ProductDTO
{
    internal class ProductCreateDTO
    {
        [Required(ErrorMessage ="Product name is required"), StringLength(100, ErrorMessage ="Product name must be in 100 character")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Purchase Price is required")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "Purchase Price is required")]
        public decimal SellPrice { get; set; }
    }
}

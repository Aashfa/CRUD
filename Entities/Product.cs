using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters.")]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        //[Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public float Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

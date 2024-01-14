using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_BusinessObjects.Models
{
    public class OrderDetail
    {
        [Required, Key]
        [Column(Order = 1)]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required, Key]
        [Column(Order = 2)]
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public float? Discount { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}

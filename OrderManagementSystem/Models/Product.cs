using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Barcode { get; set; }
        public int AvailableQuantity { get; set; }
        public virtual Order Order { get; set; }
    }
}

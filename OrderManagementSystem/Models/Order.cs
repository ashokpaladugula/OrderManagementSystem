using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual CodeList CodeList { get; set; }
        public int StatusId { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }

    }
}

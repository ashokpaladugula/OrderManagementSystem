using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public virtual ContactAddress ContactAddress { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}

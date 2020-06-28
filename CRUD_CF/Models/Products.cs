using System;
using System.Collections.Generic;

namespace CRUD_CF.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
    }
}

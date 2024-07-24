using System;
using System.Collections.Generic;

namespace ApartmentManagement.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Number { get; set; } // Apartment number or identifier
        public int Floor { get; set; }
        public decimal Dues { get; set; } // Monthly dues
        public decimal ElectricityBill { get; set; }
        public decimal WaterBill { get; set; }
        public decimal GasBill { get; set; }
        
        // Navigation property for related Users
        public ICollection<User> Users { get; set; }
    }
}

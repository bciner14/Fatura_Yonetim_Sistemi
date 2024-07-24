using System;

namespace ApartmentManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        // Navigation property for related Apartment
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}

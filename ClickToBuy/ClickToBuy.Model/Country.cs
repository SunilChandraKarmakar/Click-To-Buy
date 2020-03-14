using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}

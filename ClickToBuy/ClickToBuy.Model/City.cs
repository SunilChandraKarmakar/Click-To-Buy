using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required City name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Country name.")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}

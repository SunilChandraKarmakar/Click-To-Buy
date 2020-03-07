using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Gender
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide name.")]
        [StringLength(6, MinimumLength = 4)]
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}

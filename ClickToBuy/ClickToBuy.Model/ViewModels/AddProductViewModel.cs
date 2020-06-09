using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model.ViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide product name.")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide regular price.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Regular Price")]
        [Range(1, 100000000)]
        public float Price { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Quantity { get; set; }
    }
}

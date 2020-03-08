using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide brand name.")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide origin of brand.")]
        [StringLength(50, MinimumLength = 2)]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Provide discription.")]
        [StringLength(500, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

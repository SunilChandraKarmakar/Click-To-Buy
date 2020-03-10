using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Tag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Select Product")] 
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Product Tag")]
        public string TagName { get; set; }

        public Product Product { get; set; }
    }
}

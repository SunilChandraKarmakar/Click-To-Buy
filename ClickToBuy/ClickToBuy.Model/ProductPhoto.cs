using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class ProductPhoto
    {
        public int Id { get; set; }

        [Display(Name = "Product Photo")]
        [StringLength(30, MinimumLength = 1)]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required(ErrorMessage = "Select Product")]
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }
        public bool Featured { get; set; }
        public bool Status { get; set; }

        public Product Product { get; set; }
    }
}

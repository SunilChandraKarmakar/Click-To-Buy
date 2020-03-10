using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order number")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [Range(1, 20)]
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

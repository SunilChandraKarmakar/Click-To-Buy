using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class StockProduct
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Provide product name.")]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Range(1, 5000)]
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}

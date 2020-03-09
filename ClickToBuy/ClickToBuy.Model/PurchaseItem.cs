using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class PurchaseItem
    {
        public int Id { get; set; }

        [Required]
        public int PurchaseId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 1000000)]
        public float Price { get; set; }

        public Purchase Purchase { get; set; }
    }
}

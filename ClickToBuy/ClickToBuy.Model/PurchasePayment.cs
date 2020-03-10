using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class PurchasePayment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Purchase Number")]
        public int PurchaseId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 100000)]
        public float Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Purchase Purchase { get; set; }
    }
}

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
        [Range(0, 100000)]
        [Display(Name = "Pay Amount")]
        public float PayAmount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 100000)]
        [Display(Name = "Due Amount")]
        public float DueAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}

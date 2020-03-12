using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Purchase
    {
        public Purchase()
        {
            PurchasePayment = new PurchasePayment();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6)]
        [Display(Name = "Purchase Number")]
        public string PurchaseNumber { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
        public PurchasePayment PurchasePayment { get; set; }
        public ICollection<StockProduct> StockProducts { get; set; } 
    }
}

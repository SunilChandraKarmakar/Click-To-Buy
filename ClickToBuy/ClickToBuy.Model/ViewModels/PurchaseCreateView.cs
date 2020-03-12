using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model.ViewModels
{
    public class PurchaseCreateView
    { 
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

        [Required(ErrorMessage = "Select Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Provied quantity")]
        [DataType(DataType.PhoneNumber)]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 1000000)]
        public float Price { get; set; }

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

        public Purchase Purchase { get; set; }
        public Product Product { get; set; }     
        public Supplier Supplier { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
        public PurchasePayment PurchasePayment { get; set; }
        public ICollection<StockProduct> StockProducts { get; set; }
    }
}

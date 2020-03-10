using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied cupon number.")]
        [StringLength(30, MinimumLength = 8)]
        public string CouponNumber { get; set; }

        [Required]
        [Display(Name = "Customer name")]
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 2000)]
        public float Amount { get; set; }

        public Customer Customer { get; set; }
    }
}

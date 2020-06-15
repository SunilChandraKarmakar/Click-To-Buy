using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Provied order no.")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }

        [Required(ErrorMessage = "Customer name please.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }     

        [Display(Name = "Coupon Number")]
        [StringLength(20, MinimumLength = 8)]
        public string CouponNumber { get; set; }

        [Required(ErrorMessage = "Provied customer billing address.")]
        public int CustomerBillingAddressId { get; set; }

        [Required(ErrorMessage = "Select delivary please.")]
        [Display(Name = "Delivary please.")]
        public int DeliveryChargeId { get; set; }

        public bool Status { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
        public CustomerBillingAddress CustomerBillingAddress { get; set; }
        public DeliveryCharge DeliveryCharge { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<ReturnProduct> ReturnProducts { get; set; }




    }
}

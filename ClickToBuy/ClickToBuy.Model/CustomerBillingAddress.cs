using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class CustomerBillingAddress
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide customer name")] 
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Provide your bulling address.")]
        [Display(Name = "Billing Address")]
        [DataType(DataType.MultilineText)]
        [StringLength(5000, MinimumLength = 10)]
        public string BillingAddress { get; set; }

        public Customer Customer { get; set; }
    }
}

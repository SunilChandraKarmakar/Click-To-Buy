using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class DeliveryCharge
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Select city")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Provied ammount")]
        [DataType(DataType.Currency)]
        [Range(1, 5000)]
        public float Ammount { get; set; }

        public City City { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

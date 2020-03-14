using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClickToBuy.Model
{
    public class Admin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provied contact number.")]
        [StringLength(14, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Provied email address")]
        [StringLength(50, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Provied password.")]
        [StringLength(14, MinimumLength = 5)]
        [DataType(DataType.PhoneNumber)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Provied confirm password.")]
        [StringLength(30, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Not match in Password!")]
        public string ConfirmPassword { get; set; }

        public string Picture { get; set; }

        [Required(ErrorMessage = "Select country.")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Select City")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Provied address.")]
        [StringLength(500, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClickToBuy.Model
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not match in password!")]
        public string ConfirmPassword { get; set; }

        public string Pictuer { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public string CustomerIPAddress { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public Gender Gender { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}

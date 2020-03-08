using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide product name.")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide category name.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Provide brand name.")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Provide condition type.")]
        public int ConditionId { get; set; }

        [Required(ErrorMessage = "Provide Close Type.")]
        public int CloseTypeId { get; set; }

        [Required(ErrorMessage = "Provide regular price.")]
        [DataType(DataType.Currency)]
        [Range(1, 1000000)]
        public float RegularPrice { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, 1000000)]
        public float? OfferPrice { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [DataType(DataType.MultilineText)]
        public string Link { get; set; }

        [Required(ErrorMessage = "Provide product details.")]
        [StringLength(2000, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string ProductDetails { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Condition Condition { get; set; }
        public CloseType CloseType { get; set; }
    }
}

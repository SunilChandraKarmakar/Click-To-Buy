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
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Provide brand name.")]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Provide condition type.")]
        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        [Required(ErrorMessage = "Provide Close Type.")]
        [Display(Name = "Status")]
        public int CloseTypeId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Provide regular price.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Regular Price")]
        [Range(1, 1000000)]
        public float RegularPrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Offer Price")]
        [Range(0, 1000000)]
        public float? OfferPrice { get; set; }

        [DataType(DataType.MultilineText)]
        public string Link { get; set; }

        [Required(ErrorMessage = "Provide product details.")]
        [StringLength(2000, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Product Details")]
        public string ProductDetails { get; set; }

        public Customer Customer { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Condition Condition { get; set; }
        public CloseType CloseType { get; set; }
        public ICollection<StockProduct> StockProducts { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<ReturnProduct> ReturnProducts { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}

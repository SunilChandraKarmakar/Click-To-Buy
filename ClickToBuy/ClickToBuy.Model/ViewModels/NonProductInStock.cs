using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Model.ViewModels
{
    public class NonProductInStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ConditionId { get; set; }
        public int CloseTypeId { get; set; }
        public float RegularPrice { get; set; }
        public float? OfferPrice { get; set; }
        public string Picture { get; set; }    
        public string Link { get; set; }
        public string ProductDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Slider
    {
        public int Id { get; set; }
                
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        public string PhotoName { get; set; }
        public bool Status { get; set; }
    }
}

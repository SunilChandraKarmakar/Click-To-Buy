using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Condition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}

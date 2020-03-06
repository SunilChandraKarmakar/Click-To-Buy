using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClickToBuy.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide category name")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Provide description of category")]
        [StringLength(1000, MinimumLength = 2)]
        public string Description { get; set; }

        public Category Categoryy { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}

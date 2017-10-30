using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestTask.Models;

namespace TestTask.ViewModels
{
    public class EditBasketViewModel
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public EditBasketViewModel()
        {
            Products = new List<Product>();
        }
    }
}
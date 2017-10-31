using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.ViewModels
{
    public class EditProductViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
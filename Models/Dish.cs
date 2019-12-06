using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Display (Name="Dish Name: ")]
        [Required (ErrorMessage = "A dish is required.")]
        public string dishName { get; set; }
        [Display (Name="Calories: ")]
        [Required (ErrorMessage = "Amount of caloires is required.")]
        [CaloriesGreaterThanZero]
        public int calories { get; set; }
        [Display (Name="Tastiness: ")]
        [Required (ErrorMessage = "Tasty rating is required.")]
        [Range(1, 5, ErrorMessage = "Please enter a rating between 1 and 5.")]
        public int tastiness { get; set; }
        [Display (Name="Description: ")]
        [Required (ErrorMessage = "A description is required.")]
        public string description { get; set; }
        public int chefId { get; set; }
        //navigation property
        public Chef Chef { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
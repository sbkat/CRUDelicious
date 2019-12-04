using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Display (Name="Chef's Name: ")]
        [Required (ErrorMessage = "Chef's name is required.")]
        public string chefsName { get; set; }
        [Display (Name="Dish Name: ")]
        [Required (ErrorMessage = "A dish is required.")]
        public string dishName { get; set; }
        [Display (Name="Calories: ")]
        [Required (ErrorMessage = "Amount of caloires is required.")]
        public int calories { get; set; }
        [Display (Name="Tastiness: ")]
        [Required (ErrorMessage = "Tasty rating is required.")]
        public int tastiness { get; set; }
        [Display (Name="Description: ")]
        [Required (ErrorMessage = "A description is required.")]
        public string description { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
}
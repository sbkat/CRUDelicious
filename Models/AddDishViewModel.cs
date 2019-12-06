using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDelicious.Models
{
    public class AddDishViewModel
    {
        [NotMapped]
        public Dish Dish { get; set; }
        public List<Chef> SelectChef { get; set; }
        [Display (Name="Chef: ")]
        public int chefId { get; set; }
    }
}
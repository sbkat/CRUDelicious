using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDelicious.Models
{
    public class AddDishViewModel
    {
        [NotMapped]
        public Dish Dish { get; set; }
        public List<Chef> SelectChef { get; set; }
        public int chefId { get; set; }
        public AddDishViewModel() {
            SelectChef = new List<Chef>();
        }
    }
}
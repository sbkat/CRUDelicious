using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDelicious.Models
{
    public class Chef
    {
        [Key]
        public int chefId { get; set; }
        [Display (Name="First Name: ")]
        [Required (ErrorMessage = "First name is required.")]
        public string firstName { get; set; }
        [Display (Name="Last Name: ")]
        [Required (ErrorMessage = "Last name is required.")]
        public string lastName { get; set; }
        [Display (Name="Date of Birth: ")]
        [Required (ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime dateOfBirth { get; set; }
        //navigation property
        public List<Dish> CreatedDishes { get; set; }
    }
}
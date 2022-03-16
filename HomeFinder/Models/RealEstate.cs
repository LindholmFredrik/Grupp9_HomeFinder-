﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinder.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        public string Pictures { get; set; }
        public string Description { get; set; }
        [Display(Name = "Form Of Lease")]
        [Required]
        public string FormOfLease { get; set; }
<<<<<<< HEAD
        [Column(TypeName="decimal(18,4)")]
        public decimal Price { get; set; }
=======
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        [Display(Name = "Rooms")]
>>>>>>> b1ce262c168580b947cc65dd8a322588cb7aae3d
        public int NumberOfRooms { get; set; }
        [Display(Name = "Living Area")]
        public int LivingArea { get; set; }
        [Display(Name = "Construction Year")]
        [DataType(DataType.Date)]
        public DateTime ConstructionYear { get; set; }
        [Display(Name = "Show Date")]
        [DataType(DataType.Date)]
        public DateTime ShowDate { get; set; }
        public List<RegistrationOfInterest> RegistrationsOfInterest{ get; set; }
    }
}
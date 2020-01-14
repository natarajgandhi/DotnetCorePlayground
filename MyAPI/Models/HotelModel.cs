using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Models
{
    public class HotelModel
    {
        [Required]
        public string Name { get; set; }
        public string Cuisine { get; set; }
        //public string LocationName { get; set; }
        public LocationModel Location { get; set; }

    }
}

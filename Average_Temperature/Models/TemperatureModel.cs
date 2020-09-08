using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Average_Temperature.Models
{
    public class TemperatureModel
    {
        [Display(Name = "城市")]
        public string City { get; set; }

        [Display(Name = "溫度")]
        public double[] Temperature { get; set; }
    }
}
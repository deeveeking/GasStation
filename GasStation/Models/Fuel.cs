using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GasStation.Models
{
    public class Fuel
    {
       
        public int Id { get; set; }
        public int Liters { get; set; }
        public double Price { get;}
        public string Name { get; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Models 
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
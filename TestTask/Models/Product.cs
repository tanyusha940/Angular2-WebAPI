﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public ICollection<Basket> Baskets { get; set; }
        public Product()
        {
            Baskets = new List<Basket>();
        }
    }
}
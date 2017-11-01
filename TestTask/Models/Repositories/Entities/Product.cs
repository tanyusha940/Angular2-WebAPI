using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Basket> Baskets { get; set; }

        public Product()
        {
            Baskets = new List<Basket>();
        }
    }
}
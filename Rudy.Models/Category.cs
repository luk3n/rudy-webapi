using System.Collections.Generic;

namespace Rudy.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Product> products { get; set; }
    }
}

using System.Collections.Generic;

namespace Rudy.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}

using System;
namespace Rudy.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public CategoryDTO category { get; set; }
    }
}

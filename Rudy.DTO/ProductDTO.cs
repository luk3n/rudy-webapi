using System;
namespace Rudy.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public int measurementUnit { get; set; }
        public DateTime CreationDate { get; set; }
        public CategoryDTO Category { get; set; }
    }
}

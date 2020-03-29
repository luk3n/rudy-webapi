using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rudy.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int MeasurementUnit { get; set; }
        public DateTime CreationDate { get; set; }
        public LineItem LineItem { get; set; }
        public Category Category { get; set; }
    }
}

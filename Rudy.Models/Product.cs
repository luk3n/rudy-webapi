using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rudy.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public string code { get; set; }
        public string barcode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        public int measurementUnit { get; set; }
        public DateTime creationDate { get; set; }
        public LineItem lineItem { get; set; }
        public Category category { get; set; }
    }
}

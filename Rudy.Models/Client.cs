using System.ComponentModel.DataAnnotations.Schema;

namespace Rudy.Models
{
    [Table("Clients")]
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

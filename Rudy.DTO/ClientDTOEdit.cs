using System.ComponentModel.DataAnnotations;

namespace Rudy.DTO
{
    public class ClientDTOEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
    }
}

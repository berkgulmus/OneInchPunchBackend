using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
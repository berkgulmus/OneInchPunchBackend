using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

    }
}
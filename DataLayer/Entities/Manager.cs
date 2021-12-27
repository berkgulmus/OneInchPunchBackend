using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
    }
}
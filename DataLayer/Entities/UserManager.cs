using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class UserManager
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Manager Manager { get; set; }
    }
}
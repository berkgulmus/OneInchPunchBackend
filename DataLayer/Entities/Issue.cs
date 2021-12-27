using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Point { get; set; }
        [Required]
        public Status Status{ get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public Task Task { get; set; }
    }
}
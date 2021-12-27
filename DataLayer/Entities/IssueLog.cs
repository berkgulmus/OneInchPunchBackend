using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class IssueLog
    {
        public int Id { get; set; }
        [Required]
        public Issue Issue{ get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DataLayer.Entities
{
    public class Deparment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<User> Users{ get; set; }
    }
}
using System.Collections.Generic;
using DataLayer.Entities;

namespace BusinessLayer.Responses
{
    public class GetDeparmentByIdWithUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
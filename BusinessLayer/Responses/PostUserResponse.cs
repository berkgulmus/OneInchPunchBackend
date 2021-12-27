using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Entities;

namespace BusinessLayer.Responses
{
    public class PostUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Deparment Deparment { get; set; }
        public Role Role { get; set; }
    }
}

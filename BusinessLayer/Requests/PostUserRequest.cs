using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Requests
{
    public class PostUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DeparmentId{ get; set; }
        public int RoleId { get; set; }
    }
}

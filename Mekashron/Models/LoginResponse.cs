using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mekashron.Models
{
    public class LoginResponse
    {
        public int EntityId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ResultMessage { get; set; }
    }
}
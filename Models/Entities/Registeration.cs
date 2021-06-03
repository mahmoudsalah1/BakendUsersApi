using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUsers.Models.Entities
{
    public class Registeration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

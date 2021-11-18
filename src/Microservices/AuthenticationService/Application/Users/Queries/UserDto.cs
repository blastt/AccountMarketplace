using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}

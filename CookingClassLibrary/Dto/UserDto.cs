using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingClassLibrary.Dto
{
    public class UserDto
    {
        public long UserId { get; set; }

        public string Username { get; set; } = null!;

        public long CredentialsId { get; set; }
    }
}

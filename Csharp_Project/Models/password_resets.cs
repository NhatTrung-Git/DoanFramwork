using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class password_resets
    {
        private string email;
        private string token;
        private DateTime created_at;

        public string Email { get => email; set => email = value; }
        public string Token { get => token; set => token = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }

        public password_resets()
        {
        }

        public password_resets(string email, string token, DateTime created_at)
        {
            this.email = email;
            this.token = token;
            this.created_at = created_at;
        }
    }
}

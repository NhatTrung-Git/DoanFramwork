using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_admin
    {
        private int admin_id;
        private string admin_email;
        private string admin_password;
        private string admin_name;
        private string admin_phone;
        private DateTime created_at;
        private DateTime updated_at;

        public int Admin_id { get => admin_id; set => admin_id = value; }
        public string Admin_email { get => admin_email; set => admin_email = value; }
        public string Admin_password { get => admin_password; set => admin_password = value; }
        public string Admin_name { get => admin_name; set => admin_name = value; }
        public string Admin_phone { get => admin_phone; set => admin_phone = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_admin()
        {
        }

        public tbl_admin(int admin_id, string admin_email, string admin_password, string admin_name, string admin_phone, DateTime created_at, DateTime updated_at)
        {
            this.admin_id = admin_id;
            this.admin_email = admin_email;
            this.admin_password = admin_password;
            this.admin_name = admin_name;
            this.admin_phone = admin_phone;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

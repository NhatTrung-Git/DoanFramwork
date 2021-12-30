using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_customers
    {
        private int customer_id;
        private string customer_name;
        private string customer_email;
        private string customer_password;
        private string customer_phone;
        private DateTime created_at;
        private DateTime updated_at;
        public tbl_customers() { }
        public tbl_customers(int customer_id, string customer_name, string customer_email, string customer_password, string customer_phone, DateTime created_at, DateTime updated_at)
        {
            this.Customer_id = customer_id;
            this.Customer_name = customer_name;
            this.Customer_email = customer_email;
            this.Customer_password = customer_password;
            this.Customer_phone = customer_phone;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }

        public int Customer_id { get => customer_id; set => customer_id = value; }
        public string Customer_name { get => customer_name; set => customer_name = value; }
        public string Customer_email { get => customer_email; set => customer_email = value; }
        public string Customer_password { get => customer_password; set => customer_password = value; }
        public string Customer_phone { get => customer_phone; set => customer_phone = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_shipping
    {
        private int shipping_id;
        private string shipping_name;
        private string shipping_img;
        private string shipping_phone;
        private string shipping_email;
        private string shipping_password;
        private string shipping_notes;
        private DateTime created_at;
        private DateTime updated_at;

        public int Shipping_id { get => shipping_id; set => shipping_id = value; }
        public string Shipping_name { get => shipping_name; set => shipping_name = value; }
        public string Shipping_img { get => shipping_img; set => shipping_img = value; }
        public string Shipping_phone { get => shipping_phone; set => shipping_phone = value; }
        public string Shipping_email { get => shipping_email; set => shipping_email = value; }
        public string Shipping_password { get => shipping_password; set => shipping_password = value; }
        public string Shipping_notes { get => shipping_notes; set => shipping_notes = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_shipping()
        {
        }

        public tbl_shipping(int shipping_id, string shipping_name, string shipping_img, string shipping_phone, string shipping_email, string shipping_password, string shipping_notes, DateTime created_at, DateTime updated_at)
        {
            this.shipping_id = shipping_id;
            this.shipping_name = shipping_name;
            this.shipping_img = shipping_img;
            this.shipping_phone = shipping_phone;
            this.shipping_email = shipping_email;
            this.shipping_password = shipping_password;
            this.shipping_notes = shipping_notes;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

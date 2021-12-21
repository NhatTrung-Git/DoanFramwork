using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_payment
    {
        private long payment_id;
        private string payment_method;
        private string payment_status;
        private DateTime created_at;
        private DateTime updated_at;

        public long Payment_id { get => payment_id; set => payment_id = value; }
        public string Payment_method { get => payment_method; set => payment_method = value; }
        public string Payment_status { get => payment_status; set => payment_status = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_payment()
        {
        }

        public tbl_payment(long payment_id, string payment_method, string payment_status, DateTime created_at, DateTime updated_at)
        {
            this.payment_id = payment_id;
            this.payment_method = payment_method;
            this.payment_status = payment_status;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

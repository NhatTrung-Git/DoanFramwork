using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_order
    {
        private long order_id;
        private int customer_id;
        private int shipping_id;
        private int payment_id;
        private string order_total;
        private string order_status;
        private DateTime created_at;
        private DateTime updated_at;

        public long Order_id { get => order_id; set => order_id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Shipping_id { get => shipping_id; set => shipping_id = value; }
        public int Payment_id { get => payment_id; set => payment_id = value; }
        public string Order_total { get => order_total; set => order_total = value; }
        public string Order_status { get => order_status; set => order_status = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_order()
        {
        }

        public tbl_order(long order_id, int customer_id, int shipping_id, int payment_id, string order_total, string order_status, DateTime created_at, DateTime updated_at)
        {
            this.order_id = order_id;
            this.customer_id = customer_id;
            this.shipping_id = shipping_id;
            this.payment_id = payment_id;
            this.order_total = order_total;
            this.order_status = order_status;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

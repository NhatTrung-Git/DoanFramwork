using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_order_details
    {
        private long order_details_id;
        private int order_id;
        private int product_id;
        private string address;
        private string product_price;
        private int product_sales_quantity;
        private DateTime created_at;
        private DateTime updated_at;

        public long Order_details_id { get => order_details_id; set => order_details_id = value; }
        public int Order_id { get => order_id; set => order_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public string Address { get => address; set => address = value; }
        public string Product_price { get => product_price; set => product_price = value; }
        public int Product_sales_quantity { get => product_sales_quantity; set => product_sales_quantity = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_order_details()
        {
        }

        public tbl_order_details(long order_details_id, int order_id, int product_id, string address, string product_price, int product_sales_quantity, DateTime created_at, DateTime updated_at)
        {
            this.order_details_id = order_details_id;
            this.order_id = order_id;
            this.product_id = product_id;
            this.address = address;
            this.product_price = product_price;
            this.product_sales_quantity = product_sales_quantity;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

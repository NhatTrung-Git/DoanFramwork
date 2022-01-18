using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class cart
    {
        private int cart_id;
        private int customer_id;
        private int product_id;
        private int cart_quantity;
        private string cart_price;

        public int Cart_id { get => cart_id; set => cart_id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public int Cart_quantity { get => cart_quantity; set => cart_quantity = value; }
        public string Cart_price { get => cart_price; set => cart_price = value; }

        public cart()
        {
        }

        public cart(int cart_id, int customer_id, int product_id, int cart_quantity, string cart_price)
        {
            this.cart_id = cart_id;
            this.customer_id = customer_id;
            this.product_id = product_id;
            this.cart_quantity = cart_quantity;
            this.cart_price = cart_price;
        }
    }
}

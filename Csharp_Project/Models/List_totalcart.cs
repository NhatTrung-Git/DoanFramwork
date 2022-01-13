using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class List_totalcart
    {
        private long order_id;
        private string order_total;
        private string order_status;
        private List<object> list;

        public long Order_id { get => order_id; set => order_id = value; }
        public string Order_total { get => order_total; set => order_total = value; }
        public string Order_status { get => order_status; set => order_status = value; }
        public List<object> List { get => list; set => list = value; }

        public List_totalcart()
        {
        }

        public List_totalcart(long order_id, string order_total, string order_status, List<object> list)
        {
            this.order_id = order_id;
            this.order_total = order_total;
            this.order_status = order_status;
            this.list = list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_voucher
    {
        private int voucher_id;
        private string voucher_code;
        private string voucher_name;
        private int voucher_quantity;
        private DateTime voucher_date;
        private int voucher_sale;

        public int Voucher_id { get => voucher_id; set => voucher_id = value; }
        public string Voucher_code { get => voucher_code; set => voucher_code = value; }
        public string Voucher_name { get => voucher_name; set => voucher_name = value; }
        public int Voucher_quantity { get => voucher_quantity; set => voucher_quantity = value; }
        public DateTime Voucher_date { get => voucher_date; set => voucher_date = value; }
        public int Voucher_sale { get => voucher_sale; set => voucher_sale = value; }

        public tbl_voucher()
        {
        }

        public tbl_voucher(int voucher_id, string voucher_code, string voucher_name, int voucher_quantity, DateTime voucher_date, int voucher_sale)
        {
            this.voucher_id = voucher_id;
            this.voucher_code = voucher_code;
            this.voucher_name = voucher_name;
            this.voucher_quantity = voucher_quantity;
            this.voucher_date = voucher_date;
            this.voucher_sale = voucher_sale;
        }
    }
}

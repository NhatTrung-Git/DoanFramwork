using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_category_product
    {
        private int category_id;
        private string category_name;
        private string slug_category_product;
        private string category_desc;
        private int category_status;
        private DateTime created_at;
        private DateTime updated_at;

        public int Category_id { get => category_id; set => category_id = value; }
        public string Category_name { get => category_name; set => category_name = value; }
        public string Slug_category_product { get => slug_category_product; set => slug_category_product = value; }
        public string Category_desc { get => category_desc; set => category_desc = value; }
        public int Category_status { get => category_status; set => category_status = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_category_product()
        {
        }

        public tbl_category_product(int category_id, string category_name, string slug_category_product, string category_desc, int category_status, DateTime created_at, DateTime updated_at)
        {
            this.category_id = category_id;
            this.category_name = category_name;
            this.slug_category_product = slug_category_product;
            this.category_desc = category_desc;
            this.category_status = category_status;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

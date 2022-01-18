using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_product
    {
        private int product_id;
        private string product_name;
        private string product_slug;
        private int category_id;
        private int brand_id;
        private string product_desc;
        private string product_content;
        private string product_price;
        private string product_image;
        private int product_status;
        private DateTime created_at;
        private DateTime updated_at;

        public int Product_id { get => product_id; set => product_id = value; }
        public string Product_name { get => product_name; set => product_name = value; }
        public string Product_slug { get => product_slug; set => product_slug = value; }
        public int Category_id { get => category_id; set => category_id = value; }
        public int Brand_id { get => brand_id; set => brand_id = value; }
        public string Product_desc { get => product_desc; set => product_desc = value; }
        public string Product_content { get => product_content; set => product_content = value; }
        public string Product_price { get => product_price; set => product_price = value; }
        public string Product_image { get => product_image; set => product_image = value; }
        public int Product_status { get => product_status; set => product_status = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_product()
        {
        }

        public tbl_product(int product_id, string product_name, string product_slug, int category_id, int brand_id, string product_desc, string product_content, string product_price, string product_image, int product_status, DateTime created_at, DateTime updated_at)
        {
            this.product_id = product_id;
            this.product_name = product_name;
            this.product_slug = product_slug;
            this.category_id = category_id;
            this.brand_id = brand_id;
            this.product_desc = product_desc;
            this.product_content = product_content;
            this.product_price = product_price;
            this.product_image = product_image;
            this.product_status = product_status;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class tbl_brand
    {
        private int brand_id;
        private string brand_name;
        private string brand_image;
        private string brand_desc;
        private int brand_status;
        private DateTime created_at;
        private DateTime updated_at;

        public int Brand_id { get => brand_id; set => brand_id = value; }
        public string Brand_name { get => brand_name; set => brand_name = value; }
        public string Brand_image { get => brand_image; set => brand_image = value; }
        public string Brand_desc { get => brand_desc; set => brand_desc = value; }
        public int Brand_status { get => brand_status; set => brand_status = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }

        public tbl_brand()
        {
        }

        public tbl_brand(int brand_id, string brand_name, string brand_image, string brand_desc, int brand_status, DateTime created_at, DateTime updated_at)
        {
            this.brand_id = brand_id;
            this.brand_name = brand_name;
            this.brand_image = brand_image;
            this.brand_desc = brand_desc;
            this.brand_status = brand_status;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}

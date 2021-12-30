using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Csharp_Project.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }
        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<object> GetTbl_Products()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT product_id, p.created_at,  category_name, product_name, product_price, product_image, product_status   FROM `tbl_product` p JOIN tbl_category_product cp on p.category_id = cp.category_id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["product_status"]) != 0)
                        {
                            list.Add(new
                            {
                                id = Convert.ToInt32(reader["product_id"]),
                                time = Convert.ToDateTime(reader["created_at"]).ToString("dd/MM/yyyy"),
                                danhmuc = reader["category_name"].ToString(),
                                name = reader["product_name"].ToString(),
                                cost = reader["product_price"].ToString(),
                                image = reader["product_image"].ToString(),
                                state = "Còn hàng",
                                status = "active",
                            });
                        }
                        else
                        {
                            list.Add(new
                            {
                                id = Convert.ToInt32(reader["product_id"]),
                                time = Convert.ToDateTime(reader["created_at"]).ToString("dd/MM/yyyy"),
                                danhmuc = reader["category_name"].ToString(),
                                name = reader["product_name"].ToString(),
                                cost = reader["product_price"].ToString(),
                                image = reader["product_image"].ToString(),
                                state = "Hết hàng",
                                status = "block",
                            });
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<object> GetTbl_Category_Products()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT category_id, category_name FROM tbl_category_product";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new
                        {
                            Category_id = Convert.ToInt32(reader["category_id"]),
                            Category_name = reader["category_name"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> GetTbl_Brands() 
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT brand_id, brand_name  FROM tbl_brand";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            Brand_id = Convert.ToInt32(reader["brand_id"]),
                            Brand_name = reader["brand_name"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public object GetTbl_ProductById(int id)
        {
            object p = new object();
            using(MySqlConnection conn = GetConnection())
            {
                string str = "SELECT product_id,product_name, category_id,brand_id,product_price,product_image,product_status FROM `tbl_product` WHERE product_id = @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using(var reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        p = new
                        {
                            product_id = Convert.ToInt32(reader["product_id"]),
                            product_name = reader["product_name"].ToString(),
                            category_id = Convert.ToInt32(reader["category_id"]),
                            brand_id = Convert.ToInt32(reader["brand_id"]),
                            product_price = reader["product_price"].ToString(),
                            product_image = reader["product_image"].ToString(),
                            product_status = Convert.ToInt32(reader["product_status"]),
                        };
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return p;
        }
        public int InsertProduct(string product_name, int category_id, int brand_id, string product_price, string product_image, int product_status)
        {
            using(MySqlConnection conn = GetConnection())
            {
                string str = "INSERT INTO `tbl_product`(`product_name`, `product_slug`, `category_id`, `brand_id`, `product_desc`, `product_content`, `product_price`, `product_image`, `product_status`, `created_at`, `updated_at`) VALUES (@name, @slug, @category, @brand, @desc, @content, @price, @image, @status, @created, @updated)";
                Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
                string temp = product_name.Normalize(NormalizationForm.FormD);
                string str2 =  regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("name", product_name);
                cmd.Parameters.AddWithValue("slug", str2.Replace(" ", "-"));
                cmd.Parameters.AddWithValue("category", category_id);
                cmd.Parameters.AddWithValue("brand", brand_id);
                cmd.Parameters.AddWithValue("desc", product_name);
                cmd.Parameters.AddWithValue("content", product_name);
                cmd.Parameters.AddWithValue("price", product_price);
                cmd.Parameters.AddWithValue("image", product_image);
                cmd.Parameters.AddWithValue("status", product_status);
                cmd.Parameters.AddWithValue("created", DateTime.Now);
                cmd.Parameters.AddWithValue("updated", null);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateProduct(int product_id, string product_name, int category_id, int brand_id, string product_price, string product_image, int product_status)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "UPDATE `tbl_product` SET `product_name`= @name,`category_id`= @category,`brand_id`= @brand, `product_price`=  @price,`product_image`= @image,`product_status`= @status, `updated_at`= @updated WHERE `product_id`= @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", product_id);
                cmd.Parameters.AddWithValue("name", product_name);
                cmd.Parameters.AddWithValue("category", category_id);
                cmd.Parameters.AddWithValue("brand", brand_id);
                cmd.Parameters.AddWithValue("price", product_price);
                cmd.Parameters.AddWithValue("image", product_image);
                cmd.Parameters.AddWithValue("status", product_status);
                cmd.Parameters.AddWithValue("updated", DateTime.Now);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteProduct(int product_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "DELETE FROM `tbl_product` WHERE `product_id`= @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", product_id);
                return cmd.ExecuteNonQuery();
            }
        }
        public List<object> GetTbl_Shippings()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT `shipping_id`, `shipping_name`, `shipping_img`, `shipping_email`, `shipping_notes`, `created_at` FROM `tbl_shipping`";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            id = Convert.ToInt32(reader["shipping_id"]),
                            time = Convert.ToDateTime(reader["created_at"]).ToString("dd/MM/yyyy"),
                            email = reader["shipping_email"].ToString(),
                            name = reader["shipping_name"].ToString(),
                            image = reader["shipping_img"].ToString(),
                            state = reader["shipping_notes"].ToString(),
                            status = reader["shipping_notes"].ToString().ToLower(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int InsertShipping(string shipping_name, string shipping_email, string shipping_password, string shipping_phone, string shipping_img)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT shipping_id FROM `tbl_shipping` WHERE shipping_email = @mail";
                string str1 = "INSERT INTO `tbl_shipping`(`shipping_name`, `shipping_img`, `shipping_phone`, `shipping_email`, `shipping_password`, `shipping_notes`, `created_at`, `updated_at`) VALUES (@name,@img,@phone,@email,@pass,@status,@created,@updated)";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mail", shipping_email);
                using (var reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        return -1;
                    }
                    reader.Close();
                    cmd = new MySqlCommand(str1, conn);
                    cmd.Parameters.AddWithValue("name", shipping_name);
                    cmd.Parameters.AddWithValue("img", shipping_img);
                    cmd.Parameters.AddWithValue("phone", shipping_phone);
                    cmd.Parameters.AddWithValue("email", shipping_email);
                    cmd.Parameters.AddWithValue("pass", shipping_password);
                    cmd.Parameters.AddWithValue("status", "Active");
                    cmd.Parameters.AddWithValue("created", DateTime.Now);
                    cmd.Parameters.AddWithValue("updated", null);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int UpdateShipping(int shipping_id, string shipping_notes)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "UPDATE `tbl_shipping` SET `shipping_notes`= @status,`updated_at`= @updated WHERE shipping_id = @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", shipping_id);
                cmd.Parameters.AddWithValue("status", shipping_notes);
                cmd.Parameters.AddWithValue("updated", DateTime.Now);
                return cmd.ExecuteNonQuery();
            }
        }
        public List<object> GetTbl_Orders()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT order_id, customer_name, customer_email, order_address, order_status, order_total, customer_phone, od.created_at FROM `tbl_order` od JOIN `tbl_customers` cs on od.customer_id = cs.customer_id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string stt = "";
                        switch (reader["order_status"].ToString())
                        {
                            case "Đã giao":
                                stt = "active";
                                break;
                            case "Đang giao":
                                stt = "waiting";
                                break;
                            case "Đã hủy đơn":
                                stt = "block";
                                break;
                            default:
                                stt = "";
                                break;
                        }
                        if(stt.CompareTo("") != 0)
                        {
                            list.Add(new
                            {
                                id = Convert.ToInt32(reader["order_id"]),
                                time = Convert.ToDateTime(reader["created_at"]).ToString("dd/MM/yyyy"),
                                email = reader["customer_email"].ToString(),
                                received = reader["customer_name"].ToString(),
                                address = reader["order_address"].ToString(),
                                numberPhone = reader["customer_phone"].ToString(),
                                cost = reader["order_total"].ToString(),
                                state = reader["order_status"].ToString(),
                                status = stt,
                            });
                        }    
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int UpdateOrder(int order_id, string order_status)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "UPDATE `tbl_order` SET `order_status`= @status,`updated_at`= @updated WHERE `order_id`= @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", order_id);
                cmd.Parameters.AddWithValue("status", order_status);
                cmd.Parameters.AddWithValue("updated", DateTime.Now);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

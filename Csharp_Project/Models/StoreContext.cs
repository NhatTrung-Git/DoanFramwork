using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

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
        public string Hash(string text)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public bool VerifyHash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public List<tbl_customers> Customers()
        {
            List<tbl_customers> list = new List<tbl_customers>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from tbl_customers";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new tbl_customers()
                        {
                            Customer_id = Convert.ToInt32(reader["customer_id"]),
                            Customer_email = reader["customer_email"].ToString(),
                            Customer_name = reader["customer_name"].ToString(),
                            Customer_password = reader["customer_password"].ToString(),
                            Customer_phone = reader["customer_phone"].ToString(),
                        });
                    }
                }

                conn.Close();

            }
            return list;
        }
        public int InsertUser(tbl_customers us)
        {
            List<tbl_customers> customers = Customers();
            for (int i = 0; i < customers.Count; i++)
            {
                if (us.Customer_email == customers[i].Customer_email)
                {
                    return 0;
                }
            }
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into tbl_customers values(NULL,@name,@email,@password,@phone,NULL,NULL)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                var hash = Hash(us.Customer_password);
                cmd.Parameters.AddWithValue("name", us.Customer_name);
                cmd.Parameters.AddWithValue("email", us.Customer_email);
                cmd.Parameters.AddWithValue("password", hash);
                cmd.Parameters.AddWithValue("phone", us.Customer_phone);
                return (cmd.ExecuteNonQuery());

            }
        }

        public tbl_customers loginUser(string Customer_email, string Customer_password)
        {
            tbl_customers cs = new tbl_customers();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from tbl_customers where Customer_email=@email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", Customer_email);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (VerifyHash(Customer_password, reader["customer_password"].ToString()))
                        {
                            cs.Customer_id = Convert.ToInt32(reader["customer_id"]);
                            cs.Customer_email = reader["customer_email"].ToString();
                            cs.Customer_name = reader["customer_name"].ToString();
                            cs.Customer_password = reader["customer_password"].ToString();

                        }
                        return cs;
                    }

                    reader.Close();
                }

                conn.Close();

            }
            return cs;
        }
        public tbl_admin loginAdmin(string Email, string Password)
        {
            tbl_admin cs = new tbl_admin();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from tbl_admin where admin_email=@email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", Email);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Password == reader["admin_password"].ToString())
                        {
                            cs.Admin_id = Convert.ToInt32(reader["admin_id"]);
                            cs.Admin_name = reader["admin_name"].ToString();
                            cs.Admin_email = reader["admin_email"].ToString();
                            cs.Admin_password = reader["admin_password"].ToString();
                        }
                        return cs;
                    }

                    reader.Close();
                }

                conn.Close();

            }
            return cs;
        }
    
    }
}

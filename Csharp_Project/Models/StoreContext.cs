using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
                string str = "SELECT category_id, category_name, category_desc FROM tbl_category_product";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT product_id,product_name, category_id,brand_id,product_price,product_image,product_status FROM `tbl_product` WHERE product_id = @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
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
            using (MySqlConnection conn = GetConnection())
            {
                string str = "INSERT INTO `tbl_product`(`product_name`, `product_slug`, `category_id`, `brand_id`, `product_desc`, `product_content`, `product_price`, `product_image`, `product_status`, `created_at`, `updated_at`) VALUES (@name, @slug, @category, @brand, @desc, @content, @price, @image, @status, @created, @updated)";
                Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
                string temp = product_name.Normalize(NormalizationForm.FormD);
                string str2 = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
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
                            case "Đã thanh toán":
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
                        if (stt.CompareTo("") != 0)
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
        public int UpdateOrder(long order_id, string order_status)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "UPDATE `tbl_order` SET `order_status`= @status,`updated_at`= @updated WHERE `order_id`= @id";
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                MySqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.CommandText = str;
                    cmd.Parameters.AddWithValue("id", order_id);
                    cmd.Parameters.AddWithValue("status", order_status);
                    cmd.Parameters.AddWithValue("updated", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    if (order_status == "Đã hủy đơn")
                    {
                        cmd.Parameters.Clear();
                        string str1 = "SELECT `product_id`, `product_sales_quantity` FROM `tbl_order_details` WHERE order_id = @order_id";
                        string str2 = "UPDATE `tbl_product` SET `product_status`= product_status + @product_status,`updated_at`= now() WHERE product_id = @product_id";
                        cmd.CommandText = str1;
                        cmd.Parameters.AddWithValue("order_id", order_id);
                        List<object> list = new List<object>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new
                                {
                                    product_id = Convert.ToInt32(reader["product_id"]),
                                    product_sales_quantity = Convert.ToInt32(reader["product_sales_quantity"]),
                                });
                            }
                            reader.Close();
                        }
                        cmd.CommandText = str2;
                        foreach (var item in list)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("product_id", item.GetType().GetProperty("product_id").GetValue(item, null));
                            cmd.Parameters.AddWithValue("product_status", item.GetType().GetProperty("product_sales_quantity").GetValue(item, null));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    trans.Rollback();
                    return 0;
                }
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
                var str = "insert into tbl_customers values(NULL,@name,@email,@password,@phone,@diachi,NULL,NULL)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                var hash = Hash(us.Customer_password);
                cmd.Parameters.AddWithValue("name", us.Customer_name);
                cmd.Parameters.AddWithValue("email", us.Customer_email);
                cmd.Parameters.AddWithValue("password", hash);
                cmd.Parameters.AddWithValue("phone", us.Customer_phone);
                cmd.Parameters.AddWithValue("diachi", us.Customer_address);
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
                            cs.Customer_address = reader["customer_address"].ToString();

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
        public List<object> GetTbl_Category_Products_Home()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT category_id, category_name, category_desc FROM tbl_category_product";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            id = Convert.ToInt32(reader["category_id"]),
                            name = reader["category_name"].ToString(),
                            image = reader["category_desc"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> GetTbl_ProductById_buying(int id)
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT product_id,product_name,product_desc,product_price,product_image,product_status FROM `tbl_product` WHERE product_id = @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        list.Add(new
                        {
                            id = Convert.ToInt32(reader["product_id"]),
                            name = reader["product_name"].ToString(),
                            description = reader["product_desc"].ToString(),
                            image = reader["product_image"].ToString(),
                            cost = reader["product_price"].ToString(),
                            available = Convert.ToInt32(reader["product_status"]),
                            mini_image = reader["product_image"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int InsertCart(int customer_id, int product_id, int cart_quantity, string cart_price)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT cart_id FROM `cart` WHERE customer_id = @cidc AND product_id = @pidc";
                string str1 = "INSERT INTO `cart`(`customer_id`, `product_id`, `cart_quantity`, `cart_price`) VALUES (@cid, @pid, @quantity, @price)";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cidc", customer_id);
                cmd.Parameters.AddWithValue("pidc", product_id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == false)
                    {
                        reader.Close();
                        cmd = new MySqlCommand(str1, conn);
                        cmd.Parameters.AddWithValue("cid", customer_id);
                        cmd.Parameters.AddWithValue("pid", product_id);
                        cmd.Parameters.AddWithValue("quantity", cart_quantity);
                        cmd.Parameters.AddWithValue("price", cart_price);
                        return cmd.ExecuteNonQuery();
                    }
                    return -1;
                }
            }
        }
        public List<object> Getcart(int id)
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT cart_id, p.product_image, p.product_name, cart_price, cart_quantity, p.product_id, product_price FROM `cart` c JOIN tbl_product p on p.product_id = c.product_id WHERE customer_id = @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int sl = Convert.ToInt32(reader["cart_quantity"]);
                        int sum = Convert.ToInt32(reader["cart_price"].ToString());
                        list.Add(new
                        {
                            cart_id = Convert.ToInt32(reader["cart_id"]),
                            image = reader["product_image"].ToString(),
                            product_name = reader["product_name"].ToString(),
                            cost = sum,
                            product_sales_quantity = sl,
                            product_price = reader["product_price"].ToString(),
                            product_id = Convert.ToInt32(reader["product_id"]),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int DeleteCart(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "DELETE FROM `cart` WHERE `cart_id` = @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteAllCart(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "DELETE FROM `cart` WHERE `customer_id` = @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                return cmd.ExecuteNonQuery();
            }
        }
        public List<object> GetTbl_voucher()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT `voucher_id`, `voucher_name`, voucher_sale FROM `tbl_voucher` WHERE voucher_quantity > 0 and voucher_date > now()";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            id = Convert.ToInt32(reader["voucher_id"]),
                            name = reader["voucher_name"].ToString(),
                            sale = Convert.ToInt32(reader["voucher_sale"]),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int ThemDonHang(int customer_id, int voucher_id, string order_total, string order_address, List<tbl_order_details> list)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "INSERT INTO `tbl_order`(`customer_id`, `voucher_id`, `order_total`, `order_status`, `order_address`, `created_at`) VALUES (@customer_id, @voucher_id, @order_total, @order_status, @order_address, now())";
                string str2 = "INSERT INTO `tbl_order_details`(`order_id`, `product_id`, `product_name`, `product_price`, `product_sales_quantity`, created_at) VALUES (@order_id, @product_id, @product_name, @product_price, @product_sales_quantity, now())";
                string str3 = "UPDATE `tbl_product` SET `product_status`= product_status - @product_status,`updated_at`= now() WHERE product_id = @product_id";
                string str4 = "DELETE FROM `cart` WHERE `customer_id` = @customer_id";
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                MySqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    cmd.CommandText = str;
                    cmd.Parameters.AddWithValue("customer_id", customer_id);
                    if (voucher_id == 0)
                    {
                        cmd.Parameters.AddWithValue("voucher_id", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("voucher_id", voucher_id);
                    }
                    cmd.Parameters.AddWithValue("order_total", order_total);
                    cmd.Parameters.AddWithValue("order_status", "Đang giao");
                    cmd.Parameters.AddWithValue("order_address", order_address);
                    cmd.ExecuteNonQuery();
                    long order_id = cmd.LastInsertedId;
                    foreach (var item in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = str2;
                        cmd.Parameters.AddWithValue("order_id", order_id);
                        cmd.Parameters.AddWithValue("product_id", item.Product_id);
                        cmd.Parameters.AddWithValue("product_name", item.Product_name);
                        cmd.Parameters.AddWithValue("product_price", item.Product_price);
                        cmd.Parameters.AddWithValue("product_sales_quantity", item.Product_sales_quantity);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = str3;
                        cmd.Parameters.AddWithValue("product_id", item.Product_id);
                        cmd.Parameters.AddWithValue("product_status", item.Product_sales_quantity);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                    cmd.CommandText = str4;
                    cmd.Parameters.AddWithValue("customer_id", customer_id);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    trans.Rollback();
                    return 0;
                }
            }
        }
        public List<List_totalcart> GetTbl_OrdersByCusId(int customer_id)
        {
            List<List_totalcart> list1 = new List<List_totalcart>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT `order_id`, `order_total`, `order_status` FROM `tbl_order` WHERE customer_id = @customer_id";
                string str2 = "SELECT p.product_name, odt.product_sales_quantity, odt.product_price, product_image, category_name FROM `tbl_order_details` odt JOIN tbl_product p on odt.product_id = p.product_id join tbl_category_product cp on cp.category_id = p.category_id WHERE order_id = @order_id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("customer_id", customer_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<object> list2 = new List<object>();
                        list1.Add(new List_totalcart
                        (
                            Convert.ToInt64(reader["order_id"]),
                            reader["order_total"].ToString(),
                            reader["order_status"].ToString(),
                            list2
                        ));
                    }
                    reader.Close();
                }
                foreach (var item in list1)
                {
                    List<object> list3 = new List<object>();
                    cmd.Parameters.Clear();
                    cmd.CommandText = str2;
                    cmd.Parameters.AddWithValue("order_id", item.Order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list3.Add(new
                            {
                                product_name = reader["product_name"].ToString(),
                                product_sales_quantity = Convert.ToInt32(reader["product_sales_quantity"]),
                                product_price = reader["product_price"].ToString(),
                                product_image = reader["product_image"].ToString(),
                                category_name = reader["category_name"].ToString(),
                            });
                        }
                        reader.Close();
                    }
                    item.List = list3;
                }
                conn.Close();
            }
            return list1;
        }
        public List_totalcart GetTbl_OrdersById(long order_id)
        {
            List_totalcart list1 = new List_totalcart();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT `order_id`, `order_total`, `order_status` FROM `tbl_order` WHERE order_id = @order_id";
                string str2 = "SELECT p.product_name, odt.product_sales_quantity, odt.product_price, product_image, category_name FROM `tbl_order_details` odt JOIN tbl_product p on odt.product_id = p.product_id join tbl_category_product cp on cp.category_id = p.category_id WHERE order_id = @order_id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("order_id", order_id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        List<object> list2 = new List<object>();
                        list1 = new List_totalcart
                        (
                            Convert.ToInt64(reader["order_id"]),
                            reader["order_total"].ToString(),
                            reader["order_status"].ToString(),
                            list2
                        );
                    }
                    reader.Close();
                }
                List<object> list3 = new List<object>();
                cmd.Parameters.Clear();
                cmd.CommandText = str2;
                cmd.Parameters.AddWithValue("order_id", list1.Order_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list3.Add(new
                        {
                            product_name = reader["product_name"].ToString(),
                            product_sales_quantity = Convert.ToInt32(reader["product_sales_quantity"]),
                            product_price = reader["product_price"].ToString(),
                            product_image = reader["product_image"].ToString(),
                            category_name = reader["category_name"].ToString(),
                        });
                    }
                    reader.Close();
                }
                list1.List = list3;
                conn.Close();
            }
            return list1;
        }
        public List<object> GetTbl_ProductsByCategoryid(int category_id)
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT `product_id`, `product_name`, `product_price`, `product_image` FROM `tbl_product` WHERE category_id = @category_id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("category_id", category_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            product_id = Convert.ToInt32(reader["product_id"]),
                            product_name = reader["product_name"].ToString(),
                            product_price = reader["product_price"].ToString(),
                            product_image = reader["product_image"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> GetTbl_ProductsByKeyword(string keyword)
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT `product_id`, `product_name`, `product_price`, `product_image` FROM `tbl_product` WHERE product_name like @keyword";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("keyword", "%" + keyword + "%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            product_id = Convert.ToInt32(reader["product_id"]),
                            product_name = reader["product_name"].ToString(),
                            product_price = reader["product_price"].ToString(),
                            product_image = reader["product_image"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> GetTbl_Voucher()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT voucher_id,voucher_code,voucher_name,voucher_quantity,voucher_date,voucher_sale FROM `tbl_voucher` ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["voucher_quantity"]) != 0 && Convert.ToDateTime(reader["voucher_date"]).ToString("dd/MM/yyyy").CompareTo(DateTime.Now.ToString("dd/MM/yyyy")) >= 0)
                        {
                            list.Add(new
                            {
                                id = Convert.ToInt32(reader["voucher_id"]),
                                time = Convert.ToDateTime(reader["voucher_date"]).ToString("dd/MM/yyyy"),
                                code = reader["voucher_code"].ToString(),
                                name = reader["voucher_name"].ToString(),
                                quantity = int.Parse(reader["voucher_quantity"].ToString()),
                                sale = int.Parse(reader["voucher_sale"].ToString()),
                                state = "Còn giá trị",
                                status = "active",
                            });
                        }
                        else
                        {
                            list.Add(new
                            {
                                id = Convert.ToInt32(reader["voucher_id"]),
                                time = Convert.ToDateTime(reader["voucher_date"]).ToString("dd/MM/yyyy"),
                                code = reader["voucher_code"].ToString(),
                                name = reader["voucher_name"].ToString(),
                                quantity = int.Parse(reader["voucher_quantity"].ToString()),
                                sale = int.Parse(reader["voucher_sale"].ToString()),
                                state = "Hết giá trị",
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


        public object GetTbl_VoucherById(int id)
        {
            object p = new object();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT voucher_id,voucher_code,voucher_name,voucher_quantity,voucher_date,voucher_sale FROM `tbl_voucher` where voucher_id=@id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new
                        {
                            voucher_id = Convert.ToInt32(reader["voucher_id"]),
                            voucher_name = reader["voucher_name"].ToString(),
                            voucher_code = reader["voucher_code"].ToString(),
                            voucher_quantity = Convert.ToInt32(reader["voucher_quantity"]),
                            voucher_date = Convert.ToDateTime(reader["voucher_date"]).ToString("yyyy-MM-dd"),
                            voucher_sale = Convert.ToInt32(reader["voucher_sale"]),

                        };
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return p;
        }
        public int InsertVoucher(string voucher_name, string voucher_code, int voucher_quantity, string voucher_date, int voucher_sale)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "INSERT INTO `tbl_voucher`(`voucher_code`, `voucher_name`, `voucher_quantity`, `voucher_date`, `voucher_sale`) VALUES (@code,@name,@sl,@date,@sale)";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("name", voucher_name);
                cmd.Parameters.AddWithValue("code", voucher_code);
                cmd.Parameters.AddWithValue("sl", voucher_quantity);
                cmd.Parameters.AddWithValue("date", voucher_date);
                cmd.Parameters.AddWithValue("sale", voucher_sale);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateVoucher(int voucher_id, string voucher_name, string voucher_code, int voucher_quantity, string voucher_date, int voucher_sale)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "UPDATE `tbl_voucher` SET `voucher_name`= @name,`voucher_code`= @code,`voucher_quantity`= @sl, `voucher_date`=  @date,`voucher_sale`= @sale  WHERE `voucher_id`= @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", voucher_id);
                cmd.Parameters.AddWithValue("name", voucher_name);
                cmd.Parameters.AddWithValue("code", voucher_code);
                cmd.Parameters.AddWithValue("sl", voucher_quantity);
                cmd.Parameters.AddWithValue("date", voucher_date);
                cmd.Parameters.AddWithValue("sale", voucher_sale);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteVoucher(int voucher_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "DELETE FROM `tbl_voucher` WHERE `voucher_id`= @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", voucher_id);
                return cmd.ExecuteNonQuery();
            }
        }
        //
        public List<object> GetTbl_Products_ncc()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT brand_id, created_at, brand_name,brand_desc, brand_status   FROM `tbl_brand` ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["brand_status"]) != 0)
                        {
                            list.Add(new
                            {
                                id = Convert.ToInt32(reader["brand_id"]),
                                time = Convert.ToDateTime(reader["created_at"]).ToString("dd/MM/yyyy"),
                                name = reader["brand_name"].ToString(),
                                desc = reader["brand_desc"].ToString(),
                                state = "Hoạt động",
                                status = "active",
                            });
                        }
                        else
                        {
                            list.Add(new
                            {
                                id = Convert.ToInt32(reader["brand_id"]),
                                time = Convert.ToDateTime(reader["created_at"]).ToString("dd/MM/yyyy"),

                                name = reader["brand_name"].ToString(),
                                desc = reader["brand_desc"].ToString(),
                                state = "Tạm ngưng",
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
        public object GetTbl_brandById(int id)
        {
            object p = new object();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT brand_id,brand_name,brand_desc,brand_status,brand_image FROM tbl_brand where brand_id=@id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new
                        {
                            brand_id = Convert.ToInt32(reader["brand_id"]),
                            brand_name = reader["brand_name"].ToString(),
                            brand_desc = reader["brand_desc"].ToString(),
                            brand_status = Convert.ToInt32(reader["brand_status"]),
                            brand_image = reader["brand_image"].ToString(),
                        };
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return p;
        }
        public object GetTbl_brandByProId(int id)
        {
            object p = new object();
            using (MySqlConnection conn = GetConnection())
            {
                string str = "SELECT tbl_brand.brand_id,brand_name,brand_desc,brand_status,brand_image FROM `tbl_product` JOIN tbl_brand on tbl_product.brand_id = tbl_brand.brand_id WHERE product_id = @product_id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("product_id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new
                        {
                            brand_id = Convert.ToInt32(reader["brand_id"]),
                            brand_name = reader["brand_name"].ToString(),
                            brand_desc = reader["brand_desc"].ToString(),
                            brand_status = Convert.ToInt32(reader["brand_status"]),
                            brand_image = reader["brand_image"].ToString(),
                        };
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return p;
        }
        public int InsertNhacc(string brand_name, string brand_desc, int brand_status, string brand_image)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "INSERT INTO `tbl_brand` (`brand_name`,`brand_desc`, `brand_status`, `brand_image`,`created_at`,`updated_at`) VALUES (@name,@desc, @status, @image,@created, null)";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("name", brand_name);
                cmd.Parameters.AddWithValue("desc", brand_desc);
                cmd.Parameters.AddWithValue("status", brand_status);
                cmd.Parameters.AddWithValue("image", brand_image);

                cmd.Parameters.AddWithValue("created", DateTime.Now);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateNhacc(int brand_id, string brand_name, string brand_desc, int brand_status, string brand_image)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "UPDATE `tbl_brand` SET `brand_name`= @name,`brand_desc`= @desc,`brand_status`= @status,`brand_image`= @image,`updated_at`= @updated WHERE `brand_id`= @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", brand_id);
                cmd.Parameters.AddWithValue("name", brand_name);
                cmd.Parameters.AddWithValue("desc", brand_desc);
                cmd.Parameters.AddWithValue("status", brand_status);
                cmd.Parameters.AddWithValue("image", brand_image);
                cmd.Parameters.AddWithValue("updated", DateTime.Now);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteNhacc(int brand_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "DELETE FROM `tbl_brand` WHERE `brand_id`= @id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", brand_id);
                return cmd.ExecuteNonQuery();
            }
        }
        //
        public int[] GetListDS(int nam)
        {
            List<DSThongKe> list = new List<DSThongKe>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT MONTH(created_at) AS THANG, COUNT(*) as SL FROM tbl_order WHERE YEAR(created_at) = @nam GROUP BY MONTH(created_at)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("nam", nam);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DSThongKe()
                        {
                            THANG = int.Parse(reader["THANG"].ToString()),
                            SOLUONGBANRA = int.Parse(reader["SL"].ToString())
                        });
                    }
                    reader.Close();
                }
                conn.Close();

            }
            int[] ds = new int[12];
            for (int i = 0; i < list.Count; i++)
            {
                ds[list[i].THANG - 1] = list[i].SOLUONGBANRA;
            }
            return ds;
        }

        public tbl_customers GetCustomersById(int id)
        {
            tbl_customers cs = new tbl_customers();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT customer_id,customer_name,customer_email,customer_phone,customer_address FROM `tbl_customers` where customer_id=@id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cs.Customer_id = int.Parse(reader["customer_id"].ToString());
                        cs.Customer_name = reader["customer_name"].ToString();
                        cs.Customer_email = reader["customer_email"].ToString();
                        cs.Customer_phone = reader["customer_phone"].ToString();
                        cs.Customer_address = reader["customer_address"].ToString();
                    }
                    reader.Close();
                }
                conn.Close();

            }
            return cs;
        }
        //
        public int UpdateCustomer(int customer_id, string customer_name, string customer_phone, string customer_address)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string str = "UPDATE `tbl_customers` SET `customer_name`= @customer_name, `customer_phone`= @customer_phone,`customer_address`= @customer_address WHERE customer_id = @customer_id";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("customer_id", customer_id);
                cmd.Parameters.AddWithValue("customer_name", customer_name);
                cmd.Parameters.AddWithValue("customer_phone", customer_phone);
                cmd.Parameters.AddWithValue("customer_address", customer_address);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}

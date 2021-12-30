using Csharp_Project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Csharp_Project.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }//biết thành viên 
        public StoreContext() { }
        public StoreContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
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
        public bool VerifyHash( string input, string hash)
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
       
        public tbl_customers loginUser(string Customer_email,string Customer_password)
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
                        if(VerifyHash(Customer_password, reader["customer_password"].ToString()))
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
        public tbl_shipping loginShipping(string Email, string Password)
        {
            tbl_shipping cs = new tbl_shipping();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from tbl_shipping where shipping_email=@email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", Email);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Password == reader["shipping_password"].ToString())
                        {
                            cs.Shipping_id = Convert.ToInt32(reader["shipping_id"]);
                            cs.Shipping_name = reader["shipping_name"].ToString();
                            cs.Shipping_email = reader["shipping_email"].ToString();
                            cs.Shipping_password = reader["shipping_password"].ToString();

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
        
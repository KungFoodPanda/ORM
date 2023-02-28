using ORM.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Data
{
    public class ProductData
    {
        public List<Product> GetAll()
        {
            var productList = new List<Product>();
            SqlConnection con = Database.GetConnection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= con;
                cmd.CommandText = "Select * from Product";
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read()) 
                    {
                        Product product = new Product((int)reader.GetValue(0), (string)reader.GetValue(1), (decimal)reader.GetValue(2), (int)reader.GetValue(3));
                        productList.Add(product);
                    }
                }
            }
            con.Close();
            return productList;
        }

        public void Add(Product product)
        {
            var con = Database.GetConnection();
            using (con)
            {
                con.Open();
                var command = new SqlCommand("Insert intro Product(name,price,stock) values (@name,@price,@stock);",con);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(int id)
        {
            var con = Database.GetConnection();
            using (con) 
            {
                con.Open();
                var command = new SqlCommand("Delete from Product where id=@id", con);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}

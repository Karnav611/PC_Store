using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PcStoreManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string AddProduct(Product prod)
        {
            string result = "";
            try
            {

                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=socdb;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();

                string Query = @"INSERT INTO products (pid, name, brand, price, warranty, description)  
                                               Values(@ProdId, @Name, @Brand, @Price, @Warranty, @Description)";

                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProdId", prod.ProdId);
                cmd.Parameters.AddWithValue("@Name", prod.Name);
                cmd.Parameters.AddWithValue("@Brand", prod.Brand);
                cmd.Parameters.AddWithValue("@Price", prod.Price);
                cmd.Parameters.AddWithValue("@Warranty", prod.Warranty);
                cmd.Parameters.AddWithValue("@Description", prod.Description);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = "Record Added Successfully !";
            }
            catch (FaultException fex)
            {
                result = "Error";
            }

            return result;
        }

        public DataSet GetProduct()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=socdb;Integrated Security=True;");
                string Query = "SELECT * FROM products";

                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.Fill(ds);
            }
            catch (FaultException fex)
            {
                throw new FaultException<string>("Error: " + fex);
            }

            return ds;
        }

        public string DeleteProduct(Product prod)
        {
            string result = "";
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=socdb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            string Query = "DELETE FROM products Where pid = @ProdId";
            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@ProdId", prod.ProdId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            result = "Record Deleted Successfully!";
            return result;
        }

        public DataSet SearchProduct(Product prod)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=socdb;Integrated Security=True;");
                string Query = "SELECT * FROM products WHERE pid = @ProdId";

                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.SelectCommand.Parameters.AddWithValue("@ProdId", prod.ProdId);
                sda.Fill(ds);
            }
            catch (FaultException fex)
            {
                throw new FaultException<string>("Error:  " + fex);
            }
            return ds;
        }

        public string UpdateProduct(Product prod)
        {
            string result = "";
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=socdb;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand();

            string Query = "UPDATE products SET name=@Name, price=@Price, brand=@Brand, warranty=@Warranty, description=@Description WHERE pid=@ProdId";

            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Name", prod.Name);
            cmd.Parameters.AddWithValue("@Brand", prod.Brand);
            cmd.Parameters.AddWithValue("@Price", prod.Price);
            cmd.Parameters.AddWithValue("@Warranty", prod.Warranty);
            cmd.Parameters.AddWithValue("@Description", prod.Description);
            con.Open();
            cmd.ExecuteNonQuery();
            result = "Record Updated Successfully !";
            con.Close();    

            return result;
        }

    }
}

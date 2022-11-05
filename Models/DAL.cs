using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EMedicine.Models
{
    public class DAL
    {
        public Response register(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_register", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FirstName", users.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", users.LastName);
            sqlCommand.Parameters.AddWithValue("@Password", users.Password);
            sqlCommand.Parameters.AddWithValue("@Email", users.Email);
            sqlCommand.Parameters.AddWithValue("@Fund", 0);
            sqlCommand.Parameters.AddWithValue("@Type", "Users");
            sqlCommand.Parameters.AddWithValue("@Type", "Pending");
            
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User registred successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User registration failed";
            }
            return response;
        }

        public Response Login (Users users, SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            adapter.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode = 200;
                response.StatusMessage = "User registred successfully";
                response.Users = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User registration failed";
                response.Users = null;
            }
            return response;
        }

        public Response ViewUser(Users users, SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("p_viewUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
                user.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                response.StatusCode = 200;
                response.StatusMessage = "User exists";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User does not exist";
                response.User = null;
            }
            return response;
        }

        public Response UpdateProfile(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_register", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FirstName", users.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", users.LastName);
            sqlCommand.Parameters.AddWithValue("@Password", users.Password);
            sqlCommand.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Record Updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some error failed. Try again";
            }
            return response;
        }

        public Response AddToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_register", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserId", cart.UserId);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@Discount", cart.Discount);
            sqlCommand.Parameters.AddWithValue("@Quantity", cart.Quantity);
            sqlCommand.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            sqlCommand.Parameters.AddWithValue("@MedicineID", cart.MedicinesId);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Item added to cart";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item could not added. Try again";
            }
            return response;
        }

        public Response PlaceOrder(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_PlaceOrder", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", users.ID);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order has been placed successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order could not be placed";
            }
            return response;
        }

        public Response OrderList(Users users, SqlConnection connection)
        {
            Response response = new Response();
            List<Orders> listOrder = new List<Orders>();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand.CommandType= CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            adapter.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count>0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                }
                if(listOrder.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details fetched";
                    response.ListOrders = listOrder;
                } 
                else
                {
                response.StatusCode = 100;
                response.StatusMessage = "Order details not availables";        
                }
              response.ListOrders= null;
            }
            return response;
        }

        public Response AddUpdateMedicine (Medicines medicines, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_AddUpdateMedicine", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Name", medicines.Name);
            sqlCommand.Parameters.AddWithValue("@Manufacturer", medicines.Manufacturer);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", medicines.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@Discount", medicines.Discount);
            sqlCommand.Parameters.AddWithValue("@Quantity", medicines.Quantity);
            sqlCommand.Parameters.AddWithValue("@TotalPrice", medicines.TotalPrice);
            sqlCommand.Parameters.AddWithValue("@ExpDate", medicines.ExpDate);
            sqlCommand.Parameters.AddWithValue("@Status", medicines.Status);
            sqlCommand.Parameters.AddWithValue("@ImageURL", medicines.ImageUrl);
            sqlCommand.Parameters.AddWithValue("@Type", medicines.Type);

            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Medicine inserted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Medicine failed. Try again";
            }
            return response;
        }
    }
}

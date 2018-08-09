using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
public class CustomerManager
{
    public int InsertCustomer(Customer cust, SqlConnection connection)
    {
        //Create the SQL Query for inserting a product
        string sqlQuery = String.Format("Insert into Customer (Name, Email) Values('{0}', '{1}');"
        + "Select @@Identity", cust.Name,cust.Email);

        int customerID = 0;
        //Create a Command object
        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        {
            //Execute the command to SQL Server and return the newly created ID
            customerID = Convert.ToInt32((decimal)command.ExecuteScalar());

            //Close and dispose
        }
        // Set return value
        return customerID;
    }

    public Customer GetCustomerById(int customerId, SqlConnection connection)
    {
        Customer result = null;

        //Create the SQL Query for returning a product category based on its primary key
        string sqlQuery = String.Format("select * from Table where Id='{0}'", customerId);

        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        {
            using (SqlDataReader dataReader = command.ExecuteReader())
            {

                //load into the result object the returned row from the database
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result = new Customer
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Name = dataReader["Name"].ToString(),
                            Email = dataReader["Description"].ToString(),
                            
                        };
                    }
                }
            }
        }

        return result;
    }

    public bool DeleteCustomer(int custID, SqlConnection connection)
    {
        bool result = false;

        //Create the SQL Query for deleting a product
        string sqlQuery = string.Format("delete from Customer where Id = {0}", custID);

        //Create a Command object
        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        {
            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0) result = true;
        }
        return result;
    }
}

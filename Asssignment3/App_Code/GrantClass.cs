using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //these libraries must be added
using System.Data.SqlClient; //sql server tools
using System.Configuration; //to talk to the config file



/// <summary>
/// Summary description for GrantClass
/// </summary>
public class GrantClass
{
    private SqlConnection connect;
   
    public GrantClass()
    {
        //get the connection string

        string connectString =

            ConfigurationManager.ConnectionStrings["GrantReviewConnection"].ToString();

        //initilize the connection object

        connect = new SqlConnection(connectString);
    }
    public DataTable Getgrants(int GrantKey)

    {

        //declare a new data table to store the results

        DataTable table = new DataTable();

        //sql statement

        string sql = "Select GrantReviewDate as [Date], "
                + "GrantRequestExplanation as Explanation, "
                + "GrantAllocationAmount as Amount, "
                + "GrantRequestStatus as [Status] "
                + "From GrantRequest r "
                + "inner join GrantReview gr "
                + "on r.GrantRequestKey = gr.GrantRequestKey "
                + " Where GrantTypeKey = @GrantTypeKey";

        //the command object passes the sql through the connection

        SqlCommand cmd = new SqlCommand(sql, connect);

        //the parameter replaces the sql variable with a value

        cmd.Parameters.AddWithValue("@GrantTypeKey", GrantKey);

        //declare a reader to stream the results

        SqlDataReader reader = null;

        //open the connection

        connect.Open();

        //execute the command and reader

        reader = cmd.ExecuteReader();

        //load the results into the table 

        table.Load(reader);

        //close stuff

        reader.Close();

        connect.Close();

        return table;

    }



    public DataTable GetGrants()

    {

        DataTable table = new DataTable();

        string sql = "Select GrantTypeKey, GrantTypeName from GrantType";

        SqlCommand cmd = new SqlCommand(sql, connect);

        SqlDataReader reader = null;

        connect.Open();

        reader = cmd.ExecuteReader();

        table.Load(reader);

        reader.Close();

        connect.Close();

        return table;

    }

}
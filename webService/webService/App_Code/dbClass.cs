using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;


public interface IDbAction
{
    /// <summary>
    /// Initiates values into an object
    /// </summary>
    /// <returns></returns>
    int Init();
    int AddNew();
    int Update();
    int Delete();
}

public static class DbQ
{
    static string dbName = "wsDatabase.accdb";

    static string dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + dbName);
    
   // static string provider = "Microsoft.Jet.OLEDB.4.0";
    static string provider = "Microsoft.ACE.OLEDB.12.0";

    //Connection string for Access DB
    static string connectionString = string.Format("Data Source={0};Provider={1}", dbPath, provider);


    /// <summary>
    /// Executes a non query (everything but SELECT)
    /// </summary>
    /// <param name="QueryString">The query string</param>
    /// <returns>False if it didn't work, true if it did</returns>
    public static int ExecuteNonQuery(String QueryString)
    {
        OleDbConnection con = new OleDbConnection(connectionString);

        int retVal;
        con.Open();
        OleDbCommand cmd = new OleDbCommand(QueryString, con);
        try
        {
            retVal = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            return -1;
        }
        finally
        {
            con.Close();

        }
        return retVal;
    }
   
    /// <summary>
    /// Executes a SELECT query
    /// </summary>
    /// <param name="QueryString">The query string</param>
    /// <returns>The data that was given</returns>
    public static DataSet ExecuteQuery(String QueryString)
    {

        OleDbConnection con = new OleDbConnection(connectionString);
        //Establishes a connection
        con.Open();
        //Creates a DB command using the Query and the connection
        OleDbCommand cmd = new OleDbCommand(QueryString, con);
        //Creates a DB Adapter
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //Creates a new DataSet for the results
        DataSet ds = new DataSet();
        //Fills the dataset with the results
        da.Fill(ds, "tbl");
        //Closes the connection
        con.Close();

        return ds;
    }
}
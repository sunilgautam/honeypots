using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ConnectionManager
/// </summary>
public class ConnectionManager
{
    public static SqlConnection con;

    public ConnectionManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static SqlConnection GetConnection()
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        con = new SqlConnection(ConnectionString);
        con.Open();
        return con;
    }

    public static void CloseConnection()
    {
        con.Close();
    }
}


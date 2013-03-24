using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class h_admin_performance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setPageList();
    }

    public void setPageList()
    {
        DataTable dTablePageList = new DataTable();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["honeypots.app.con"].ConnectionString);

        SqlCommand cmd = new SqlCommand("GET_PAGE_PERFORMANCE", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PARA", SqlDbType.VarChar).Value = "LIST";
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        ad.Fill(dTablePageList);
        rptPageList.DataSource = dTablePageList;
        rptPageList.DataBind();
    }
}
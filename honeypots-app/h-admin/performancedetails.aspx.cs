using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class h_admin_performancedetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlPagePerformance.Visible = false;
            pnlNoRecord.Visible = true;

            if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
            {
                litPage.Text = Request.QueryString["page"];
                hdnPage.Value = Request.QueryString["page"];
            }
            else
            {
                Response.Redirect("~/h-admin/performance.aspx");
            }
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        DateTime dtFromTest, dtToTest;
        if (hdnPage.Value == "")
        {
            Response.Redirect("~/h-admin/performance.aspx");
        }
        else if (txtDateFrom.Text.Trim() == "" || txtDateTo.Text.Trim() == "")
        {
            pnlPagePerformance.Visible = false;
            pnlNoRecord.Visible = true;
        }
        else if (DateTime.TryParse(txtDateFrom.Text.Trim(), out dtFromTest) && DateTime.TryParse(txtDateTo.Text.Trim(), out dtToTest))
        {
            //litPage.Text = string.Format("USER HITS FOR {0} (PAGES)", dtTest.ToString("dd-MMM-yyyy"));
            setPagePerformance(dtFromTest, dtToTest, hdnPage.Value);
            pnlPagePerformance.Visible = true;
            pnlNoRecord.Visible = false;
        }
        else
        {
            pnlPagePerformance.Visible = false;
            pnlNoRecord.Visible = true;
        }
    }

    public void setPagePerformance(DateTime from, DateTime to, string page)
    {
        DataTable dTablePageList = new DataTable();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["honeypots.app.con"].ConnectionString);

        SqlCommand cmd = new SqlCommand("GET_PAGE_PERFORMANCE", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PARA", SqlDbType.VarChar).Value = "PER";
        cmd.Parameters.Add("@LIMIT_FROM_DATE", SqlDbType.Date).Value = from;
        cmd.Parameters.Add("@LIMIT_FROM_TO", SqlDbType.Date).Value = to;
        cmd.Parameters.Add("@PAGE", SqlDbType.VarChar).Value = page;
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        ad.Fill(dTablePageList);
        rptPagePerformance.DataSource = dTablePageList;
        rptPagePerformance.DataBind();
    }
}
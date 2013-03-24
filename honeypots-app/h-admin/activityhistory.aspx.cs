using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class h_admin_activityhistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlPageHits.Visible = false;
            pnlAllHits.Visible = false;
            pnlNoRecord.Visible = true;
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        DateTime dtTest;
        if (txtDate.Text.Trim() == "")
        {
            pnlPageHits.Visible = false;
            pnlAllHits.Visible = false;
            pnlNoRecord.Visible = true;
        }
        else if (DateTime.TryParse(txtDate.Text.Trim(), out dtTest))
        {
            litPage.Text = string.Format("USER HITS FOR {0} (PAGES)", dtTest.ToString("dd-MMM-yyyy"));
            litAll.Text = string.Format("USER HITS FOR {0} (ALL RESOURCES)", dtTest.ToString("dd-MMM-yyyy"));
            setUserHits(dtTest);
            pnlPageHits.Visible = true;
            pnlAllHits.Visible = true;
            pnlNoRecord.Visible = false;
        }
        else
        {
            pnlPageHits.Visible = false;
            pnlAllHits.Visible = false;
            pnlNoRecord.Visible = true;
        }
    }

    public void setUserHits(DateTime date)
    {
        DataTable dTablePage = new DataTable();
        DataTable dTableAll = new DataTable();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["honeypots.app.con"].ConnectionString);
        
        SqlCommand cmd = new SqlCommand("GET_USER_ACTIVITY", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PARA", SqlDbType.VarChar).Value = "D";
        cmd.Parameters.Add("@RESOURCE_TYPE", SqlDbType.VarChar).Value = "PAGE";
        cmd.Parameters.Add("@DT", SqlDbType.SmallDateTime).Value = date;
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        ad.Fill(dTablePage);
        Chart_Pages.DataSource = dTablePage;
        Chart_Pages.DataBind();

        cmd = new SqlCommand("GET_USER_ACTIVITY", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@PARA", SqlDbType.VarChar).Value = "D";
        cmd.Parameters.Add("@RESOURCE_TYPE", SqlDbType.VarChar).Value = "ALL";
        cmd.Parameters.Add("@DT", SqlDbType.SmallDateTime).Value = date;
        ad = new SqlDataAdapter(cmd);
        ad.Fill(dTableAll);
        Chart_All.DataSource = dTableAll;
        Chart_All.DataBind();
    }

    protected void Chart_Pages_Customize(object sender, EventArgs e)
    {
        if (Chart_Pages.Series[0].ChartType != SeriesChartType.Point)
        {
            foreach (Series series in Chart_Pages.Series)
            {
                foreach (DataPoint point in series.Points)
                {
                    if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                    {
                        point.LegendText = point.AxisLabel;
                        point.AxisLabel = string.Empty;
                        point.Label = string.Empty;
                    }
                }
            }
        }
    }

    protected void Chart_All_Customize(object sender, EventArgs e)
    {
        if (Chart_All.Series[0].ChartType != SeriesChartType.Point)
        {
            foreach (Series series in Chart_All.Series)
            {
                foreach (DataPoint point in series.Points)
                {
                    if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                    {
                        point.LegendText = point.AxisLabel;
                        point.AxisLabel = string.Empty;
                        point.Label = string.Empty;
                    }
                }
            }
        }
    }
}
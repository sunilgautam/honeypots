using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using antiSQLInjection;
using gudusoft.gsqlparser;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class TestSQLInject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setState(3);
    }

    private void setState(int n)
    {
        if (n == 0)
        {
            // SUCCESS
            pnlForm.Visible = false;
            pnlSuccess.Visible = true;
            pnlFail.Visible = false;
            pnlInjected.Visible = false;
        }
        else if (n == 1)
        {
            // FAIL
            pnlForm.Visible = false;
            pnlSuccess.Visible = false;
            pnlFail.Visible = true;
            pnlInjected.Visible = false;
        }
        else if (n == 2)
        {
            // FAIL DUE TO SQL INJECTION
            pnlForm.Visible = false;
            pnlSuccess.Visible = false;
            pnlFail.Visible = false;
            pnlInjected.Visible = true;
        }
        else
        {
            // RESET
            pnlForm.Visible = true;
            pnlSuccess.Visible = false;
            pnlFail.Visible = false;
            pnlInjected.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string query = "SELECT * FROM USERS WHERE [USER_NAME] = '" + txtUserName.Text + "' AND [PASSWORD] = '" + txtPassword.Text + "'";
        TAntiSQLInjection testInjection = new TAntiSQLInjection(TDbVendor.DbVMssql);
        // CHECK IS QUERY IS INJECTED
        if (testInjection.isInjected(query))
        {
            setState(2);
        }
        else
        {
            SqlConnection appCon = new SqlConnection(ConfigurationManager.ConnectionStrings["honeypots.app.con"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, appCon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                setState(0);
                Reset();
            }
            else
            {
                setState(1);
                Reset();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        setState(3);
        Reset();
    }

    protected void btnTryAgain_Click(object sender, EventArgs e)
    {
        setState(3);
        Reset();
    }

    private void Reset()
    {
        txtUserName.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }
}
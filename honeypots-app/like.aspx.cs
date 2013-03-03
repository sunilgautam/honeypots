using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using honeypots;

public partial class like : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // SET TOKEN
            TokenManager.SetToken(this);
        }
        else
        {
            // CHECK TOKEN
            TokenManager.IsValidToken(this);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "You have clicked on Like";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "You have clicked on Unlike";
    }
}
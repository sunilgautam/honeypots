using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for SessionSecurePage
/// </summary>
public class SessionSecurePage : Page
{
	public SessionSecurePage()
	{
		
	}
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);//2
        if (Session["userid"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["username"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["password"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["fullname"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["schoolid"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["schoolname"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["usertype"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["strUserType"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        //else if (Session["teacherid"] == null)
        //{
        //    Response.Redirect("/Errors/sessionExpired.htm");
        //}
        else if (Session["YearId"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["MediumId"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);
        if (Session["useridentity"] != null)
        {
            if (Session["useridentity"] != string.Empty)
            {
                UserLogs track2 = new UserLogs(HttpContext.Current, long.Parse(Session["useridentity"].ToString()));
            }
            else
            {
                UserLogs track3 = new UserLogs(HttpContext.Current);
            }
        }
    }
}

public class SessionSecureMasterPage : MasterPage
{
    public SessionSecureMasterPage()
    {

    }
    protected override void OnInit(EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
        else if (Session["schoolname"] == null)
        {
            Response.Redirect("~/Errors/sessionExpired.htm");
        }
    }
}

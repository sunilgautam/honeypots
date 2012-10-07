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
using System.Web.SessionState;

/// <summary>
/// Summary description for GetDetails
/// </summary>
public class GetDetails
{
    public SqlDataAdapter da;
    public DataTable dt;
    
    public DataTable disprec(string str)
    {
        dt = new DataTable();
        da = new SqlDataAdapter(str,ConnectionManager.GetConnection());
        da.Fill(dt);
        ConnectionManager.CloseConnection();
        return dt;
    }

    public void fillcbo(DropDownList dd,string sql,string field)
    {
        dt = new DataTable();
        da = new SqlDataAdapter(sql,ConnectionManager.GetConnection());
        da.Fill(dt);
        dd.DataSource = dt;
        dd.DataTextField = field;
        dd.DataBind();
        ConnectionManager.CloseConnection();
    }

    public void fillcbo1(DropDownList dd, string sql, string field, string fldValue)
    {
        dt = new DataTable();
        da = new SqlDataAdapter(sql, ConnectionManager.GetConnection());
        da.Fill(dt);
        dd.DataSource = dt;
        dd.DataTextField = field;
        dd.DataValueField = fldValue;
        dd.DataBind();
        ConnectionManager.CloseConnection();
    }

    public void fillcbo2(DropDownList dd, string sql, string field, string fldValue)
    {
        dt = new DataTable();
        da = new SqlDataAdapter(sql, ConnectionManager.GetConnection());
        da.Fill(dt);
        dd.DataSource = dt;
        //dd.DataTextField = field;
        //dd.DataValueField = fldValue;
        dd.DataBind();
        ConnectionManager.CloseConnection();
    }

    public bool validateDate(string val)
    {
        int year = 0;
        int month = 0;
        int day = 0;
        string[] date;
        try
        {
            date = val.Split('/');
            if (date.Length != 3)
                return (false);
            day = int.Parse(date[0]);
            month = int.Parse(date[1]);
            year = int.Parse(date[2]);
            if (!(year >= 0 && year <= 9999))
                return (false);
            if (!(month >= 01 && month <= 12))
                return (false);
            if (!(day >= 01 && day <= 31))
                return (false);
        }
        catch (Exception ex)
        {
            return (false);
        }
        return (true);
    }

    public void BindDataList(Page pg,int schoold,int yearid, int mediumid)
    {
        int month = int.Parse(DateTime.Now.Month.ToString());
        int day = int.Parse(DateTime.Now.Day.ToString());

        //DataList dl = ((DataList)pg.Master.FindControl("dlistNotices"));
        Repeater dl = ((Repeater)pg.Master.FindControl("dlistNotices"));
        dl.DataSource = disprec("EXEC GetNotices 'Date',0,'" + DateTime.Now.ToShortDateString() + "'," + yearid + ", " + mediumid);
        dl.DataBind();
        DataList dl1 = ((DataList)pg.Master.FindControl("dlistBirthday"));
        //HtmlControl bdaydiv = (HtmlControl)pg.Master.FindControl("birthdaydiv");
        Panel pnldbay1 = ((Panel)pg.Master.FindControl("bdpanel"));
        dt = disprec("EXEC GetAdmissionDetails1 0,'Date Of Birth','No',0,0," + schoold + "," + yearid + ", " + mediumid + ",0," + month + "," + day + "");
        dl1.DataSource = dt;
        dl1.DataBind();
        if (dt.Rows.Count != 0)
        {
        //    bdaydiv.Style.Add("display", "inline");
            pnldbay1.Visible = true;
        }
        else
        {
        //    bdaydiv.Style.Add("display", "none");
            pnldbay1.Visible = false;
        }
    }

    public DataSet reportdataset(string sql)
    {
        DataSet ds = new DataSet();
        da = new SqlDataAdapter(sql, ConnectionManager.GetConnection());
        da.Fill(ds);
        ConnectionManager.CloseConnection();
        return ds;
    }
}

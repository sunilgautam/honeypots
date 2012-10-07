using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
/// <summary>
/// Tracks User Activity
/// </summary>
public class UserLogs : Page
{
    HttpContext baseContext;
    public UserLogs(HttpContext baseCon)
    {
        baseContext = baseCon;
        int user_id = int.Parse(baseContext.Session["userid"].ToString());
        string[] user_domain = getDomain();
        string vcrUserDomain = user_domain[0];
        string userLocation = user_domain[1];
        DateTime LogDateTime = DateTime.Now;
        string RequestType = baseContext.Request.RequestType;
        string RequestedPage = baseContext.Request.Url.ToString();
        string RefererPage = baseContext.Request.UrlReferrer.ToString();
        string Browser = GetBrowser();
        string PlatForm = baseContext.Request.Browser.Platform + "/" + baseContext.Request.UserAgent;
        int ContentSize = baseContext.Request.ContentLength;
        int Status = baseContext.Response.StatusCode;
        
    //NewGUID:
    //    Guid useridentity = System.Guid.NewGuid();
        //baseContext.Session["useridentity"] = useridentity.ToString();

        using (SqlCommand cmd = new SqlCommand("AddUserLog", ConnectionManager.GetConnection()))
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Delete", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@intLogId", SqlDbType.BigInt).Value = 0;
                //cmd.Parameters.Add("@useridentity", SqlDbType.UniqueIdentifier).Value = useridentity;
                cmd.Parameters.Add("@intUserId", SqlDbType.Int).Value = user_id;
                cmd.Parameters.Add("@vcrUserDomain", SqlDbType.VarChar).Value = vcrUserDomain;
                cmd.Parameters.Add("@dtmLogDateTime", SqlDbType.DateTime).Value = LogDateTime;
                cmd.Parameters.Add("@vcrRequestType", SqlDbType.VarChar).Value = RequestType;
                cmd.Parameters.Add("@vcrRequestedPage", SqlDbType.VarChar).Value = RequestedPage;
                cmd.Parameters.Add("@vcrRefererPage", SqlDbType.VarChar).Value = RefererPage;
                cmd.Parameters.Add("@vcrBrowser", SqlDbType.VarChar).Value = Browser;
                cmd.Parameters.Add("@vcrPlatForm", SqlDbType.VarChar).Value = PlatForm;
                cmd.Parameters.Add("@intStatus", SqlDbType.Int).Value = Status;
                cmd.Parameters.Add("@intContentSize", SqlDbType.BigInt).Value = ContentSize;
                cmd.Parameters.Add("@userLocation", SqlDbType.VarChar).Value = userLocation;
                cmd.Parameters.Add("@RetValue", SqlDbType.BigInt).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                baseContext.Session["useridentity"] = cmd.Parameters["@RetValue"].Value;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //goto NewGUID;
                }
            }
        }
    }

    public UserLogs(HttpContext baseCon, long refer)
    {
        baseContext = baseCon;
        DateTime LogDateTime = DateTime.Now;
        string RequestType = baseContext.Request.RequestType;
        string RequestedPage = baseContext.Request.Url.ToString();
        string RefererPage = baseContext.Request.UrlReferrer.ToString();
        int ContentSize = baseContext.Request.ContentLength;
        int Status = baseContext.Response.StatusCode;

        using (SqlCommand cmd = new SqlCommand("AddUserLog", ConnectionManager.GetConnection()))
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Delete", SqlDbType.VarChar).Value = "Refer";
                cmd.Parameters.Add("@intLogId", SqlDbType.BigInt).Value = 1;
                //cmd.Parameters.Add("@useridentity", SqlDbType.UniqueIdentifier).Value = useridentity;
                //cmd.Parameters.Add("@intUserId", SqlDbType.Int).Value = user_id;
                //cmd.Parameters.Add("@vcrUserDomain", SqlDbType.VarChar).Value = vcrUserDomain;
                cmd.Parameters.Add("@dtmLogDateTime", SqlDbType.DateTime).Value = LogDateTime;
                cmd.Parameters.Add("@vcrRequestType", SqlDbType.VarChar).Value = RequestType;
                cmd.Parameters.Add("@vcrRequestedPage", SqlDbType.VarChar).Value = RequestedPage;
                cmd.Parameters.Add("@vcrRefererPage", SqlDbType.VarChar).Value = RefererPage;
                //cmd.Parameters.Add("@vcrBrowser", SqlDbType.VarChar).Value = Browser;
                //cmd.Parameters.Add("@vcrPlatForm", SqlDbType.VarChar).Value = PlatForm;
                cmd.Parameters.Add("@intStatus", SqlDbType.Int).Value = Status;
                cmd.Parameters.Add("@intContentSize", SqlDbType.BigInt).Value = ContentSize;
                //cmd.Parameters.Add("@userLocation", SqlDbType.VarChar).Value = userLocation;
                //cmd.Parameters.Add("@RetValue", SqlDbType.BigInt).Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("@referId", SqlDbType.BigInt).Value = refer;
                cmd.ExecuteNonQuery();
                //baseContext.Session["useridentity"] = cmd.Parameters["@RetValue"].Value;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //goto NewGUID;
                }
            }
        }
    }

    protected string[] getDomain()
    {
        string ipaddress;
        string[] domaindetail = new string[2];
        string[] domain ={ "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--" };
        ipaddress = baseContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == null)
        {
            ipaddress = baseContext.Request.ServerVariables["REMOTE_ADDR"];
        }
        if (ipaddress != null)
        {
            if (ipaddress != "127.0.0.1")
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["apiKey"].ToString() + "&ip=" + ipaddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream stream = response.GetResponseStream();
                    XmlTextReader textReader = new XmlTextReader(stream);
                    //XmlTextReader textReader = new XmlTextReader(Server.MapPath("~/Test/XMLFile2.xml"));
                    textReader.WhitespaceHandling = WhitespaceHandling.None;
                    int i = -2;
                    while (textReader.Read())
                    {
                        switch (textReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                //if (textReader.IsEmptyElement)
                                //{
                                i++;
                                //}
                                break;
                            case XmlNodeType.Text:
                                domain[i] = textReader.Value;
                                //i++;
                                break;
                        }
                    }
                }
            }
        }
        domaindetail[0] = domain[2] + "/" + domain[4] + "/" + domain[5] + "/" + ipaddress;
        domaindetail[1] = domain[7] + "/" + domain[8];
        return domaindetail;
    }

    protected string GetBrowser()
    {
        string User_agent = baseContext.Request.UserAgent;
        string browserName = User_agent.ToLower().Contains("chrome") ? "Chrome" : baseContext.Request.Browser.Browser;
        string browserVersion = User_agent.ToLower().Contains("chrome") ? GetChromeVersion(User_agent) : baseContext.Request.Browser.Version.ToString();
        return browserName + "/" + browserVersion;
    }

    protected string GetChromeVersion(string agent)
    {
        int ch = agent.ToLower().LastIndexOf("chrome");
        string chstr = agent.Substring(ch);
        string full=agent.Substring(ch, chstr.IndexOf(" "));
        return full.Substring(full.IndexOf("/") + 1);
    }
}
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;

namespace honeypots
{
    public class UserLogger
    {
        private UserLog objUserLog;
        private DBAccess objDBAccess;
        public UserLogger()
        {
            objUserLog = new UserLog();
        }

        internal void StartUserLog(HttpContext baseContext)
        {
            objUserLog.User_Agent = baseContext.Request.UserAgent;
            objUserLog.Browser = GetBrowser(baseContext);
            string[] user_domain = GetDomain(baseContext);
            objUserLog.Domain = user_domain[0];
            objUserLog.Location = user_domain[1];
            objUserLog.Log_Id = 0;
            objUserLog.Page = baseContext.Request.Url.ToString();
            if (baseContext.Request.UrlReferrer != null)
            {
                objUserLog.Page_Referer = baseContext.Request.UrlReferrer.ToString();
            }
            else
            {
                objUserLog.Page_Referer = string.Empty;
            }
            objUserLog.Platform = baseContext.Request.Browser.Platform + "/" + baseContext.Request.UserAgent;
            objUserLog.User_Lang = string.Join(",", baseContext.Request.UserLanguages);
            objUserLog.Request_Content_Size = baseContext.Request.ContentLength;
            objUserLog.Request_Type = baseContext.Request.RequestType;
            objUserLog.Request_Started_At = DateTime.Now;
        }

        internal void SetUserLogState(HttpContext baseContext)
        {
            objUserLog.Session_Id = baseContext.Session.SessionID;
        }

        internal void EndUserLog(HttpContext baseContext)
        {
            objUserLog.Mime_Type = baseContext.Response.ContentType;
            objUserLog.Request_Status = baseContext.Response.StatusCode;
            objUserLog.Request_Ended_At = DateTime.Now;
            objUserLog.Request_Processing_Time = (objUserLog.Request_Ended_At - objUserLog.Request_Started_At).TotalMilliseconds;
        }

        internal void SubmitUserLog(HttpContext baseContext)
        {
            objDBAccess = new DBAccess();
            objDBAccess.LogRequest(this.objUserLog);
        }

        protected string[] GetDomain(HttpContext baseContext)
        {
            string ipaddress;
            string[] domaindetail = new string[2];
            string[] domain = { "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--", "--" };
            ipaddress = baseContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == null)
            {
                ipaddress = baseContext.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (ipaddress != null)
            {
                if (ipaddress != "127.0.0.1")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["honeypots.api.key"].ToString() + "&ip=" + ipaddress);
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

        protected string GetBrowser(HttpContext baseContext)
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
            string full = agent.Substring(ch, chstr.IndexOf(" "));
            return full.Substring(full.IndexOf("/") + 1);
        }
    }
}
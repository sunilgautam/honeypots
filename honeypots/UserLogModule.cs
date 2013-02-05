using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace honeypots
{
    public class UserLogModule : IHttpModule
    {
        UserLogger objUserLogger;
        public UserLogModule()
        {
            
        }

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
            context.PostAcquireRequestState += new EventHandler(context_PostAcquireRequestState);
            context.Error += new EventHandler(context_Error);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                HttpApplication context = ((HttpApplication)sender);
                objUserLogger = new UserLogger();
                objUserLogger.StartUserLog(context.Context);
            }
            catch (Exception ex)
            {
                objUserLogger.SubmitErrorLog(ex);
                HandleResponseOnError();
            }
        }

        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            try
            {
                HttpApplication context = ((HttpApplication)sender);
                if (objUserLogger != null)
                {
                    objUserLogger.SetUserLogState(context.Context);
                }
            }
            catch (Exception ex)
            {
                objUserLogger.SubmitErrorLog(ex);
                HandleResponseOnError();
            }
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            try
            {
                HttpApplication context = ((HttpApplication)sender);
                if (objUserLogger != null)
                {
                    objUserLogger.EndUserLog(context.Context);
                    objUserLogger.SubmitUserLog(context.Context);
                }
            }
            catch (Exception ex)
            {
                objUserLogger.SubmitErrorLog(ex);
                HandleResponseOnError();
            }
        }

        void context_Error(object sender, EventArgs e)
        {
            try
            {
                HttpApplication context = ((HttpApplication)sender);
                if (objUserLogger != null)
                {
                    objUserLogger.SubmitErrorLog(context.Context.Server.GetLastError());
                    HandleResponseOnError();
                }
            }
            catch (Exception ex)
            {
                objUserLogger.SubmitErrorLog(ex);
                HandleResponseOnError();
            }
        }

        void HandleResponseOnError()
        {
            // CHECK IF CUSTOM ERROR IS NOT ENABLED IN WEBSITE
            if (!HttpContext.Current.IsCustomErrorEnabled)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/html";
                HttpContext.Current.Response.Write("<html><head><title>Error</title></head><body>");
                HttpContext.Current.Response.Write("<div><h2>Error occured in application !!!</h2><br /><u>handled by honeypots error handler</u></div>");
                HttpContext.Current.Response.Write("</body></html>");
                HttpContext.Current.Response.End();
            }
        }
    }
}
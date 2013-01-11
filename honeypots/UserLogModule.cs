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
                
            }
        }
    }
}
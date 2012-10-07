using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace honeypots
{
    public class UserLogModule : IHttpModule
    {
        public UserLogModule()
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
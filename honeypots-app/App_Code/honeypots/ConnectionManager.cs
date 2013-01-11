using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace honeypots
{
    public class ConnectionManager
    {
        private ConnectionManager()
        {

        }

        internal static ConnectionManager Instance
        {
            get
            {
                return new ConnectionManager();
            }
        }

        internal SqlConnection GetConnection()
        {
            try
            {
                object conSetting = ConfigurationManager.ConnectionStrings["honeypots.app.con"];
                if (conSetting != null)
                {
                    SqlConnection appCon = new SqlConnection(((ConnectionStringSettings)conSetting).ConnectionString);
                    if (appCon != null)
                    {
                        return appCon;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception("No honeypot connctions settings found. Please specify them.");
                }
            }
            catch
            {
                throw new Exception("Error occurred while initializing honeypot connection manager.");
            }
        }
    }
}
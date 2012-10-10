using System;
using System.Data;
using System.Data.SqlClient;

namespace honeypots
{
    public class DBAccess
    {
        private SqlConnection hCon;

        public DBAccess()
        {
            
        }

        internal void LogRequest(honeypots.UserLog objUserLog)
        {
            try
            {
                hCon = honeypots.ConnectionManager.Instance.GetConnection();
                SqlCommand cmd = new SqlCommand("ADD_USER_LOG", hCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@USER_SESSION_ID", SqlDbType.NVarChar).Value = objUserLog.Session_Id;
                cmd.Parameters.Add("@USER_DOMAIN", SqlDbType.NVarChar).Value = objUserLog.Domain;
                cmd.Parameters.Add("@USER_BROWSER", SqlDbType.NVarChar).Value = objUserLog.Browser;
                cmd.Parameters.Add("@USER_PLATFORM", SqlDbType.NVarChar).Value = objUserLog.Platform;
                cmd.Parameters.Add("@USER_LOCATION", SqlDbType.NVarChar).Value = objUserLog.Location;
                cmd.Parameters.Add("@REQUEST_TYPE", SqlDbType.VarChar).Value = objUserLog.Request_Type;
                cmd.Parameters.Add("@REQUEST_PAGE", SqlDbType.NVarChar).Value = objUserLog.Page;
                cmd.Parameters.Add("@REQUEST_REFERER", SqlDbType.NVarChar).Value = objUserLog.Page_Referer;
                cmd.Parameters.Add("@REQUEST_CONTENT_SIZE", SqlDbType.BigInt).Value = objUserLog.Request_Content_Size;
                cmd.Parameters.Add("@RESPOSE_STATUS", SqlDbType.Int).Value = objUserLog.Request_Status;
                cmd.Parameters.Add("@REQUEST_START_TIME", SqlDbType.DateTime).Value = objUserLog.Request_Started_At;
                cmd.Parameters.Add("@REQUEST_END_TIME", SqlDbType.DateTime).Value = objUserLog.Request_Ended_At;
                cmd.Parameters.Add("@PROCESSING_TIME", SqlDbType.VarChar).Value = Convert.ToString(objUserLog.Request_Processing_Time);

                hCon.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (hCon.State != ConnectionState.Closed)
                {
                    hCon.Close();
                }
            }
        }
    }
}
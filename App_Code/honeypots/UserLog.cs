using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace honeypots
{
    public class UserLog
    {
        public UserLog()
        {

        }

        private long _Log_Id;
        public long Log_Id
        {
            get { return _Log_Id; }
            set { _Log_Id = value; }
        }

        private string _Session_Id;
        public string Session_Id
        {
            get { return _Session_Id; }
            set { _Session_Id = value; }
        }

        private string _Domain;
        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }

        private string _Browser;
        public string Browser
        {
            get { return _Browser; }
            set { _Browser = value; }
        }

        private string _Platform;
        public string Platform
        {
            get { return _Platform; }
            set { _Platform = value; }
        }

        private string _Location;
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        private string _Request_Type;
        public string Request_Type
        {
            get { return _Request_Type; }
            set { _Request_Type = value; }
        }

        private string _Page;
        public string Page
        {
            get { return _Page; }
            set { _Page = value; }
        }

        private string _Page_Referer;
        public string Page_Referer
        {
            get { return _Page_Referer; }
            set { _Page_Referer = value; }
        }

        private long _Request_Content_Size;
        public long Request_Content_Size
        {
            get { return _Request_Content_Size; }
            set { _Request_Content_Size = value; }
        }

        private int _Request_Status;
        public int Request_Status
        {
            get { return _Request_Status; }
            set { _Request_Status = value; }
        }

        private DateTime _Request_Started_At;
        public DateTime Request_Started_At
        {
            get { return _Request_Started_At; }
            set { _Request_Started_At = value; }
        }

        private DateTime _Request_Ended_At;
        public DateTime Request_Ended_At
        {
            get { return _Request_Ended_At; }
            set { _Request_Ended_At = value; }
        }

        private double _Request_Processing_Time;
        public double Request_Processing_Time
        {
            get { return _Request_Processing_Time; }
            set { _Request_Processing_Time = value; }
        }
    }
}
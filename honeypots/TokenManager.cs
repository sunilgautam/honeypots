using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.HtmlControls;

namespace honeypots
{
    public abstract class TokenManager
    {
        public TokenManager()
        {

        }

        public static readonly string FormToken = "_0x_0x_0x_form_token";
        public static readonly string SessionToken = "user_token";
        public static readonly string CookieToken = "client_token";
        public static readonly string UrlToken = "token";

        //***************************************************
        //*   Validate token number against session values  *
        //*            and Double Submit Cookies            *
        //***************************************************
        public static bool IsValidToken(Page current, bool processOnInvalid = true)
        {
            bool status = false;
            string token = null;
            try
            {
                if (current != null)
                {
                    if (current.Request.Form[TokenManager.FormToken] != null)
                    {

                        token = current.Session[TokenManager.SessionToken].ToString();
                        if (token == current.Request[TokenManager.FormToken].ToString() && token == current.Request[TokenManager.CookieToken].ToString())
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    else if (current.Request[TokenManager.UrlToken] != null)
                    {
                        token = current.Session[TokenManager.SessionToken].ToString();
                        if (token == current.Request[TokenManager.UrlToken].ToString() && token == current.Request[TokenManager.CookieToken].ToString())
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    else
                    {
                        status = false;
                    }
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }

            if (status == false)
            {
                if (processOnInvalid)
                {
                    ProcessInvalid(current);
                }
            }
            else
            {
                KeepToken(current, token);
            }

            return status;
        }

        //***************************************************
        //*   Generates a Cryptographically strong token    *
        //***************************************************
        public static string GetToken()
        {
            byte[] data = new byte[20];
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(data);
            UTF8Encoding encoder = new UTF8Encoding();
            StringBuilder displaystring = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                displaystring.Append(data[i].ToString("x2"));
            }
            return displaystring.ToString();
        }

        //***************************************************
        //*         Assign a token to a page                *
        //***************************************************
        public static string SetToken(Page current)
        {
            try
            {
                Literal form_token = null;
                HttpCookie token_cookie = null;

                form_token = new Literal();
                form_token.ID = TokenManager.FormToken;
                form_token.ClientIDMode = ClientIDMode.Static;
                string token_id = GetToken();
                form_token.Text = string.Format("<input type=\"hidden\" name=\"{0}\" id=\"{1}\" value=\"{2}\">", TokenManager.FormToken, TokenManager.FormToken, token_id);

                token_cookie = new HttpCookie(TokenManager.CookieToken, token_id);
                token_cookie.HttpOnly = true;

                current.Response.Cookies.Add(token_cookie);
                current.Form.Controls.Add(form_token);

                current.Session[TokenManager.SessionToken] = token_id;
                return token_id;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        public static string KeepToken(Page current, string token_id)
        {
            try
            {
                Literal form_token = null;
                form_token = new Literal();
                form_token.ID = TokenManager.FormToken;
                form_token.ClientIDMode = ClientIDMode.Static;
                form_token.Text = string.Format("<input type=\"hidden\" name=\"{0}\" id=\"{1}\" value=\"{2}\">", TokenManager.FormToken, TokenManager.FormToken, token_id);

                current.Form.Controls.Add(form_token);

                return token_id;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        private static void ProcessInvalid(Page current)
        {
            current.Response.Clear();
            current.Response.ContentType = "text/html";
            current.Response.Write("<html><head><title>Invalid Token</title></head><body>");
            current.Response.Write("<div><h2>Unable to process request due to following problem</h2><ul><li>Invalid token detected</li></ul><br /><u>handled by honeypots token manager</u></div>");
            current.Response.Write("</body></html>");
            current.Response.End();
        }
    }
}
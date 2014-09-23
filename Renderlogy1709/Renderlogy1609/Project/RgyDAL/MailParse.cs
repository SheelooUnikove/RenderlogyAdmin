using RenderlogyEmail.Common.Logging;
using RenderlogyEmail.Mime;
using RenderlogyEmail.Pop3;
using RenderlogyEmail.Pop3.Exceptions;
using RenderlogyUtility.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RgyDAL
{
    public class MailParse
    {
        private Pop3Client pop3Client;
        private Pop3DataClient data;
        private string ConnString = ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ToString();
        /// <summary>
        /// Return last mail's content stored in the database
        /// </summary>
        /// <param name="MailServerName">EMail server name</param>
        /// <param name="PortNo">EMail port no</param>
        /// <param name="isSslEnabled">Is SSL enabled</param>
        /// <param name="loginName">EMail Id for which you want ot get the data</param>
        /// <param name="Password">EMail password</param>
        /// <returns>Currently return last mail's data</returns>
        public DataTable mailcontents(string MailServerName, int PortNo, bool isSslEnabled, string loginName, string Password)
        {
            Dictionary<int, Message> messages = new Dictionary<int, Message>();
            DataTable datatable = new DataTable();
            //// This is how you would override the default logger type
            //// Here we want to log to a file
            DefaultLogger.SetLog(new FileLogger());
            FileLogger.LogPath = HttpContext.Current.Server.MapPath("~/Attachments/");

            // Enable file logging and include verbose information
            FileLogger.Enabled = true;
            FileLogger.Verbose = true;

            try
            {
                pop3Client = new Pop3Client();
                data = new Pop3DataClient();

                if (pop3Client.Connected)
                    pop3Client.Disconnect();
                pop3Client.Connect(MailServerName, PortNo, isSslEnabled);
                pop3Client.Authenticate(loginName, Password);
                //DateTime? lastmsgSavedDate = data.GetLastSavedDate(ConnString, loginName);
                //messages = pop3Client.GetAllMessages(lastmsgSavedDate); //Used to get all messages from the given EMail Id
                //foreach (Message message in messages.Values)
                //{
                int msgcount = pop3Client.GetMessageCount();
                Message message = pop3Client.GetMessage(msgcount);
                    data.SaveMessageToDatabase(ConnString, message, FileLogger.LogPath);
                //}
                //Currently return last inserted data
                datatable = data.GetMessageFromDatabase(ConnString).Tables[0];
                return datatable;
            }
            catch (InvalidLoginException)
            {
                DefaultLogger.Log.LogError("POP3 Server Authentication: The server did not accept the user credentials!");
                return datatable;
            }
            catch (PopServerNotFoundException)
            {
                DefaultLogger.Log.LogError("POP3 Retrieval: The server could not be found");
                return datatable;
            }
            catch (PopServerLockedException)
            {
                DefaultLogger.Log.LogError("POP3 Account Locked: The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?");
                return datatable;
            }
            catch (LoginDelayException)
            {
                DefaultLogger.Log.LogError("POP3 Account Login Delay: Login not allowed. Server enforces delay between logins. Have you connected recently?");
                return datatable;
            }
            catch (Exception ex)
            {
                DefaultLogger.Log.LogError("Failed Code due to: " + ex.Message + "\r\n" + "Stack trace:\r\n" + ex.StackTrace);
                return datatable;
            }
        }
    }
}
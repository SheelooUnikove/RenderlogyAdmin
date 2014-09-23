using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace RenderLogy.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter register email id")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please Enter correct Email Format")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }


        public bool IsUserExist(string emailid, string password)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection(
           System.Configuration.ConfigurationManager.ConnectionStrings["ConRenderLogy"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from SignUp where userID='" + emailid + "' and PasswordConfirm='" + password + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }

      //  public string EmailId { get; set; }

        private static String smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
        private static String defaultFrom = ConfigurationManager.AppSettings["MailFrom"];
       // public string RandomPassword { get; set; }
        public string RegistrationMail( int SignUpId) //string RandomPassword,
        {
            SignUpModel objSignUpModel = new SignUpModel();
            string strSmtpFailedRecipientException = string.Empty;
            try
            {
                // string from = CommonDataUtilityService.FeedBackEmailId;
                string from =(string) HttpContext.Current.Session["EmailId"];
                string to = (string)HttpContext.Current.Session["EmailId"];      //ConfigurationManager.AppSettings["MailTo"];
                string subject = "Renderlogy Alert";

                string hosturl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/ConfirmAccount?Id=" + SignUpId +"&EmailId="+from; 
                string confirmationLink = string.Format("<a href=\"{0}\">Clink to confirm your registration</a>", hosturl);
               // string body = "<html><head></head><body><span style=" + "font-size:13px;" + ">You have received this message from renderlogy <b>" + objSignUpModel.FullName + "</b></span>" + "<br/><span style=" + "font-size:13px;" + "><b>Message:</b>: " + confirmationLink + "\n\n\n<br/><br/> Thanks</br></br></br> <b>RenderLogy Team </b></span></body></html>";

                string mailerPath = System.Web.HttpContext.Current.Server.MapPath("~/mailer/AccountActivation.htm");
                string body = string.Empty;
                body = System.IO.File.ReadAllText(mailerPath);
                body = body.Replace("<message>", confirmationLink);
                //string body = "<html><head></head><body><span style=" + "font-size:13px;" + ">You have received this message from renderlogy <b>" + objSignUpModel.FullName + "</b></span>" + "<br/><b>Your Temporay password :</b>" + RandomPassword + "<br/><span style=" + "font-size:13px;" + "><b>Message:</b>: " + confirmationLink + "\n\n\n<br/><br/> Thanks</br> <b>RenderLogy Team </b></span></body></html>";
               // string mailerPath = System.Web.HttpContext.Current.Server.MapPath("~/mailer/feedBack.html");
                //string body = string.Empty;
                //body = System.IO.File.ReadAllText(mailerPath);
                //body = body.Replace("<Message>", CommonDataUtilityService.UserMessage);
                //if (CommonDataUtilityService.ISSpentTimeGood.ToLower().ToString() == "yes")
                //    body = body.Replace("<Status>", "Like");
                //else
                //    body = body.Replace("<Status>", "Unlike");
                //body = body.Replace("<EmailId>", CommonDataUtilityService.EmailId);
                //body = body.Replace("<MobileNo>", CommonDataUtilityService.MobileNo);

                SmtpClient smtp = new SmtpClient(smtpServer, Convert.ToInt32(ConfigurationManager.AppSettings["PortNo"]));
                MailMessage message = new MailMessage(from, to, subject, body);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpPassword"]);
                message.IsBodyHtml = true;
                smtp.Credentials = credentials;
                smtp.EnableSsl = false;
                try
                {
                    smtp.Send(message);
                    return "Message sent successfully.";
                }
                catch (SmtpFailedRecipientException objSmtpFailedRecipientException)
                {

                    SmtpStatusCode status = objSmtpFailedRecipientException.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy)
                    {
                        strSmtpFailedRecipientException = "MailboxBusy";
                    }
                    else if (status == SmtpStatusCode.MailboxUnavailable)
                    {
                        strSmtpFailedRecipientException = "MailboxUnavailable";
                    }
                    else
                    {
                        strSmtpFailedRecipientException = objSmtpFailedRecipientException.Message;
                    }
                    return "Message failure to send.";
                }
            }
            catch (Exception objEx)
            {
                strSmtpFailedRecipientException = objEx.Message;
                return "Message failure to send.";
            }
        }
    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Web;


namespace RgyDAL
{
    public class MailUtil
    {
        CommonUtility objCommonUtil = new CommonUtility();
        ////////////////// Mailer Setction
        public string SendForgotPassword(string FullName, string EmailId, string Password, string mailerpath)
        {
            // string mailerpath= Server.MapPath("~/RenderLogy/Mailer/forgotPassword.htm"); 
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string mailto = EmailId; //objCommonUtil.SendPassEmailId;
            string subject = "RenderLogy::Alert->Forgot Password";
            string message = "<tr>";
            message += "<td width='30'>&nbsp;</td>";
            message += "<td height='30'><span style='font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-weight:normal; color:#999999; '>Dear " + FullName + "," + "</span></td>";
            message += "<td width='30'>&nbsp;</td>";
            message += "</tr>";
            message += "<tr>";
            message += "<td width='30'>&nbsp;</td>";
            message += "<td height='30'><span style='font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-weight:normal; color:#999999; '>We have received a request to reset your password. Here are your details.</span></td>";
            message += "<td width='30'>&nbsp;</td>";
            message += "</tr>";
            message += "<tr>";
            message += "<td width='30'>&nbsp;</td>";
            message += "<td height='30'>&nbsp;</td>";
            message += "<td width='30'>&nbsp;</td>";
            message += "</tr>";
            message += "<tr>";
            message += "<td width='30'>&nbsp;</td>";
            message += "<td height='30'><span style='font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-weight:normal; color:#999999; '>E-mail ID: <span style='font-size:18px;  color:#777;'><a href='#' style='text-decoration:none;'><font color='#777777'>" + EmailId + "</font></a></span></span></td>";
            message += "<td width='30'>&nbsp;</td>";
            message += "</tr>";
            message += "<tr>";
            message += "<td width='30'>&nbsp;</td>";
            message += "<td height='30'><span style='font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-weight:normal; color:#999999; '>Password: <span style='font-size:18px;  color:#777;'>" + Password + "</span></span></td>";
            message += "<td width='30'>&nbsp;</td>";
            message += "</tr>";
            // MailUtil.
            sendMail(mailerpath, mailto, mailfrom, subject, message);
            return "Password sent successfully.";
        }
        public void sendMail(string MailerPath, string MailTo, string MailFrom, string subject, string body)
        {
            try
            {
                string str = string.Empty;
                str = System.IO.File.ReadAllText(MailerPath);
                str = str.Replace("<message>", body);
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(MailTo, subject));
                mail.From = new MailAddress(MailFrom);
                mail.Subject = subject.ToString();
                mail.IsBodyHtml = true;
                mail.Body = str;
                sendProcess(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void sendProcess(MailMessage Mail)
        {
            try
            {
                SmtpClient objClient = new SmtpClient();
                //objClient.EnableSsl = true;
                objClient.EnableSsl = false;
                objClient.Send(Mail);
                if (Mail.Attachments.Count > 0)
                {
                    Mail.Attachments.Dispose();
                }
                Mail.Dispose();
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

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
        public string RegistrationMail(int SignUpId) //string RandomPassword,
        {
            SignUp objSignUpModel = new SignUp();
            string strSmtpFailedRecipientException = string.Empty;
            try
            {

                string from = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string to = (string)HttpContext.Current.Session["EmailId"];      //ConfigurationManager.AppSettings["MailTo"];
                string subject = "Renderlogy Alert";

                string hosturl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/ConfirmAccount?Id=" + SignUpId + "&EmailId=" + to;
                string confirmationLink = string.Format("<a href=\"{0}\">Click to confirm your registration</a>", hosturl);
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


        public string InviteNewMemberMail(string ToEmail) //string RandomPassword,
        {
            SignUp objSignUpModel = new SignUp();
            string strSmtpFailedRecipientException = string.Empty;
            try
            {

                string from = ConfigurationManager.AppSettings["MailFrom"].ToString();
                // string to = (string)HttpContext.Current.Session["EmailId"];      //ConfigurationManager.AppSettings["MailTo"];
                string subject = "Renderlogy Alert";

                //string strarr = ToEmail.Remove(ToEmail.Length - 1, ToEmail.Length);


                string[] ToArray = ToEmail.Split(',');

                // foreach (string Toitem in ToArray.Count())
                for (int i = 0; i < ToArray.Count() - 1; i++)
                {

                    string hosturl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/AccountActive?EmailId=" + ToArray[i];
                    string confirmationLink = string.Format("<a href=\"{0}\">Click to confirm your registration</a>", hosturl);

                    string mailerPath = System.Web.HttpContext.Current.Server.MapPath("~/mailer/AccountActivation.htm");
                    string body = string.Empty;
                    body = System.IO.File.ReadAllText(mailerPath);
                    body = body.Replace("<message>", confirmationLink);

                    SmtpClient smtp = new SmtpClient(smtpServer, Convert.ToInt32(ConfigurationManager.AppSettings["PortNo"]));


                    MailMessage message = new MailMessage(from, ToArray[i], subject, body);
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpPassword"]);
                    message.IsBodyHtml = true;
                    smtp.Credentials = credentials;
                    smtp.EnableSsl = false;
                    try
                    {
                        smtp.Send(message);
                        // return "Message sent successfully.";
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
                return "Message sent successfully.";
            }
            catch (Exception objEx)
            {
                strSmtpFailedRecipientException = objEx.Message;
                return "Message failure to send.";
            }
        }

        //string str = string.Empty;
        //    str = System.IO.File.ReadAllText(MailerPath);
        //    str = str.Replace("<message>", Message);
        //    str = str.Replace("<footer>", Footer);
        //    MailMessage mail = new MailMessage();
        //    string[] separator = new string[] { "," ,";"};
        //    string[] strSplitArr = MailTo.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string add in strSplitArr)
        //    {
        //        mail.To.Add(new MailAddress(add));
        //    }
        //    mail.From = new MailAddress(MailFrom, "InfoOne");
        //    mail.Subject = Subject;
        //    if (Attachment != "")
        //    {
        //        objAtt = new Attachment(Attachment);
        //        mail.Attachments.Add(objAtt);
        //        //objAtt.Dispose();
        //    }
        //    mail.IsBodyHtml = true;
        //    mail.Body = str;
        //    sendProcess(mail);
        //    if(objAtt!=null)
        //    objAtt.Dispose();


        // string[] Multi =ToEmail.Split(','); //spiliting input Email id string with comma(,)
        //foreach (string Multiemailid in Multi)
        //{
        //    mailMessage.To.Add(new MailAddress(Multiemailid)); //adding multi reciver's Email Id
        //}


        public string InviteNewCustomer(string ToEmail,int Id)
        {
            SignUp objSignUpModel = new SignUp();
            string strSmtpFailedRecipientException = string.Empty;
            try
            {

                string from = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string subject = "Renderlogy Alert";


                string hosturl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/AccountActive?EmailId=" + Id;
                string confirmationLink = string.Format("<a href=\"{0}\">Click to confirm your registration</a>", hosturl);

                string mailerPath = System.Web.HttpContext.Current.Server.MapPath("~/mailer/AccountActivation.htm");
                string body = string.Empty;
                body = System.IO.File.ReadAllText(mailerPath);
                body = body.Replace("<message>", confirmationLink);

                SmtpClient smtp = new SmtpClient(smtpServer, Convert.ToInt32(ConfigurationManager.AppSettings["PortNo"]));


                MailMessage message = new MailMessage(from, ToEmail, subject, body);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpPassword"]);
                message.IsBodyHtml = true;
                smtp.Credentials = credentials;
                smtp.EnableSsl = false;
                try
                {
                    smtp.Send(message);
                    // return "Message sent successfully.";
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


                return "Message sent successfully.";
            }
            catch (Exception objEx)
            {
                strSmtpFailedRecipientException = objEx.Message;
                return "Message failure to send.";
            }
        }

    }
}

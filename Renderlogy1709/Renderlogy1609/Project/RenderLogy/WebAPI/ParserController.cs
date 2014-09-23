using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using RgyDAL;
using System.Xml.Serialization;
using System.Configuration;

namespace RenderLogy.WebAPI
{
    public class ParserController : ApiController
    {

        DataContext Context = new DataContext();

        [HttpGet]
        [ActionName("MailParsing")]
        public MessageDetails MailParser()
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            string MailServerName = nvc["MailServer"].ToString();
            int PortNo = int.Parse(nvc["PortNo"].ToString());
            bool isSslEnabled = bool.Parse(nvc["SslEnabled"].ToString());
            string loginName = nvc["loginName"].ToString();
            string Password = nvc["Password"].ToString();           
           
            
            MailParse objmailparse = new MailParse();
            String fullmailStr = string.Empty;
            List<ParseResults> objTagsDictionary = new List<ParseResults>();
          
            DataTable dt = objmailparse.mailcontents(MailServerName, PortNo, isSslEnabled, loginName, Password);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MessageDetails msg = new MessageDetails();
                    msg.From = dr["FromEmail"].ToString();

                    DateTime recvDate;
                    DateTime.TryParse(dr["EmailRecvDate"].ToString(), out recvDate);
                    msg.ReceivedDate = recvDate;

                    msg.ToMailIds = new List<MailIds>();
                    string[] toMailIds = dr["ToEmail"].ToString().Split(';');
                    foreach (string mailId in toMailIds)
                    {
                        if (mailId != "")
                        {
                            MailIds ToMailIds = new MailIds();
                            ToMailIds.MailId = mailId;
                            msg.ToMailIds.Add(ToMailIds);
                        }
                    }

                    msg.CCMailIds = new List<MailIds>();
                    string[] ccMailIds = dr["CC"].ToString().Split(';');
                    foreach (string mailId in ccMailIds)
                    {
                        if (mailId != "")
                        {
                            MailIds CCMailIds = new MailIds();
                            CCMailIds.MailId = mailId;
                            msg.CCMailIds.Add(CCMailIds);
                        }
                    }

                    msg.BccMailIds = new List<MailIds>();
                    string[] bccMailIds = dr["BCC"].ToString().Split(';');
                    foreach (string mailId in bccMailIds)
                    {
                        if (mailId != "")
                        {
                            MailIds bccMailId = new MailIds();
                            bccMailId.MailId = mailId;
                            msg.BccMailIds.Add(bccMailId);
                        }
                    }

                    msg.Subject = new SubjectDetail();
                    msg.Subject.recvSubject = dr["Subject"].ToString();
                    msg.Subject.parseData = TextParser(dr["Subject"].ToString());

                    msg.Body = new BodyDetail();
                    msg.Body.recvBody = dr["Body"].ToString();
                    msg.Body.parseData = TextParser(dr["Body"].ToString());

                    msg.Attachments = new List<Attachment>();
                    Attachment attach;
                    if (dr["AttachFileName"].ToString() != "")
                    {
                        char[] chArr = { '|', '|' };
                        string[] strAttachFileName = dr["AttachFileName"].ToString().Split(chArr);
                        foreach (string singleFileName in strAttachFileName)
                        {
                            if (singleFileName != "")
                            {
                                attach = new Attachment();
                                attach.fileName = singleFileName;
                                if (Path.GetExtension(singleFileName).ToLower() == ".doc" || Path.GetExtension(singleFileName).ToLower() == ".docx")
                                {
                                    attach.fileType = "Word";
                                    WordParser wordObj = new WordParser();
                                    String strWord = wordObj.WordContent(singleFileName);
                                    attach.parseData = TextParser(strWord);
                                }
                                else if (Path.GetExtension(singleFileName).ToLower() == ".xls" || Path.GetExtension(singleFileName).ToLower() == ".xlsx")
                                {
                                    attach.fileType = "Excel";
                                    ExcelParser excelObj = new ExcelParser();
                                    DataTable dtExcel = excelObj.ExcelContent(singleFileName, true, "Sheet1");
                                    int colCount = dtExcel.Columns.Count;
                                    foreach (DataRow drRow in dtExcel.Rows)
                                    {
                                        String strExcel = string.Empty;
                                        for (int colIteration = 0; colIteration < colCount; colIteration++)
                                        {
                                            strExcel += drRow[colIteration].ToString() + " ";
                                        }
                                        attach.parseData = TextParser(strExcel);
                                    }
                                }
                                msg.Attachments.Add(attach);
                            }
                        }
                    }
                    return msg;
                }
            }
            return new MessageDetails();
        }
         
        [HttpGet]
        public ParseResults TextParser(string parsetext)
        {
            var FullParsingStr = parsetext.Replace("\n", " ").Replace("\r", " ");
            //var FullParsingStr = parsetext;// nvc["StrText"];
            List<TagsDictionary> objTagsDictionary = new List<TagsDictionary>();
            ParseResults objparseItem = new ParseResults();

            var data = Context.TagDictionary.ToList();
            
            try
            {
                foreach(var item in data)
                {
                    if (FullParsingStr.ToLower().Contains(item.TagTitle.ToLower()))
                    {
                        TagsDictionary tagitem = new TagsDictionary();
                        tagitem.TagId = item.TagId;
                        tagitem.TagTitle = item.TagTitle;
                        tagitem.Action = item.Action;
                        tagitem.ActionAPI = item.ActionAPI;
                        objTagsDictionary.Add(tagitem);
                    }
                }

                List<UsersData> matchedUsers = new List<UsersData>();
                var UserData = Context.SignUp.ToList();
                foreach (var Useritem in UserData)
                {
                    if (FullParsingStr.ToLower().Contains(Useritem.FullName.ToLower()) && Useritem.FullName!="")
                    {
                        UsersData uitem = new UsersData();
                        uitem.UserId = Useritem.SignUpId;
                        uitem.FullName = Useritem.FullName;
                        uitem.Address = Useritem.Address;
                        uitem.EmailId = Useritem.EmailId;
                        matchedUsers.Add(uitem);
                    }
                }
                
                 //date parser


                String strtext= Convert.ToString(FullParsingStr);
                string[] TextArray =strtext.Split(' ');

                List<string> objdateStr = new List<string>();

                foreach (String text in TextArray)
                {

                    //var regex1 = new Regex(@"\b\d{2}\/\d{2}/\d{4}\b");
                    //foreach (Match m in regex1.Matches(text))
                    //{
                    //    DateTime dt;
                    //    if (DateTime.TryParseExact(m.Value, "dd/MM/yyyy", null, DateTimeStyles.None, out dt))
                    //        objdateStr.Add(text);  
                    //}
                  
                    var regex3 = new Regex(@"^((31(?!\ (Feb(ruary)?|Apr(il)?|June?|(Sep(?=\b|t)t?|Nov)(ember)?)))|((30|29)(?!\ Feb(ruary)?))|(29(?=\ Feb(ruary)?\ (((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])\ (Jan(uary)?|Feb(ruary)?|Ma(r(ch)?|y)|Apr(il)?|Ju((ly?)|(ne?))|Aug(ust)?|Oct(ober)?|(Sep(?=\b|t)t?|Nov|Dec)(ember)?)\ ((1[6-9]|[2-9]\d)\d{2})$");
                    foreach (Match m in regex3.Matches(text.ToUpper()))
                    {
                        // DateTime dt;
                        // if (DateTime.TryParseExact(m.Value, "DD-MMM-YYYY", null, DateTimeStyles.None, out dt))
                        objdateStr.Add(text);
                    }

                    var regex5 = new Regex(@"\b\d{4}\-(Jan(uary)?|Feb(ruary)?|Ma(r(ch)?|y)|Apr(il)?|Ju((ly?)|(ne?))|Aug(ust)?|Oct(ober)?|(Sep(?=\b|t)t?|Nov|Dec)(ember)?|\d{2})-\d{2}\b");
                    foreach (Match m in regex5.Matches(text))
                    {
                             objdateStr.Add(text);
                    }

                    var regex11 = new Regex(@"\b\d{4}\/(JAN|FEB|MAR|MAY|APR|JUL|JUN|AUG|OCT|SEP|NOV|DEC|\d{2})/\d{2}\b");
                    foreach (Match m in regex11.Matches(text))
                    {
                        objdateStr.Add(text);
                    }
                    var regex6 = new Regex(@"^((31(?! (FEB|APR|JUN|SEP|NOV)))|((29)(?! FEB))|(29(?= FEB (((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])(-|/)(JAN|FEB|MAR|MAY|APR|JUL|JUN|AUG|OCT|SEP|NOV|DEC|\d{2})(-|/)((1[6-9]|[2-9]\d)\d{2}|\d{2})$");
                    foreach (Match m in regex6.Matches(text.ToUpper()))
                    {
                       // DateTime dt;
                       // if (DateTime.TryParseExact(m.Value, "DD-MMM-YYYY", null, DateTimeStyles.None, out dt))
                            objdateStr.Add(text);
                    }

               

                    
                    //Use the Parse() method
                    try
                    {                       
                        //dateTime = DateTime.Parse(text);
                        //hasDate = true;
                        //if (hasDate)
                        //{
                        //    objdateStr.Add(text);
                        //}
                       // break;//no need to execute/loop further if you have your date
                    }
                    catch (Exception ex)
                    {

                    }
                }

                objparseItem.TagsData = objTagsDictionary;
                objparseItem.UserData = matchedUsers;
                objparseItem.MatchedDates = objdateStr;

            }
            catch
            {
               // HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                //return response;
            }
            return objparseItem;

         }



        [HttpGet]
        public DataTable GetExcelData()//ContactInfo,FinanceInfo 
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            string FilePath = nvc["FilePath"].ToString();
            string SheetName = nvc["SheetName"].ToString();
            string AgainstType = nvc["AgainstType"].ToString();


            ExcelParser excelObj = new ExcelParser();
            DataSet dsXmlFields = excelObj.XmlColumnDefSynonym(AgainstType, ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ToString(), HttpContext.Current.Server.MapPath("~/CRMFiles/"));
            if (dsXmlFields.Tables.Count > 1)
            {
                DataTable dtExcel = excelObj.ExcelColumnDef(HttpContext.Current.Server.MapPath("~/CRMFiles/") + FilePath, true, SheetName);
                if (dtExcel.Rows.Count > 0)
                {
                    var queryRes = (from cs in dsXmlFields.Tables["Name"].AsEnumerable()
                                    join cs1 in dsXmlFields.Tables["Synonyms"].AsEnumerable() on cs["Field_Id"].ToString().ToLower().Trim() equals cs1["Field_Id"].ToString().ToLower().Trim()
                                    join cs2 in dsXmlFields.Tables["Synonym"].AsEnumerable() on cs1["Synonyms_Id"].ToString().ToLower().Trim() equals cs2["Synonyms_Id"].ToString().ToLower().Trim()
                                    join c in dtExcel.AsEnumerable() on cs["Name_Text"].ToString().ToLower().Trim() equals c["COLUMN_NAME"].ToString().ToLower().Trim()
                                    orderby Convert.ToInt32(cs["ColumnOrder"].ToString())
                                    select cs["Name_Text"]).Distinct().ToList();
                    return excelObj.GetSpecificColumnsValue(HttpContext.Current.Server.MapPath("~/CRMFiles/") + FilePath, true, SheetName, queryRes, "");
                }
                else
                {
                    return dtExcel;
                }
            }
            else
                return dsXmlFields.Tables[0];
        }
       

        //[HttpPut]
        //public HttpResponseMessage UpdateUser(int Id, User user)
        //{
        //    try
        //    {
        //        if (Id == user.UserId)
        //        {
        //            Context.Entry(user).State = EntityState.Modified;

        //            Context.SaveChanges();
        //            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Accepted);
        //            return response;
        //        }
        //        else
        //        {
        //            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        //            return response;
        //        }

        //    }
        //    catch
        //    {
        //        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
        //        return response;
        //    }
        //}

        //[HttpDelete]
        //public HttpResponseMessage DeleteUser(int Id)
        //{
        //    try
        //    {
        //        var data = Context.User.Find(Id);
        //        Context.User.Remove(data);
        //        Context.SaveChanges();
        //        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Accepted);
        //        return response;
        //    }
        //    catch
        //    {
        //        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
        //        return response;
        //    }
        //}

    }
}
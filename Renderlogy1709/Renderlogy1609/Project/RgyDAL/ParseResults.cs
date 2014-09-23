using System;
using System.Collections.Generic;
using System.Web;

namespace RgyDAL
{
    public class MessageDetails
    {
        public string From { get; set; }
        public DateTime ReceivedDate { get; set; }
        public List<MailIds> ToMailIds { get; set; }
        public List<MailIds> CCMailIds { get; set; }
        public List<MailIds> BccMailIds { get; set; }
        public SubjectDetail Subject { get; set; }
        public BodyDetail Body { get; set; }
        public List<Attachment> Attachments { get; set; }
    }

    public class SubjectDetail
    {
        public string recvSubject { get; set; }
        public ParseResults parseData { get; set; }
    }
    public class BodyDetail
    {
        public string recvBody { get; set; }
        public ParseResults parseData { get; set; }
    }
    public class Attachment
    {
        public string fileName { get; set; }
        public string fileType { get; set; }
        public ParseResults parseData { get; set; }
    }
    public class ParseResults
    {
       public List<TagsDictionary> TagsData { get; set; }
       public List<UsersData> UserData { get; set; }
       public List<string> MatchedDates { get; set; }          
    }
    public class MailIds
    {
        public string MailId { get; set; }               
    }
}
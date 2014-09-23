using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace RgyDAL
{

    [Table("mailsData")]
    public class mailsData
    {
        [Key]
        public int MessageId { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AttachFileName { get; set; }
        public DateTime EmailRecvDate { get; set; }


    }
}
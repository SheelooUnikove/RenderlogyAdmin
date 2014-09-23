using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RgyDAL
{
   [Table("TagsDictionary")]
    public class TagsDictionary
    {
        [Key]
        public int TagId { get; set; }
        public string TagTitle { get; set; }
        public string Action { get; set; }
        public string ActionAPI { get; set; }
       
    }
}
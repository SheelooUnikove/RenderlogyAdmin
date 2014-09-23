using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RgyDAL
{
    public class EngagementTypes
    {
        [Key]
        public int EngagementTypesId { get; set; }
        public string EngagementTitle { get; set; }
    }
}

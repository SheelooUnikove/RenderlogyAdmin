using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RgyDAL
{
    class Engagements
    {
        [Key]
        public int EngagementsID { get; set; }
        public string EngagementTitle { get; set; }
        public int EngagementTypeID { get; set; }
        public string CustID { get; set; }
        public string ProjectAdress { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }

        


    }
}

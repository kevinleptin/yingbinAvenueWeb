using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yingbinAvenueWeb.Models.dtos
{
    public class SurveyDto
    {
        public SurveyDto()
        {
            Subject2 = new List<int>();
        }
        public int Id { get; set; }
        public string UserLocalId { get; set; }
        public int Subject1 { get; set; }
        public List<int> Subject2 { get; private set; }
        public string Subject3 { get; set; }
        public string Subject4 { get; set; }
        public string Subject5 { get; set; }
        public string Subject6 { get; set; }
        public string Subject7 { get; set; }
    }
}
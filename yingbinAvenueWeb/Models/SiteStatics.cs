using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yingbinAvenueWeb.Models
{
    public class SiteStatics
    {
        [Key]
        public int ID { get; set; }

        public int Count { get; set; }
    }
}
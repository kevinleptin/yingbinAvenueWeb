using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace yingbinAvenueWeb.Models
{
    public class EntryForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string UserName { get; set; }

        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string MobiPhone { get; set; }
    }
}
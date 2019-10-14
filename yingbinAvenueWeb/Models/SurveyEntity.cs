using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace yingbinAvenueWeb.Models
{
    public class SurveyEntity
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string UserIp { get; set; }
        [MaxLength(50)]
        public string UserLocalId { get; set; }
        public int Subject1 { get; set; }

        [Required]
        [MaxLength(100)]
        public string Subject2 { get; set; }
        [MaxLength(1000)]
        public string Subject3 { get; set; }
        [MaxLength(1000)]
        public string Subject4 { get; set; }
        [MaxLength(1000)]
        public string Subject5 { get; set; }
        [MaxLength(1000)]
        public string Subject6 { get; set; }
        [MaxLength(1000)]
        public string Subject7 { get; set; }
    }
}
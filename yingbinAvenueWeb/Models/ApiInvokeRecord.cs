using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace yingbinAvenueWeb.Models
{
    public class ApiInvokeRecord
    {
        public ApiInvokeRecord()
        {
            CreateOn = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Path { get; set; }
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// IP Address
        /// </summary>
        [MaxLength(50)]
        public string CreateBy { get; set; }
    }
}
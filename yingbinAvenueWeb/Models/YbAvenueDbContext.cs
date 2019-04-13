using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace yingbinAvenueWeb.Models
{
    public class YbAvenueDbContext : DbContext
    {
        public YbAvenueDbContext() : base("defaultConnectionStr")
        {

        }
        public DbSet<EntryForm> EntryForms { get; set; }
        public DbSet<ApiInvokeRecord> ApiInvokeRecords { get; set; }
    }
}
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using yingbinAvenueWeb.Models;

namespace yingbinAvenueWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public FileResult Data(string token)
        {
            string expectToken = ConfigurationManager.AppSettings["token"];
            if(string.Compare(expectToken, token, true) != 0)
            {
                return new FileContentResult(Encoding.UTF8.GetBytes("无效的秘钥"), "text/plain; charset=utf-8");
            }
            YbAvenueDbContext context = new YbAvenueDbContext();
            var data = context.EntryForms.Select(c=>new { c.UserName, c.MobiPhone }).ToList();
            string filePath = Path.Combine(HttpContext.Server.MapPath("~/excel"), Guid.NewGuid() + ".xlsx");
            FileInfo fi = new FileInfo(filePath);
            using (ExcelPackage ep = new ExcelPackage(fi))
            {
                ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Info");
                ws.Cells["A1"].Value = "名称";
                ws.Cells["B1"].Value = "电话";

                ws.Cells["A2"].LoadFromCollection(data);
                ep.Save();
            }

            return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }
    }
}

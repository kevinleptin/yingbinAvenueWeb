﻿using Newtonsoft.Json;
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
            if (string.Compare(expectToken, token, true) != 0)
            {
                return new FileContentResult(Encoding.UTF8.GetBytes("无效的秘钥"), "text/plain; charset=utf-8");
            }
            YbAvenueDbContext context = new YbAvenueDbContext();
            var data = context.SurveyEntities.ToList();
            string fileExportPath = Path.Combine(HttpContext.Server.MapPath("~/excel"), Guid.NewGuid() + ".xlsx");
            FileInfo fiExport = new FileInfo(fileExportPath);

            string fileTemplatePath = Path.Combine(HttpContext.Server.MapPath("~/templates/bayerexp.xlsx"));
            FileInfo fi = new FileInfo(fileTemplatePath);
            using (ExcelPackage ep = new ExcelPackage(fi))
            {
                ExcelWorksheet ws = ep.Workbook.Worksheets["Sheet2"];
                int startRow = 3;
                for(int i = 0; i < data.Count; i++)
                {
                    int currentRowIndex = startRow + i;
                    var entity = data[i];
                    ws.Cells["A" + currentRowIndex].Value = (i+1).ToString();

                    string[] subject1Cols = new string[] { "Padding0", "B", "C", "D", "E" };
                    string subject1Colname = subject1Cols[entity.Subject1];
                    ws.Cells[subject1Colname + currentRowIndex].Value = "1";

                    string[] subject2Cols = new string[] { "Padding0", "F", "G", "H", "I", "J", "K", "L" };
                    List<int> lstSubject2Selected = JsonConvert.DeserializeObject<List<int>>(entity.Subject2);
                    for(int j = 0; j < lstSubject2Selected.Count; j++)
                    {
                        string colName = subject2Cols[lstSubject2Selected[j]];
                        ws.Cells[colName + currentRowIndex].Value = "1";
                    }

                    ws.Cells["M" + currentRowIndex].Value = entity.Subject3;
                    ws.Cells["N" + currentRowIndex].Value = entity.Subject4;
                    ws.Cells["O" + currentRowIndex].Value = entity.Subject5;
                    ws.Cells["P" + currentRowIndex].Value = entity.Subject6;
                    ws.Cells["Q" + currentRowIndex].Value = entity.Subject7;
                }
                ep.SaveAs(fiExport);
            }

            return File(fileExportPath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }

        public FileResult DataOld(string token)
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

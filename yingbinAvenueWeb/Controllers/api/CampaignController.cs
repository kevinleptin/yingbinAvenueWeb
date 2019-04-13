using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using yingbinAvenueWeb.Models;
using yingbinAvenueWeb.Models.dtos;

namespace yingbinAvenueWeb.Controllers.api
{
    public class CampaignController : ApiController
    {
        YbAvenueDbContext _context = null;
        public CampaignController()
        {
            _context = new YbAvenueDbContext();
        }
        /// <summary>
        /// TODO: Name需要转码一次
        /// 默认首页应该是index.html , 修改route
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]        
        public IHttpActionResult Join(EntryFormDto dto)
        {
            string userIp = GetHostAddress();
            ApiInvokeRecord record = new ApiInvokeRecord()
            {
                CreateBy = userIp,
                Path = "/api/Campaign/Join"
            };
            _context.ApiInvokeRecords.Add(record);
            _context.SaveChanges();

            EntryFormResultDto result = new EntryFormResultDto();
            result.ErrorCode = 200;
            result.Message = "参与成功";
            // #1. validate
            if(dto == null || string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Phone))
            {
                result.ErrorCode = 400;
                result.Message = "请填写姓名和电话";
                return Ok(result);
            }

            if(dto.Name.Length > 20 || dto.Phone.Length > 15)
            {
                result.ErrorCode = 401;
                result.Message = "姓名和电话长度过长";
                return Ok(result);
            }

            dto.Phone = dto.Phone.Trim();
            dto.Name = dto.Name.Trim();  //TODO: Name要转码
            if(!Regex.IsMatch(dto.Phone, @"^\d{8,14}$"))
            {
                result.ErrorCode = 402;
                result.Message = "电话格式错误，应该全部为数字。";
                return Ok(result);
            }
            // #2. map
            EntryForm form = new EntryForm()
            {
                CreateBy = userIp,
                MobiPhone = dto.Phone,
                UserName = dto.Name
            };

            // #3. save to db 
            _context.EntryForms.Add(form);
            _context.SaveChanges();

            // #4. return value
            return Ok(result);
        }

        public string GetHostAddress()
        {
            string userIP = "127.0.0.1";

            try
            {
                if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Request == null || System.Web.HttpContext.Current.Request.ServerVariables == null)
                    return "";

                string CustomerIP = "";

                //CDN加速后取到的IP 
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                }

                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }

            return userIP;
        }
    }
}

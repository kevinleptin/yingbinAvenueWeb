using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using yingbinAvenueWeb.Models;
using yingbinAvenueWeb.Models.dtos;

namespace yingbinAvenueWeb.Controllers.api
{
    public class CampaignController : ApiController
    {
        protected static object locker = new object();
        YbAvenueDbContext _context = null;
        public CampaignController()
        {
            _context = new YbAvenueDbContext();
        }

        private void IncreaseCounter()
        {
            lock (CampaignController.locker)
            {
                try
                {
                    var statics = _context.Statics.First();
                    statics.Count++;
                    _context.SaveChanges();
                }
                catch { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]     
        [Route("api/campaign/join")]
        public IHttpActionResult Join(EntryFormDto dto)
        {
            string userIp = GetHostAddress();
            try
            {
                IncreaseCounter();
            }
            catch { }

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

            dto.Name = HttpUtility.UrlDecode(dto.Name).Trim();
            if (dto.Name.Length > 200 || dto.Phone.Length > 15)
            {
                result.ErrorCode = 401;
                result.Message = "姓名和电话长度过长";
                return Ok(result);
            }

            dto.Phone = dto.Phone.Trim();
            
            if(!Regex.IsMatch(dto.Phone, @"^\d{8,14}$"))
            {
                result.ErrorCode = 402;
                result.Message = "电话格式错误，应该全部为数字。";
                return Ok(result);
            }

            // dup validation
            bool duplicate = _context.EntryForms.Any(c => c.MobiPhone == dto.Phone);
            if (duplicate)
            {
                result.ErrorCode = 403;
                result.Message = "电话号码已存在";
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
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                result.ErrorCode = 500;
                result.Message = "发生错误，请重试";
                return Ok(result);
            }

            // #4. return value
            return Ok(result);
        }

        [HttpPost]
        [Route("api/campaign/invokeCount")]
        public IHttpActionResult InvokeCount()
        {
            int cnt = 0;
            try
            {
                lock(CampaignController.locker){
                    cnt = _context.Statics.First().Count;
                }
            }
            catch { }
            return Ok(new { Count = cnt });
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

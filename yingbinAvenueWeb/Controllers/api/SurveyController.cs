using Newtonsoft.Json;
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
    public class SurveyController : ApiController
    {
        YbAvenueDbContext _context = null;
        public SurveyController()
        {
            _context = new YbAvenueDbContext();
        }

        [HttpPost]
        [Route("api/survey/submit")]
        public IHttpActionResult Submit(SurveyDto dto)
        {
            SurveyResultDto result = new SurveyResultDto();
            result.Code = 0;
            result.Msg = "提交成功";
            if(dto == null)
            {
                result.Code = 401;
                result.Msg = "输入错误";
                return Ok(result);
            }

            for(int i = dto.Subject2.Count - 1; i >= 0; i--)
            {
                if(!(dto.Subject2[i]>=1 && dto.Subject2[i] <= 7))
                {
                    dto.Subject2.RemoveAt(i);
                }
            }

            //string userIp = GetHostAddress();
            //string userLocalId = Guid.NewGuid().ToString();
            //if (string.IsNullOrEmpty(dto.UserLocalId))
            //{
            //    dto.UserLocalId = userLocalId;
            //}

            //check dto validation
            if(dto.Subject1 <= 0 || dto.Subject1 > 4)
            {
                result.Code = 402;
                result.Msg = "问题1请选择";
                return Ok(result);
            }

            if(dto.Subject2.Distinct().Count() < 3)
            {
                result.Code = 403;
                result.Msg = "问题2请选择3项";
                return Ok(result);
            }
            //TODO: check dup if it's enabled.

            //turn to entity and save to db
            SurveyEntity entity = new SurveyEntity();
            entity.Subject1 = dto.Subject1;
            entity.Subject2 = JsonConvert.SerializeObject(dto.Subject2.Distinct().ToList());
            entity.Subject3 = HttpUtility.UrlDecode(dto.Subject3??"").Trim();
            entity.Subject4 = HttpUtility.UrlDecode(dto.Subject4??"").Trim();
            entity.Subject5 = HttpUtility.UrlDecode(dto.Subject5??"").Trim();
            entity.Subject6 = HttpUtility.UrlDecode(dto.Subject6??"").Trim();
            entity.Subject7 = HttpUtility.UrlDecode(dto.Subject7??"").Trim();

            // #3. save to db 
            _context.SurveyEntities.Add(entity);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                result.Code = 500;
                result.Msg = "发生错误，请重试";
                return Ok(result);
            }

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
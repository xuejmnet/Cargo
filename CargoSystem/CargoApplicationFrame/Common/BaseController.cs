using Cargo.Core.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoApplicationFrame.Common
{
    public class BaseController : Controller
    {
        public string GetClientIp()
        {
            //可以透过代理服务器
            string userIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //判断是否有代理服务器
            if (string.IsNullOrEmpty(userIP))
            {
                //没有代理服务器,如果有代理服务器获取的是代理服务器的IP
                userIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return userIP;
        }

        public IGenresRepository GenresRepository { get; set; }

	}
}
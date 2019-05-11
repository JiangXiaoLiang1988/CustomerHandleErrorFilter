using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCuetomerExcepFilter.Extension
{
    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class ExceptionFilters : HandleErrorAttribute
    {
        /// <summary>
        /// 在异常发生时调用
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            // 判断是否已经处理过异常
            if(!filterContext.ExceptionHandled)
            {
                // 获取出现异常的controller和action名称，用于记录
                string strControllerName = filterContext.RouteData.Values["controller"].ToString();
                string strActionName = filterContext.RouteData.Values["action"].ToString();
                // 定义一个HandleErrorInfo,用于Error视图展示异常信息
                HandleErrorInfo info = new HandleErrorInfo(filterContext.Exception, strControllerName, strActionName);

                ViewResult result = new ViewResult
                {
                    ViewName = this.View,
                    // 定义ViewData，泛型
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(info)
                };
                // 设置操作结果
                filterContext.Result = result;
                // 设置已经处理过异常
                filterContext.ExceptionHandled = true;
            }
            //base.OnException(filterContext);
        }
    }
}
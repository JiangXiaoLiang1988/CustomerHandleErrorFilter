using MVCCuetomerExcepFilter.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCuetomerExcepFilter.Controllers
{
    public class ExceptionController : Controller
    {
        // GET: Exception
        /// <summary>
        /// View表示发生异常时指定的视图
        /// 这里表示发生异常时使用ExceptionDetails视图
        /// </summary>
        /// <returns></returns>
        [ExceptionFilters(View =("ExceptionDetails"))]
        public ActionResult Index()
        {
            // 测试抛出异常
            throw new NullReferenceException("测试抛出的异常");
        }
    }
}
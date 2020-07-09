using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wlkh.Filter.Filters
{
    /// <summary>
    /// 资源过滤器
    /// </summary>
    public class CustomerResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("==== OnResourceExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("==== OnResourceExecuting");
            //Console.ForegroundColor = ConsoleColor.Gray;


            Console.WriteLine("==== OnResourceExecuting");
            throw new Exception("资源管理器发生了异常");
        }
    }
}

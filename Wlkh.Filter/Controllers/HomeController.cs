using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wlkh.Filter.Filters;
using Wlkh.Filter.Models;

namespace Wlkh.Filter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [CustomerActionFilter]
        [CustomerResourceFilter]
        //可以看到，执行顺序和开篇的第一张图例一致，首先执行时资源过滤器的 OnResourceExecuting 方法，接着请求接入了 操作过滤器的 OnActionExecuting 方法，最后执行操作过滤器的 OnResultExecuting 方法，然后把请求交给资源过滤器的 OnResourceExecuted，最后返回到客户端
        //所以，从执行顺序可以看出，资源管理器的执行优先级总是高于操作过滤器
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values
        [HttpGet]
        [CustomerExceptionFilter]
        [Route("get1")]
        public ActionResult<IEnumerable<string>> Get1()
        {
            throw new Exception("Get1操作发生了异常");
        }


        // GET api/values/5
        [HttpGet("{id}")]
        [CustomerActionFilter]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [UserNameActionFilter(Order = 10)]
        [UserAgeActionFilter(Order = 5)]
        public void Post([FromBody] UserModel value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

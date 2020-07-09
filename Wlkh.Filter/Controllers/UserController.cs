﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wlkh.Filter.Filters;

namespace Wlkh.Filter.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [MiddlewareFilter(typeof(RegisterManagerPipeline))]
    public class UserController : Controller
    {
        // GET: api/<controller>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "default";
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

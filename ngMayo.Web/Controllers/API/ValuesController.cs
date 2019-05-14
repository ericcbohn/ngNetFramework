using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ngMayo.Web.Controllers.API
{
    public class ValuesController : BaseApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            throw new Exception("i broke in API");
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lec03.Controllers
{
    public class ValuesController : ApiController
    {

        string[] arr = new string[] {"value1", "value2", "value3", "value4", };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return arr;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return arr[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

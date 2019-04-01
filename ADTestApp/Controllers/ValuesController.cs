using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ADTestApp.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Manideep", "Kothapalli" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
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

        [HttpGet]
        [ActionName("MyNames")]
        public ActionResult<IEnumerable<string>> MyNames()
        {
            return new string[] { "Manideep", "Kothapalli" };
        }

        [HttpGet]
        [ActionName("ReceiveTokenAsync")]
        public async Task<string> ReceiveTokenAsync()
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>()
            {
                {"grant_type","password"},
                {"client_id","8a3f0769-6ee1-44b1-8ce9-202f8b7948fe"},
                {"username","mkothapalli@cardlytics.com"},
                {"password",""},
                {"scope","https://cardlytics.com/8a3f0769-6ee1-44b1-8ce9-202f8b7948fe/user_impersonation"},
                {"client_secret","C#X(#=a^(>Dsq[>e}j|/@]h/}}$l]5}e%${t{)^0;8-"}
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://login.microsoftonline.com/64b0287b-af0d-4307-ae82-febfb154a6e6/oauth2/v2.0/token", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var jsonresult = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
            return responseString;
        }
    }
}

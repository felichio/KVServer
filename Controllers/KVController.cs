using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.IO;

namespace kvServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KVController : ControllerBase
    {
        private readonly Trie _cache;

        public KVController(Trie cache)
        {
            _cache = cache;
            
        }

        [HttpPost]
        public async Task<ContentResult> Put()
        {
            
            
            
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                var text = await reader.ReadToEndAsync();
                
                
                P p = P.FromString(text);
                try
                {
                    _cache.insert(p);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
                return Content("OK");
            }
            
            
        }

        [HttpGet("service/alive")]
        public ContentResult GetEcho()
        {   
            return Content("UP");
        }
        

        [HttpGet("{key}")]
        public ContentResult Get(string key)
        {
            // P p = new P("hello", new CollectionV(){new P("felix", new ScalarV<string>("asd"))});
            // var response = this.Request.CreateResponse(HttpStatusCode.OK);
            // response.Content = new StringContent(p.ToJsonString(), Encoding.UTF8, "application/json");
            // return response;
            key = key[1..^1];
            V v = _cache.multigetV(key);
            if (v != null) return Content(v.ToString());
            else return Content("NOT FOUND");
            
            
        }

        [HttpDelete("{key}")]
        public ContentResult Delete(string key)
        {
            key = key[1..^1];
            _cache.delete(key);
            return Content("OK");
        }
    }
}

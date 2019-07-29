using System;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/heartbeat")]
    public class HeartbeatController : Controller
    {
        private class HeartBeat
        {
            [JsonProperty("entity")]
            public string Entity { get; set; }

            [JsonProperty("domain")] public string Domain { get; set; } = "domain";
                
            [JsonProperty("category")]
            public string Category { get; set; } = "designing";
            
            [JsonProperty("time")]
            public double Time { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();
            
            [JsonProperty("project")]
            public string Project { get; set; }
        }
        
        
        [Route("")]
        public async Task<IActionResult> Heartbeat(string entity, string project)
        {
            try
            {
                await "https://wakatime.com/api/v1/users/current/heartbeats"
                    .WithHeader("Authorization", $"Bearer {Settings.Token}")
                    .PostJsonAsync(new
                        HeartBeat
                        {
                            Entity = entity,
                            Project = project
                        });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok("sent heartbeat");
        }
    }
}
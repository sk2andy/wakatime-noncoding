using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private class AuthToken
        {
            [JsonProperty("access_token")] public string AccessToken { get; set; }
        }
        
        [Route("/auth")]
        public async Task<IActionResult> Auth(string code)
        {

            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id", "appid"},
                    {
                        "client_secret",
                        "secret"
                    },
                    {"redirect_uri", "http://localhost:5000/auth"},
                    {"grant_type", "authorization_code"},
                    {"code", code}
                }))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    var response = await httpClient.PostAsync("https://wakatime.com/oauth/token", content);

                    var result = await response.Content.ReadAsStringAsync();
                    Settings.Token = JsonConvert.DeserializeObject<AuthToken>(result).AccessToken;
                }
            }
            
            return Ok("Token" + Settings.Token);
        }
    }
}
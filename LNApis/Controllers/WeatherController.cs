using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsClass.Repos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace LNApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly GenericClass _genClass = new GenericClass();

        [HttpGet]
        public async Task<string> Get(float lat, float lon, DateTime? fecha)
        {
            List<Dictionary<string, object>> lTiempo = new List<Dictionary<string, object>>();

            string token = Request.Headers["X-LNApi-Token"];
            if (_genClass.ValidToken(token))
            {

                var _repositories = new GenericRepositories();

                try
                {

                    Dictionary<string, object> dicKeys = _repositories.GetKeys();

                    var client1 = new HttpClient();
                    var request1 = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://weatherbit-v1-mashape.p.rapidapi.com/forecast/daily?lat=" + lat.ToString().Replace(",", ".") + "&lon=" + lon.ToString().Replace(",", ".")),
                        Headers =
                  {
                        { "X-RapidAPI-Host", dicKeys["X-RapidAPI-Host"].ToString() },
                        { "X-RapidAPI-Key", dicKeys["X-RapidAPI-Key"].ToString() },
                   },
                    };
                    using (var response = await client1.SendAsync(request1))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(body)["data"];
                        foreach (var item in json)
                        {
                            if (!fecha.HasValue || fecha.Value.Date == ((DateTime)item["datetime"]).Date)
                            {
                                var dic = new Dictionary<string, object>();
                                dic.Add("fecha", item["datetime"]);
                                dic.Add("temp", item["temp"]);
                                dic.Add("min_temp", item["min_temp"]);
                                dic.Add("max_temp", item["max_temp"]);
                                dic.Add("icon", item["weather"]["icon"]);

                                lTiempo.Add(dic);
                            }
                        }


                    }

                    Response.StatusCode = (int)HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            return JsonConvert.SerializeObject(lTiempo);
        }
    }
}

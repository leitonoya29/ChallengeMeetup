using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsClass.Repos;
using System.Net;

namespace LNApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly GenericRepositories _userRepository = new GenericRepositories();
        private readonly GenericClass _genClass = new GenericClass();

        [HttpPost]
        public bool Post(Dictionary<string, int> _dic)
        {
            string token = Request.Headers["X-LNApi-Token"];
            int _perID = 0;
            int _meetID = 0;
            var ret = false;
            if (token != null && _genClass.ValidToken(token))
            {

                if (_dic != null && _dic.ContainsKey("PerID") && _dic.ContainsKey("MeetID") && _dic["PerID"] > 0 && _dic["MeetID"] > 0)
                {
                    _perID = _dic["PerID"];
                    _meetID = _dic["MeetID"];

                    ret = _userRepository.RegisterUserMeet(_perID, _meetID);
                    if (ret)
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            return ret;
        }
    }
}

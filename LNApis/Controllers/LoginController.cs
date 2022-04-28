using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Comu;
using ModelsClass.Model;
using ModelsClass.Repos;

namespace LNApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Criptografia _cripto = new Criptografia();
        private readonly GenericRepositories _userRepository = new GenericRepositories();


        [HttpGet]
        public string Get(string usuario, string password)
        {
            Dictionary<string, object> oLgn = new Dictionary<string, object>();
            Usuario _lg;

            if (_userRepository.Autorizado(usuario, _cripto.GetStringSha256(password)))
            {
                try
                {
                    _lg = _userRepository.GetUsuario(usuario, _cripto.GetStringSha256(password));
                    _lg.AuthUser = true;
                    _lg.Password = _cripto.Encrypt(_lg.Password);
                    oLgn.Add("mensaje", "Usuario logueado satisfactoriamente");
                    oLgn.Add("token", _cripto.Encrypt(JsonConvert.SerializeObject(_lg)));
                    Response.StatusCode = (int)HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                }
            }
            else
            {
                oLgn.Add("mensaje", "Credenciales incorrectas");
                oLgn.Add("token", "");

                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            return JsonConvert.SerializeObject(oLgn);
        }
    }
}

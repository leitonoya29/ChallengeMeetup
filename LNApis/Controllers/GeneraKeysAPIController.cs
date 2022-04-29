using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace LNApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneraKeysAPIController : ControllerBase
    {
        [HttpGet]
        public List<string> Get()
        {
            var _lKeys = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                var key = new byte[32];
                using (var generator = RandomNumberGenerator.Create())
                    generator.GetBytes(key);
                _lKeys.Add(Convert.ToBase64String(key));
            }

            return _lKeys;
        }
    }
}

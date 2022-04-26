using Newtonsoft.Json;

namespace ModelClass.Model
{
    public class Usuario
    {


        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("AuthUser")]
        public bool AuthUser { get; set; }
        [JsonProperty("AdminUser")]
        public bool AdminUser { get; set; }

        public Usuario()
        {


        }
    }
}

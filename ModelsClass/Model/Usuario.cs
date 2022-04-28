using Newtonsoft.Json;

namespace ModelsClass.Model
{

    public class Usuario
    {

        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("AuthUser")]
        public bool AuthUser { get; set; }
        [JsonProperty("AdminUser")]
        public bool AdminUser { get; set; }

        [JsonProperty("PerID")]
        public int PerID { get; set; }

        [JsonProperty("UserToken")]
        public string UserToken { get; set; }

        public Usuario() { }
    }

}

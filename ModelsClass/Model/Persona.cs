using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClass.Model
{
    public class Persona
    {
        [JsonProperty("PerID")]
        public int PerID { get; set; }

        [JsonProperty("PerNombres")]
        public string PerNombres { get; set; }
        [JsonProperty("PerApellido")]
        public string PerApellido { get; set; }
        [JsonProperty("PerMail")]
        public string PerMail { get; set; }
        
        public Persona() { }
    }
}

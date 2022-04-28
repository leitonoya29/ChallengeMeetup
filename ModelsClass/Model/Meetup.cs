using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ModelsClass.Model
{
    public class Meetup
    {
        [JsonProperty("MeetID")]
        public int MeetID { get; set; }
        [JsonProperty("MeetFecha")]
        public DateTime MeetFecha { get; set; }
        [JsonProperty("MeetNombre")]
        public string MeetNombre { get; set; }
        [JsonProperty("MeetDesc")]
        public string MeetDesc { get; set; }
        [JsonProperty("MeetDireccion")]
        public string MeetDireccion { get; set; }
        [JsonProperty("MeetLat")]
        public float MeetLat { get; set; }
        [JsonProperty("MeetLon")]
        public float MeetLon { get; set; }
        [JsonProperty("LPer")]
        public List<int> LPer { get; set; }
        [JsonProperty("LPerConfirm")]
        public List<int> LPerConfirm { get; set; }

        public Meetup()
        {
            LPer = new List<int>();
            LPerConfirm = new List<int>();
        }
    }
}

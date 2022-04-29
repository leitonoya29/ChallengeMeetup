using ModelsClass.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModelsClass.Repos
{
    public class GenericRepositories
    {
    
        public Dictionary<string, object> GetKeys()
        {
            List<Dictionary<string, object>> lKeys = new List<Dictionary<string, object>>();
            try
            {
                string jstring = File.ReadAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\Keys.json");

                lKeys = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JsonConvert.SerializeObject(JObject.Parse(jstring)["Keys"]));
            }
            catch (Exception ex)
            {

            }
            return lKeys[0];
        }

        public List<string> GetValidKeys()
        {
            List<string> lKeys = new List<string>();
            try
            {
                string jstring = File.ReadAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\ValidKeys.json");

                lKeys = JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(JObject.Parse(jstring)["ValidKeys"]));
            }
            catch (Exception ex)
            {

            }
            return lKeys;
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> _lUsers = new List<Usuario>();
            try
            {
                string jstring = File.ReadAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\Usuarios.json");

                _lUsers = JsonConvert.DeserializeObject<List<Usuario>>(jstring);
            }
            catch (Exception ex)
            {
            }

            return _lUsers;
        }

        public Usuario GetUsuario(string nombre, string password)
        {
            Usuario usr = GetUsuarios().FirstOrDefault(u => u.UserName.ToLower() == nombre.ToLower() && u.Password == password);

            return usr;
        }

        public bool Autorizado(string nombre, string password)
        {
            Usuario usr = GetUsuarios().FirstOrDefault(u => u.UserName.ToLower() == nombre.ToLower() && u.Password == password);

            return usr != null;
        }
  
        public List<Persona> GetPersonas()
        {
            List<Persona> lPer = new List<Persona>();
            try
            {
                string jstring = File.ReadAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\Personas.json");

                lPer = JsonConvert.DeserializeObject<List<Persona>>(JsonConvert.SerializeObject(JObject.Parse(jstring)["personas"]));
            }
            catch (Exception ex)
            {
            }
            return lPer;
        }
     
        public Persona GetPersona(int id)
        {
            Persona _per = GetPersonas().FirstOrDefault(p => p.PerID == id);

            return _per;
        }

        public List<Meetup> GetMeetups()
        {
            List<Meetup> lMeet = new List<Meetup>();
            try
            {
                string jstring = File.ReadAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\Meetups.json");

                lMeet = JsonConvert.DeserializeObject<List<Meetup>>(jstring);
            }
            catch (Exception ex)
            {
            }
            return lMeet.OrderBy(x => x.MeetFecha).ToList();
        }

        public Meetup GetMeetup(int id)
        {
            Meetup lMeet = null;

            try
            {
                lMeet = GetMeetups().FirstOrDefault(m => m.MeetID == id);

            }
            catch (Exception ex)
            {
            }
            return lMeet;
        }

        public Meetup addMeetup(Meetup _meet)
        {
            List<Meetup> _lMeets = GetMeetups();

            _meet.MeetID = 1;

            if (_lMeets.Count > 0)
            {
                _lMeets = _lMeets.OrderBy(x => x.MeetID).ToList();
                _meet.MeetID = _lMeets.Last<Meetup>().MeetID + 1;
            }

            _lMeets.Add(_meet);

            try
            {
                File.WriteAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\Meetups.json", JsonConvert.SerializeObject(_lMeets));
            }
            catch (IOException ex)
            {
                _meet = null;
            }

            return _meet;
        }
       
        public bool RegisterUserMeet(int idPer, int idMeet)
        {
            Meetup _meet = null;
            List<Meetup> _lMeet = null;
            Persona _per = null;
            bool ret = false;

            _lMeet = GetMeetups();
            _meet = _lMeet.FirstOrDefault(m => m.MeetID == idMeet);
            _per = GetPersona(idPer);

            try
            {
                if (_meet != null && _per != null && !_meet.LPer.Contains(idPer))
                {
                    _meet.LPer.Add(idPer);
                    File.WriteAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\Meetups.json", JsonConvert.SerializeObject(_lMeet));

                    ret = true;
                }
            }
            catch (Exception ex)
            {
            }

            return ret;
        }

        public bool CheckInUserMeet(int idPer, int idMeet)
        {
            Meetup _meet = null;
            List<Meetup> _lMeet = null;
            Persona _per = null;
            bool ret = false;

            _lMeet = GetMeetups();
            _meet = _lMeet.FirstOrDefault(m => m.MeetID == idMeet);
            _per = GetPersona(idPer);

            try
            {
                if (_meet != null && _per != null && _meet.LPer.Contains(idPer) && !_meet.LPerConfirm.Contains(idPer))
                {
                    _meet.LPerConfirm.Add(idPer);
                    File.WriteAllText(@"C:\Users\Leandro\source\repos\ChallengeMeetup\ModelsClass\Datos\Meetups.json", JsonConvert.SerializeObject(_lMeet));

                    ret = true;
                }
            }
            catch (Exception ex)
            {
            }

            return ret;
        }

    }
}

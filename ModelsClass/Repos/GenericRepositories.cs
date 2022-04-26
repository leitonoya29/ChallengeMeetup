using ModelsClass.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModelsClass.Repos
{
    public class GenericRepositories
    {
        public List<Usuario> GetUsuarios()
        {

            return new List<Usuario>
            {
                new Usuario(){ UserID=1, UserName = "leandro",Password = "7c797267692e79c2dc513c8ca6b757d153617013a46ddbd69c21e74237d3c007", AdminUser = true, PerID=1 },
                new Usuario(){ UserID=2,UserName = "santander",Password = "138df632fd0de2067dfcd75b6dbc543d8d66da31a79a39358216aa6ef63ad437", AdminUser = false, PerID=2 }
            };
        }

        public bool Autorizado(string nombre, string password)
        {
            Usuario usr = GetUsuarios().FirstOrDefault(u => u.UserName.ToLower() == nombre.ToLower() && u.Password == password);

            return usr != null;
        }

        public Usuario GetUsuario(string nombre, string password)
        {
            Usuario usr = GetUsuarios().FirstOrDefault(u => u.UserName.ToLower() == nombre.ToLower() && u.Password == password);

            return usr;
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
        public Meetup addMeetup(Meetup _meet)
        {
            try
            {
                List<Meetup> _lMeets = GetMeetups();

                if (_lMeets.Count > 0)
                {
                    _lMeets = _lMeets.OrderBy(x => x.MeetID).ToList();
                    _meet.MeetID = _lMeets.Last<Meetup>().MeetID + 1;
                }
                else
                {
                    _meet.MeetID = 1;
                }

                _lMeets.Add(_meet);

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
            Meetup  _meet = null;
            List<Meetup> _lMeet = null;
            bool ret = false;
            try
            {
                _lMeet = GetMeetups();
                _meet = _lMeet.FirstOrDefault(m => m.MeetID == idMeet);
                if (_meet != null && !_meet.LPer.Contains(idPer))
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
            bool ret = false;
            try
            {
                _lMeet = GetMeetups();
                _meet = _lMeet.FirstOrDefault(m => m.MeetID == idMeet);
                if (_meet != null && _meet.LPer.Contains(idPer) && !_meet.LPerConfirm.Contains(idPer))
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

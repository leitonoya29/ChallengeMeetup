using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsClass.Model;
using ModelsClass.Repos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace LNApis.Controllers
{



    [ApiController]
    public class MeetupsController : ControllerBase
    {
        private readonly GenericRepositories _userRepository = new GenericRepositories();
        private readonly GenericClass _genClass = new GenericClass();


        [Route("api/[controller]/{id}")]
        [HttpGet]
        public Meetup Get(int id)
        {
            string token = Request.Headers["X-LNApi-Token"];
            Meetup _meet = null;
            if (_genClass.ValidToken(token))
            {
                try
                {

                    _meet = _userRepository.GetMeetup(id);
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

            return _meet;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public List<Meetup> Get()
        {
            List<Meetup> lMeet = null;
            string token = Request.Headers["X-LNApi-Token"];

            if (_genClass.ValidToken(token))
            {
                try
                {
                    lMeet = _userRepository.GetMeetups();
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

            return lMeet;
        }

        [Route("api/[controller]")]
        [HttpPost]
        public Meetup Post(Meetup _meet)
        {
            string token = Request.Headers["X-LNApi-Token"];

            if (_genClass.ValidToken(token))
            {
                try
                {
                    if (_meet == null)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        _meet = _userRepository.addMeetup(_meet);
                        if (_meet != null)
                        {
                            try
                            {

                            string subject = "Nueva meetup " + _meet.MeetNombre + " el dia " + _meet.MeetFecha.ToString("dd/MM/yyyy") + " a las " + _meet.MeetFecha.ToString("HH:mm");
                            string body = "No olvides registrarte a la nueva meetup " + _meet.MeetNombre + " el dia " + _meet.MeetFecha.ToString("dd/MM/yyyy") + " a las " + _meet.MeetFecha.ToString("HH:mm");
                            List<string> _lMails = _genClass.GetListaMailsUsuarios();
                            _genClass.SendMails(_lMails,subject,body);

                            }
                            catch (Exception ex)
                            {

                            }

                            Response.StatusCode = (int)HttpStatusCode.Created;
                        }
                    }
                }
                catch (Exception)
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            return _meet;
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsClass.Model;
using ModelsClass.Repos;
using Newtonsoft.Json;
using System.Net;

namespace LNApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly GenericRepositories _userRepository = new GenericRepositories();
        private readonly GenericClass _genClass = new GenericClass();

        [HttpGet]
        public async Task<string> Get()
        {
            List<Persona> lPer = null;

            string token = Request.Headers["X-LNApi-Token"];

            if (_genClass.ValidToken(token))
            {
                try { 
                _userRepository.GetPersonas();
                    Response.StatusCode = (int)HttpStatusCode.OK;
                }
                catch(Exception ex) {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return JsonConvert.SerializeObject(lPer);
        }


    }
}

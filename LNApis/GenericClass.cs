using Comu;
using ModelsClass.Model;
using ModelsClass.Repos;
using Newtonsoft.Json;
using System.Net.Mail;

namespace LNApis
{
    public class GenericClass
    {

        private readonly GenericRepositories _userRepository = new GenericRepositories();

        public bool ValidToken(string t)
        {
            bool Auth = false;
            Criptografia _cripto = new Criptografia();

            try
            {
                var _lKeys = _userRepository.GetValidKeys();


                Auth = _lKeys.Contains(t);

            }
            catch (Exception ex)
            {

            }

            return Auth;
        }

        public List<string> GetListaMailsUsuarios()
        {
            List<string> _mails = new List<string>();
            var _repositories = new GenericRepositories();
            List<Persona> _lPer = _repositories.GetPersonas();

            foreach (Persona p in _lPer)
            {
                _mails.Add(p.PerMail);
            }

            return _mails;
        }

        public void SendMails(List<string> _mails, string subject, string body)
        {
            var _repositories = new GenericRepositories();
            Dictionary<string, object> dicKeys = _repositories.GetKeys();

            try
            {
                var message = new MailMessage();
                var emailClient = new SmtpClient();

                foreach (var elem in _mails)
                {
                    if (elem.ToString().IndexOf("@") > 0)
                    {
                        message.To.Add(new MailAddress(elem));
                    }
                }

                message.From = new System.Net.Mail.MailAddress(dicKeys["Cuenta"].ToString(), dicKeys["NombreCompleto"].ToString());
                message.Bcc.Add(dicKeys["Cuenta"].ToString());
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;

                emailClient.Host = dicKeys["Servidor"].ToString();
                emailClient.Port = int.Parse(dicKeys["Puerto"].ToString());
                emailClient.Timeout = 120000;
                emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                emailClient.EnableSsl = bool.Parse(dicKeys["SSL"].ToString().ToLower());
                emailClient.UseDefaultCredentials = bool.Parse(dicKeys["autenticacion"].ToString().ToLower());
                emailClient.Credentials = new System.Net.NetworkCredential(dicKeys["User"].ToString(), dicKeys["Pass"].ToString());
                emailClient.Send(message);

                emailClient.Dispose();
                message.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

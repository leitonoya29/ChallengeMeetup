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

                var user = JsonConvert.DeserializeObject<Usuario>(_cripto.Decrypt(t));

                Auth = _userRepository.Autorizado(user.UserName, _cripto.Decrypt(user.Password));

            }
            catch (Exception ex)
            {

            }

            return Auth;
        }
        public void SendMails(List<string> _mails, string subject, string body)
        {
            try
            {
                var _repositories = new GenericRepositories();
                Dictionary<string, object> dicKeys = _repositories.GetKeys();

                var message = new System.Net.Mail.MailMessage();
                var emailClient = new System.Net.Mail.SmtpClient();

                // Detalle del mail
                foreach (var elem in _mails)
                {
                    if (elem.ToString().IndexOf("@") > 0)
                    {
                        message.To.Add(new System.Net.Mail.MailAddress(elem));
                    }
                }

                message.From = new System.Net.Mail.MailAddress(dicKeys["Cuenta"].ToString(), dicKeys["NombreCompleto"].ToString());
                message.Bcc.Add(dicKeys["Cuenta"].ToString());
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.Priority = System.Net.Mail.MailPriority.High;

                // Detalle del servidor
                emailClient.Host = dicKeys["Servidor"].ToString();
                emailClient.Port = int.Parse(dicKeys["Puerto"].ToString());
                emailClient.Timeout = 120000;
                emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                emailClient.EnableSsl = bool.Parse(dicKeys["SSL"].ToString().ToLower());
                emailClient.UseDefaultCredentials = bool.Parse(dicKeys["autenticacion"].ToString().ToLower());
                var SMTPUserInfo = new System.Net.NetworkCredential(dicKeys["User"].ToString(), dicKeys["Pass"].ToString());
                emailClient.Credentials = SMTPUserInfo;
                emailClient.Send(message);
                emailClient.Dispose();
                message.Dispose();
            }
            catch (Exception ex)
            {

            }

        }

        public List<string> GetListaMailsUsuarios()
        {
            List<string> _mails = new List<string>();
            var _repositories = new GenericRepositories();
            List<Persona> _lPer = _repositories.GetPersonas();

            foreach(Persona p in _lPer)
            {
                _mails.Add(p.PerMail);

            }

            return _mails;
        }
    }


}

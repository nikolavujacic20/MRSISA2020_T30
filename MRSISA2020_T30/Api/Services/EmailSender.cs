using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Api.Dto;
using Microsoft.Extensions.Options;

namespace Api.Services
{
    public interface IEmailSender
    {
        void SendEmailAsync(string email, string subject, string message);
    }
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

        }
        public void SendEmailAsync(string email, string subject, string message)
        {
            var from = _smtpSettings.FromAddress;
            //other logic
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                {
                    MailAddress to = new MailAddress(email);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("nikolavujacic20@gmail.com", "lifeisgood1996");


                    client.Send(new MailMessage(to,to) {Subject=subject,Body=message });
                
                }
            }
            return ;
        }
    }
}

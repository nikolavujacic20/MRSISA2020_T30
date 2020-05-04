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
            
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                {
                    MailAddress to = new MailAddress(email);
                    MailAddress to1 = new MailAddress("savo.vujacic42@gmail.com");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("nikolavujacic20@gmail.com", "lifeisgood1996");


                    client.Send(new MailMessage(to,to1) {Subject=subject,Body=message });
                
                }
            }
            return ;
        }
    }
}

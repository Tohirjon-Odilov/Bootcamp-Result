using Login.EmailSender.Domain.Entity;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Login.EmailSender.Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private int _createCode = new int();
        public string _userEmail = String.Empty;
        public string _userPassword = String.Empty;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SignUp(SignUpModel model)
        {
            //var emailSettings = _config.GetSection("EmailSettings");

            _userEmail = model.Email;
            _userPassword = model.Password;
        }

        public async Task LogIn(LogInModel model, string path)
        {
            _createCode = new Random().Next(1000, 9999);

            //using (var stream = new StreamReader(path))
            //{
            //    model.Body = await stream.ReadToEndAsync();
            //}

            var emailSettings = _config.GetSection("EmailSettings");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"]!, emailSettings["SenderName"]),
                Subject = model.Password,
                Body = @$"<h1>Assalomu alaykum</h1> <h2>Hurmatli mijoz!</h2><h3>Sizning kodingiz: <code>{_createCode} </code></h3><p>Sizning passwordingiz: {model.Password} </p><p>Sizning emailingiz: {model.Email}>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(model.Email);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]!))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };

            //smtpClient.UseDefaultCredentials = true;

            await smtpClient.SendMailAsync(mailMessage);
        }

        public string CheckSendedCode(CheckSendedCode model)
        {
            if (_createCode == Convert.ToInt32(model.SendedCode))
            {
                return "Login successfully";
            }
            return "Invalid password";
        }
    }
}

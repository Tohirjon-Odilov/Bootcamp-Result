using Login.EmailSender.Application.DataTransferObject;
using Login.EmailSender.Domain.Entity;
using Login.EmailSender.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Login.EmailSender.Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private int _createCode = new int();

        public EmailService(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task SignUp(SignUpDTO model)
        {
            if (await _context.UserDatas.AnyAsync(x => x.Email == model.Email))
            {
                throw new Exception("Email already exists");
            }
            else if (model.Password != model.ConfirmPassword)
            {
                throw new Exception("Passwords do not match");
            }

            var newModel = new UserData()
            {
                Email = model.Email,
                Password = model.Password,
            };

            await _context.UserDatas.AddAsync(newModel);
            await _context.SaveChangesAsync();
        }

        public async Task LogIn(LoginDTO model, string path)
        {
            _createCode = new Random().Next(1000, 9999);

            UserData? data = await _context.UserDatas
                .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (data.VerificationPassword != null)
            {
                throw new Exception("It mustn't be an empty row");
            }

            var emailSettings = _config.GetSection("EmailSettings");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"]!, emailSettings["SenderName"]),
                Subject = _createCode.ToString(),
                Body = @$"<h1>Assalomu alaykum, <br/>Hurmatli mijoz!</h1> <h3>Sizning kodingiz: <code style='color: green'>{_createCode} </code></h3><p>Sizning passwordingiz: {model.Password} </p><p>Sizning emailingiz: {model.Email}>",
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

            smtpClient.UseDefaultCredentials = true;

            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task<string> CheckSendedCode(LoginDTO model)
        {
            if (await _context.UserDatas.AnyAsync(x => x.VerificationPassword == model.Password))
            {
                return "Success";
            }
            throw new Exception("Code is incorrect!");
        }
    }
}

using Login.EmailSender.Domain.Entity;

namespace Login.EmailSender.Application.Services.EmailService
{
    public interface IEmailService
    {
        public Task SignUp(SignUpModel model);
        public Task LogIn(LogInModel model, string path);
        public string CheckSendedCode(CheckSendedCode model);
    }
}

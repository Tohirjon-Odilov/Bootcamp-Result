using Login.EmailSender.Application.DataTransferObject;

namespace Login.EmailSender.Application.Services.EmailService
{
    public interface IEmailService
    {
        public Task SignUp(SignUpDTO model);
        public Task LogIn(LoginDTO model, string path);
        public Task<string> CheckSendedCode(LoginDTO model);
    }
}

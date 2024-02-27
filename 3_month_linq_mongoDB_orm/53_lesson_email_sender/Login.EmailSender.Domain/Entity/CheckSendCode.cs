namespace Login.EmailSender.Domain.Entity
{
    public class CheckSendedCode
    {
        public int Id { get; set; }
        public required int SendedCode { get; set; }
    }
}

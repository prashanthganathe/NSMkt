namespace NSMkt.Services.Interface
{
    public interface IEmailService
    {
        public Task<string> SendEmail(string subject, string Message, string To, string cc, string bcc);
    }
}

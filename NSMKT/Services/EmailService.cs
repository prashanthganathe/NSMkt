using System.Net.Mail;

namespace NSMkt.Services
{
    public class EmailService: IEmailService
    {

        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
          _config = config;
        }


        private const string username = "mediaganathe@gmail.com";
        private const string password  = "wfdzecdydfpeakth";// "gbcuffeevvhbqrce";
        private const string From = "mediaganathe@gmail.com";
        private const string Host = "smtp.gmail.com";
        public string Name { get; set; }       
        public List<string> Bcc { get; set; } 
        public List<string> Attachments { get; set; }
      


        public async Task<string> SendEmail(string subject,string Message, string To, string cc,string bcc)//string Name, string ToEmailID,string subject, string Message)
        {
            try
            {                
                var mail = new MailMessage()
                {
                    From = new MailAddress(username),
                    Subject = subject,
                    Body = Message,
                    IsBodyHtml = true

                };
                mail.IsBodyHtml = true;

                if (string.IsNullOrEmpty(To))
                {                   
                    mail.To.Add(new MailAddress("sceptertrade@gmail.com"));
                    var premium = _config.GetSection("EmailList").GetSection("PremiumEmails").Value;
                    if (!string.IsNullOrEmpty(premium))
                    {

                    }
                }
                if(!string.IsNullOrEmpty(cc))
                {
                    try
                    {
                        var cclist = cc.Split(",");
                        foreach (var c in cclist)
                        {
                            mail.CC.Add(new MailAddress(c));
                        }
                    }
                    catch { }
                }
                if (!string.IsNullOrEmpty(bcc))
                {
                    try
                    {
                        var bcclist = bcc.Split(",");
                        foreach (var b in bcclist)
                        {
                            mail.Bcc.Add(new MailAddress(b));
                        }
                    }
                    catch {}
                }           

                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = Host,//"smtp.gmail.com",
                    EnableSsl = true,

                };

                if (mail.Body != "")
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;                   
                    client.Credentials = new NetworkCredential(username, password);
                    client.Send(mail); //turn on less secure apps https://myaccount.google.com/lesssecureapps
                    Console.WriteLine("Email: " + Name + " has been sent to " + string.Join(",", To));
                    return "Email Sent Successfully!";
                }
                else
                    return "";
            }
            catch (SmtpException e)
            {
                return e.Message;
            }
            catch (System.Exception e)
            {
                return e.Message;
            }
        }
    }
}

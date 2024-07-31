using System;
using System.Net;
using System.Net.Mail;

public static class EmailManager
{
    public static void  SendEmail(string recipientEmail, string subject, string body)
    {
        var fromAddress = new MailAddress("msungur33@gmail.com", "Zungur");
        var toAddress = new MailAddress(recipientEmail);
        const string fromPassword = "swbdsxoilwcaetjy";  // Gmail uygulama şifresi
        const string smtpHost = "smtp.gmail.com";
        
        var smtp = new SmtpClient
        {
            Host = smtpHost,
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }
}


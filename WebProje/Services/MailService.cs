using MailKit.Net.Smtp;
using MimeKit;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class MailService : IMailService
{
    public void Gonder(Mail mail)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("Eren Ali Restoran", "YOUR MAIL ADDRESS");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = mail.Body; ;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject=mail.Subject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("YOUR MAIL ADDRESS", "YOUR KEY ");

        client.Send(mimeMessage);
        client.Disconnect(true);
    }

    public void RezervasyonMailGonder(Rezervasyon rezervasyon)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("Eren Ali Restoran Rezervasyon", "YOUR MAIL ADDRESS");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", rezervasyon.Mail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody =$"Merhaba {rezervasyon.Name}  \n \n \n{rezervasyon.Date} Tarihli Rezervasyon Talebiniz Onaylanmıştır. \n \n Sizleri Görmek İçin Sabırsızlanıyoruz:) \n \n Görüşmek Üzere...";
        
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject="Rezervasyon Talebiniz";

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("YOUR MAIL ADDRESS", "YOUR KEY");

        client.Send(mimeMessage);
        client.Disconnect(true);
    }
}

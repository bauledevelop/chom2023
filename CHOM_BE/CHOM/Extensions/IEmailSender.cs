namespace CHOM.Extensions
{
    public interface IEmailSender
    {
        Task<bool> SendMail(MailContent mailContent);

    }
}

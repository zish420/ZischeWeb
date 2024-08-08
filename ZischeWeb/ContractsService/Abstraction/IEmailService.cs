namespace ZischeWeb.ContractsService.Abstraction
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string email);
    }

}

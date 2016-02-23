namespace SofiaToday.Services.Data.Contracts
{
    using SofiaToday.Data.Models;

    public interface IMessagesService
    {
        void Add(Message message);

        void SaveChanges();
    }
}

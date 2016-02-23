namespace SofiaToday.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using SofiaToday.Data.Common;
    using SofiaToday.Data.Models;

    public class MessagesService : IMessagesService
    {
        private readonly IDbRepository<Message> messages;

        public MessagesService(IDbRepository<Message> messages)
        {
            this.messages = messages;
        }

        public void Add(Message message)
        {
            this.messages.Add(message);
            this.messages.Save();
        }

        public void SaveChanges()
        {
            this.messages.Save();
        }
    }
}

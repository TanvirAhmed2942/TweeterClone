using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TwitterCloneDbContext _dbContext;

        public MessageRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Message AddMessage(Message message)
        {
            _dbContext.Messages.Add(message);

            return message;
        }

        public Message UpdateMessage(Message message)
        {
            _dbContext.Messages.Remove(message);
            _dbContext.Messages.Add(message);
            return message;
        }

        public bool DeleteMessage(Message message)
        {
            _dbContext.Messages.Remove(message);
            return true;
        }

        // Removes the messages the user sent as well as the ones they received.
        public int DeleteMessagesByUserId(Guid userId)
        {
            var messages = _dbContext.Messages.Where(m => m.SenderId == userId || m.ReceiverId == userId);
            _dbContext.Messages.RemoveRange(messages);
            return messages.Count();
        }

        public Message? GetMessageById(Guid id)
        {
            return _dbContext.Messages.SingleOrDefault(m => m.Id == id);
        }

        public List<Message> GetMessages(Guid? senderId, Guid? receiverId)
        {
            return _dbContext.Messages
                .Where(m => (senderId == null || m.SenderId == senderId) &&
                            (receiverId == null || m.ReceiverId == receiverId))
                .ToList();
        }

        public List<Message> GetConversation(Guid userId, Guid otherUserId)
        {
            return _dbContext.Messages
                .Where(m => (m.SenderId == userId && m.ReceiverId == otherUserId) ||
                            (m.SenderId == otherUserId && m.ReceiverId == userId))
                .ToList();
        }
    }
}

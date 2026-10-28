using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;
namespace TwitterClone.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessageService(
            IMessageRepository messageRepository,
            IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public MessageDto? SendMessage(CreateMessageDto createMessageDto)
        {
            if (createMessageDto == null ||
                createMessageDto.Content == null ||
                string.IsNullOrWhiteSpace(createMessageDto.Content.Text))
            {
                return null;
            }

            // Nobody messages themselves.
            if (createMessageDto.SenderId == createMessageDto.ReceiverId)
            {
                return null;
            }

            if (_userRepository.FetchUserById(createMessageDto.SenderId) == null ||
                _userRepository.FetchUserById(createMessageDto.ReceiverId) == null)
            {
                return null;
            }

            var content = new MessageContent(
                createMessageDto.Content.Text.Trim(),
                createMessageDto.Content.ImageUrl
            );

            var sentMessage = _messageRepository.AddMessage(
                new Message(
                    createMessageDto.SenderId,
                    createMessageDto.ReceiverId,
                    content,
                    DateTime.UtcNow,
                    false
                )
            );

            return sentMessage.ToDto();
        }

        public MessageDto? GetMessageById(Guid id)
        {
            var message = _messageRepository.GetMessageById(id);

            return message?.ToDto();
        }

        public List<MessageDto> GetMessages(Guid? senderId, Guid? receiverId)
        {
            return _messageRepository.GetMessages(senderId, receiverId)
                .OrderByDescending(m => m.SentAt)
                .Select(m => m.ToDto())
                .ToList();
        }

        public List<MessageDto> GetConversation(Guid userId, Guid otherUserId)
        {
            // Oldest first, so the conversation reads top to bottom.
            return _messageRepository.GetConversation(userId, otherUserId)
                .OrderBy(m => m.SentAt)
                .Select(m => m.ToDto())
                .ToList();
        }

        public MessageDto? UpdateMessage(Guid id, UpdateMessageDto updateMessageDto)
        {
            if (updateMessageDto == null ||
                updateMessageDto.Content == null ||
                string.IsNullOrWhiteSpace(updateMessageDto.Content.Text))
            {
                return null;
            }

            var message = _messageRepository.GetMessageById(id);

            if (message == null)
            {
                return null;
            }

            var updatedContent = new MessageContent(
                updateMessageDto.Content.Text.Trim(),
                updateMessageDto.Content.ImageUrl
            );

            message.UpdateContent(updatedContent);
            message.MarkAsModified();

            _messageRepository.UpdateMessage(message);

            return message.ToDto();
        }

        public MessageDto? MarkMessageAsRead(Guid id)
        {
            var message = _messageRepository.GetMessageById(id);

            if (message == null)
            {
                return null;
            }

            if (!message.IsRead)
            {
                message.IsRead = true;
                message.MarkAsModified();

                _messageRepository.UpdateMessage(message);
            }

            return message.ToDto();
        }

        public bool DeleteMessage(Guid id)
        {
            var message = _messageRepository.GetMessageById(id);

            if (message == null)
            {
                return false;
            }

            return _messageRepository.DeleteMessage(message);
        }
    }
}

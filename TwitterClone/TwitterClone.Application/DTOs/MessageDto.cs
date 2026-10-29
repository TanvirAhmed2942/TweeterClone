using System.ComponentModel.DataAnnotations;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.DTOs
{
    public class MessageDto
    {
        public required Guid Id { get; set; }
        public required Guid SenderId { get; set; }
        public required Guid ReceiverId { get; set; }
        public required MessageContent Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class CreateMessageDto
    {
        public required Guid SenderId { get; set; }

        public required Guid ReceiverId { get; set; }

        [Required]
        [StringLength(1000)]
        public required MessageContent Content { get; set; }
    }

    public class UpdateMessageDto
    {
        [Required]
        [StringLength(1000)]
        public required MessageContent Content { get; set; }
    }
}

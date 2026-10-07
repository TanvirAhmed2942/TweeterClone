using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.DTOs
{
    public class CreateTweetDto
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = "";

    }
}

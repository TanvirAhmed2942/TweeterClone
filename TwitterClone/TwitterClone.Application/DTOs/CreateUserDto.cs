using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.DTOs
{
    //public class CreateUserDto
    //{
    //    public string FirstName { get; set; } = "";
    //    public string LastName { get; set; } = "";
    //    [EmailAddress]
    //    public string Email { get; set; } = "";

    //    public required string PassWordHash { get; set; } = "";
    //    public string Gender { get; set; } = "";
    //    public string Phone { get; set; } = "";
    //}
    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public string Gender { get; set; } = "";
        public string Phone { get; set; } = "";

        public required string Password { get; set; }
    }

    public class ResponseUserDto
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";

        public string? Name { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Gender { get; set; } = "";
        public string? Phone { get; set; } = "";
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}

namespace TwitterClone.Application.DTOs
{
    public class CreateUserDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Phone { get; set; } = "";
    }


    public class ResponseUserDto
    {
        public Guid? Id { get; set; }
        private string FirstName { get; } = "";
        private string LastName { get; } = "";

        public string? Name { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Gender { get; set; } = "";
        public string? Phone { get; set; } = "";
    }
}

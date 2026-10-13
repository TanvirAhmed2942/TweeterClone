namespace TwitterClone.Application.DTOs
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Phone { get; set; } = "";
    }

    public class PatchUpdateUserDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Phone { get; set; } = "";
    }

}

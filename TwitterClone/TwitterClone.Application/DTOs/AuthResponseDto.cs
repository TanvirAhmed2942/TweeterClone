namespace TwitterClone.Application.DTOs
{
    public class AuthResponseDto
    {
        public required string AccessToken { get; set; }
        public required DateOnly ExpiryAt { get; set; }
        public required ResponseUserDto? UserDto { get; set; }
    }
}

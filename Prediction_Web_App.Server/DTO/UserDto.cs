namespace Prediction_Web_App.Server.DTO
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}

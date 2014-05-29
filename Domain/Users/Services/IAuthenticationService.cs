namespace Domain.Users.Services
{
    public interface IAuthenticationService
    {
        User RegisterUser(RegisterUserRequest request);
    }
}
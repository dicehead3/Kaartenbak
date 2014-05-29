namespace Infrastructure.Services.Login
{
    public interface ILoginService
    {
        LoginResponse Login(LoginRequest request);
        RegisterResponse Register(RegisterRequest request);
    }
}

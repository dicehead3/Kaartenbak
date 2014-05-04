namespace Infrastructure.Services
{
    public interface ILoginService
    {
        UserLoginResponse Login(UserLoginRequest request);
        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
    }
}

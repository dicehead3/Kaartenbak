namespace Infrastructure.Services.User
{
    public interface IUserService
    {
        UserInfoResponse Info(UserInfoRequest request);
        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);

    }
}

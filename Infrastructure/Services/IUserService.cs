namespace Infrastructure.Services
{
    public interface IUserService
    {
        UserInfoResponse Info(UserInfoRequest request);
    }
}

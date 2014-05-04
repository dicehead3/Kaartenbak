namespace Infrastructure.Policies
{
    public interface IPasswordPolicy
    {
        bool Validate(string password);
    }
}

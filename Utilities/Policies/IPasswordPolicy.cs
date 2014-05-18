namespace Utilities.Policies
{
    public interface IPasswordPolicy
    {
        bool Validate(string password);
    }
}

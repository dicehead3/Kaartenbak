namespace Domain.Users
{
    public enum ChangePasswordResult
    {
        Success,
        OldEqualsNew,
        ConfirmationFailed,
        OldIncorrect,
        Error
    }
}

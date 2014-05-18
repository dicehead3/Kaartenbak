namespace Utilities.IoC
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}

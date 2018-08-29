namespace FlightSummary.DataAccess
{
    public interface IRepository<T>
    {
        void Set(T entity);
        T Get();
    }
}

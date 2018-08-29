namespace FlightSummary.Service
{
    public abstract class FlightServiceBase<T>
    {
        protected abstract T ConvertLineFromFile(string line);
    }
}

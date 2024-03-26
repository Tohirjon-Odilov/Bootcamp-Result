namespace GPSTracker.API.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) { }
    }
}

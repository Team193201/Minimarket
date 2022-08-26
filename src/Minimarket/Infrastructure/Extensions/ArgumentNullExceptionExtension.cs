namespace Infrastructure.Extensions
{
    public static class ArgumentNullExceptionExtension
    {
        public static void ThrowIfNull(this ArgumentNullException nullException, Guid parameter, string message = default, bool loggeError = false)
        {
            if (parameter == Guid.Empty)
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (parameter == Guid.Empty)
                nullException = new ArgumentNullException(string.IsNullOrEmpty(message) ? $"this is ({parameter}) null" : message);
            throw nullException;
        }

        public static void ThrowIfNull(this ArgumentNullException nullException, int parameter, string message = default, bool loggeError = false)
        {
            if (parameter == default)
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (parameter == default && !loggeError)
                nullException = new ArgumentNullException(string.IsNullOrEmpty(message) ? $"this is ({parameter}) null" : message);
            throw nullException;
        }

        public static void ThrowIfNull(this ArgumentNullException nullException, string parameter, string message = default, bool loggeError = false)
        {
            if (string.IsNullOrEmpty(parameter))
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (string.IsNullOrEmpty(parameter) && !loggeError)
                nullException = new ArgumentNullException(string.IsNullOrEmpty(message) ? $"this is ({parameter}) null" : message);
            throw nullException;
        }
    }
}

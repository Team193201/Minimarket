namespace Infrastructure.Util
{
    public class AppArgumentNullException : ArgumentNullException
    {
        public static void ThrowIfNull(Guid argument,string paramName, string message = default, bool loggeError = false)
        {
            if (argument == Guid.Empty)
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (argument == Guid.Empty)
                throw new ArgumentNullException(string.IsNullOrEmpty(message) ? $"this is ({paramName}) null" : message);
        }

        public static void ThrowIfNull(int argument, string paramName, string message = default, bool loggeError = false)
        {
            if (argument == default)
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (argument == default && !loggeError)
                throw new ArgumentNullException(string.IsNullOrEmpty(message) ? $"this is ({paramName}) null" : message);
        }

        public static void ThrowIfNull(string argument, string paramName, string message = default, bool loggeError = false)
        {
            if (string.IsNullOrEmpty(argument))
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (string.IsNullOrEmpty(argument) && !loggeError)
                throw new ArgumentNullException(string.IsNullOrEmpty(message) ? $"this is ({paramName}) null" : message);
        }
    }
}

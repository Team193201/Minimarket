using System.Collections;

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
                throw new ArgumentNullException(string.IsNullOrEmpty(message) ? $"Argument is ({paramName}) empty" : message);
        }

        public static void ThrowIfNull(int argument, string paramName, string message = default, bool loggeError = false)
        {
            if (argument == default)
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (argument == default && !loggeError)
                throw new ArgumentNullException(string.IsNullOrEmpty(message) ? $"Argument is ({paramName}) empty" : message);
        }

        public static void ThrowIfNull(string argument, string paramName, string message = default, bool loggeError = false)
        {
            if (string.IsNullOrEmpty(argument))
                if (loggeError) { }
            //TODO: set logg and throw exception

            if (string.IsNullOrEmpty(argument) && !loggeError)
                throw new ArgumentNullException(string.IsNullOrEmpty(message) ? $"Argument is ({paramName}) empty" : message);
        }

        public static void NotNull<T>(T obj, string name, string message = null)
           where T : class
        {
            if (obj is null)
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
        }

        public static void NotNull<T>(T? obj, string name, string message = null)
            where T : struct
        {
            if (!obj.HasValue)
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);

        }

        public static void NotEmpty<T>(T obj, string name, string message = null, T defaultValue = null)
            where T : class
        {
            if (obj == defaultValue
                || (obj is string str && string.IsNullOrWhiteSpace(str))
                || (obj is IEnumerable list && !list.Cast<object>().Any()))
            {
                throw new ArgumentException("Argument is empty : " + message, $"{name} : {typeof(T)}");
            }
        }
    }
}

using Newtonsoft.Json;
using System.Net;

namespace Infrastructure.Util
{
    public record DataAppException(HttpStatusCode HttpStatusCode = HttpStatusCode.InternalServerError, string AdditionalData = default, bool IsLogge = false, DateTime DateTimeException = default);

    public class AppException : Exception
    {
        public DataAppException DataApp { get; set; }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        public AppException()
         : this(false)
        {
        }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        /// <param name="isLogge">default set false</param>
        public AppException(bool isLogge = false)
         : this(string.Empty, isLogge)
        {
            DataApp = new DataAppException(IsLogge: isLogge);
        }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isLogge">default set false</param>
        public AppException(string message, bool isLogge = false)
         : this(message, HttpStatusCode.InternalServerError, isLogge)
        {
            DataApp = new DataAppException(IsLogge: isLogge);
        }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="isLogge">default set false</param>
        public AppException(string message, HttpStatusCode httpStatusCode, bool isLogge = false)
         : this(message, httpStatusCode, null, isLogge)
        {
            DataApp = new DataAppException(HttpStatusCode: httpStatusCode, IsLogge: isLogge);
        }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="additionalData"></param>
        /// <param name="isLogge">default set false</param>
        public AppException(string message, HttpStatusCode httpStatusCode, object additionalData, bool isLogge = false)
         : this(message, httpStatusCode, additionalData, default, isLogge)
        {
            DataApp = new DataAppException(HttpStatusCode: httpStatusCode, AdditionalData: JsonConvert.SerializeObject(additionalData), IsLogge: isLogge);

        }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="additionalData"></param>
        /// <param name="dateTimeException"></param>
        /// <param name="isLogge">default set false</param>
        public AppException(string message, HttpStatusCode httpStatusCode, object additionalData, DateTime dateTimeException, bool isLogge = false)
          : this(message, httpStatusCode, additionalData, dateTimeException, null, isLogge)
        {
            DataApp = new DataAppException(HttpStatusCode: httpStatusCode, AdditionalData: JsonConvert.SerializeObject(additionalData), DateTimeException: dateTimeException, IsLogge: isLogge);
        }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="additionalData"></param>
        /// <param name="dateTimeException"></param>
        /// <param name="exception"></param>
        /// <param name="isLogge">default set false</param>
        public AppException(string message, HttpStatusCode httpStatusCode, object additionalData, DateTime dateTimeException, Exception exception, bool isLogge = false)
            : base(message, exception)
        {
            DataApp = new DataAppException(HttpStatusCode: httpStatusCode, AdditionalData: JsonConvert.SerializeObject(additionalData), DateTimeException: dateTimeException, IsLogge: isLogge);
        }
    }
}

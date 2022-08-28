using System.Net;

namespace Infrastructure.Util
{
    public class AppException : Exception
    { 
        public HttpStatusCode HttpStatusCode { get; set; }
        public object AdditionalData { get; set; }
        public bool IsLogge { get; set; }
        public DateTime DateTimeException { get; set; }

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
         : this(string.Empty, HttpStatusCode.InternalServerError, isLogge)
        {
            IsLogge = isLogge;
        }

        /// <summary>
        /// AppException :Represents errors that occur during application execution. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isLogge">default set false</param>
        public AppException(string message, bool isLogge = false)
         : this(message, HttpStatusCode.InternalServerError, isLogge)
        {
            IsLogge = isLogge;
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
            HttpStatusCode = httpStatusCode;
            IsLogge = isLogge;
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
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
            IsLogge = isLogge;
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
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
            DateTimeException = dateTimeException;
            IsLogge = isLogge;
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
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
            DateTimeException = dateTimeException;
            IsLogge = isLogge;
        }
    }
}

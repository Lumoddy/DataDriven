
public abstract class ApiException : Exception
{
    public int HTTPCode { get; }
    public string ErrorCode { get; }

    public ApiException(string errorCode, string message)
        : this(errorCode, 400, message) { }

    public ApiException(string errorCode, int httpCode, string message)
        : base(message)
    {
        HTTPCode = httpCode;
        ErrorCode = errorCode;
    }

    public ApiException(string errorCode, string message, Exception innerException)
        : this(errorCode, 400, message, innerException) { }

    public ApiException(string errorCode, int httpCode, string message, Exception innerException)
        : base(message, innerException)
    {
        HTTPCode = httpCode;
        ErrorCode = errorCode;
    }
}

public class SessionExpiredException : ApiException
{
    public const string Code = "session/expired";

    public SessionExpiredException(string message)
        : base(Code, 400, message) { }

    public SessionExpiredException(string message, Exception innerException)
        : base(Code, 400, message, innerException) { }
}
using System;

namespace SpecFlowExample.Grpc.Integration.Tests.Framework
{
    public class ServiceResponse
    {
        public int StatusCode { get; }
        public Exception? Exception { get; }
        public bool IsSuccessful { get; }

        public ServiceResponse(bool isSuccessful, int statusCode, Exception exception = null)
        {
            IsSuccessful = isSuccessful;
            StatusCode = statusCode;
            Exception = exception;
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Data { get; }

        public ServiceResponse(int statusCode, T data)
            : base(true, statusCode)
        {
            Data = data;
        }

        public ServiceResponse(int statusCode, Exception exception)
            : base(false, statusCode, exception)
        {
            Data = default;
        }
    }
}

using System;
using Microsoft.Extensions.Logging;
using MyCouch;
using Nancy;
using System.Threading.Tasks;
using error_handler.backend;
using Nancy.Bootstrapper;
using Nancy.ErrorHandling;
using Nancy.Responses.Negotiation;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace cmas.backend
{
    public class HomeModule : NancyModule
    {
        private ILogger _logger;

        public class Person
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public HomeModule(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeModule>();
            _logger.LogInformation("test log");

            Get("/", SayHello);

            Get("token", (parameters, obj) =>
            {
                throw new InvalidTokenErrorException("The User had an invalid token.");
            });

            Get("unhandled", (parameters, obj) =>
            {
                throw new System.InvalidOperationException("An invalid operation exception.");
            });
        }

        private async Task<object> SayHello(dynamic ct)
        {
            string name;

            using (var client = new MyCouchClient("http://cmas-backend:backend967@cm-ylng-msk-03:5984", "cmas"))
            {
                /* var put = await client.Entities.PutAsync(
                     new Person { Id = "001", Name = "Daniel" });
                */

                var get = await client.Entities.GetAsync<Person>("001");
                name = get.Content.Name;
            }

            return "hello from home module "+ name;
        }
    }
}

namespace error_handler.backend
{
    public enum ServiceErrorCode
    {
        GeneralError = 0,
        NotFound = 10,
        InternalServerError = 20,
        InvalidToken = 30,
    }

    public class ServiceErrorModel
    {
        public ServiceErrorCode Code { get; set; }

        public string Details { get; set; }
    }

    public class HttpServiceError
    {
        public ServiceErrorModel ServiceErrorModel { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }

    public static class HttpServiceErrorDefinition
    {
        public static HttpServiceError NotFoundError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.NotFound,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.NotFound,
                Details = "The requested entity was not found."
            }
        };

        public static HttpServiceError GeneralError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.BadRequest,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.GeneralError,
                Details = "An error occured during processing the request."
            }
        };

        public static HttpServiceError InternalServerError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.InternalServerError,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.InternalServerError,
                Details = "There was an internal server error during processing the request."
            }
        };

        public static HttpServiceError InvalidTokenError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.BadRequest,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.InvalidToken,
                Details = "Invalid API Token."
            }
        };
    }

    public interface IHasHttpServiceError
    {
        HttpServiceError HttpServiceError { get; }
    }

    public class GeneralServiceErrorException : Exception, IHasHttpServiceError
    {
        public GeneralServiceErrorException()
            : base() { }

        public GeneralServiceErrorException(string message)
            : base(message) { }

        public GeneralServiceErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpServiceError HttpServiceError { get { return HttpServiceErrorDefinition.GeneralError; } }
    }

    public class InternalServerErrorException : Exception, IHasHttpServiceError
    {
        public InternalServerErrorException()
            : base() { }

        public InternalServerErrorException(string message)
            : base(message) { }

        public InternalServerErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpServiceError HttpServiceError { get { return HttpServiceErrorDefinition.InternalServerError; } }
    }

    public class NotFoundErrorException : Exception, IHasHttpServiceError
    {
        public NotFoundErrorException()
            : base() { }

        public NotFoundErrorException(string message)
            : base(message) { }

        public NotFoundErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpServiceError HttpServiceError { get { return HttpServiceErrorDefinition.NotFoundError; } }
    }

    public class InvalidTokenErrorException : Exception, IHasHttpServiceError
    {
        public InvalidTokenErrorException()
            : base() { }

        public InvalidTokenErrorException(string message)
            : base(message) { }

        public InvalidTokenErrorException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpServiceError HttpServiceError { get { return HttpServiceErrorDefinition.InvalidTokenError; } }
    }

    public static class HttpServiceErrorUtilities
    {
        public static HttpServiceError ExtractFromException(Exception exception, HttpServiceError defaultValue)
        {
            HttpServiceError result = defaultValue;

            if (exception != null)
            {
                IHasHttpServiceError exceptionWithServiceError = exception as IHasHttpServiceError;

                if (exceptionWithServiceError != null)
                {
                    result = exceptionWithServiceError.HttpServiceError;
                }
            }

            return result;
        }
    }

    public class CmErrorHandler
    {
        private ILogger _logger;

        public CmErrorHandler(ILoggerFactory loggerFactory)
        {
             _logger = loggerFactory.CreateLogger<CmErrorHandler>();
        }

        public void Enable(IPipelines pipelines, IResponseNegotiator responseNegotiator)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException("pipelines");
            }

            if (responseNegotiator == null)
            {
                throw new ArgumentNullException("responseNegotiator");
            }

            pipelines.OnError += (context, exception) => HandleException(context, exception, responseNegotiator);
        }

        private void LogException(NancyContext context, Exception exception)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError("An exception occured during processing a request. (Exception={0}).", exception);
            }
        }

        private Response HandleException(NancyContext context, Exception exception, IResponseNegotiator responseNegotiator)
        {
            LogException(context, exception);

            return CreateNegotiatedResponse(context, responseNegotiator, exception);
        }

        private Response CreateNegotiatedResponse(NancyContext context, IResponseNegotiator responseNegotiator, Exception exception)
        {
            HttpServiceError httpServiceError = HttpServiceErrorUtilities.ExtractFromException(exception, HttpServiceErrorDefinition.GeneralError);

            Negotiator negotiator = new Negotiator(context)
                .WithStatusCode(httpServiceError.HttpStatusCode)
                .WithModel(httpServiceError.ServiceErrorModel);

            return responseNegotiator.NegotiateResponse(negotiator, context);
        }
    }

    public class StatusCodeHandler404 : IStatusCodeHandler
    {
        private IResponseNegotiator responseNegotiator;

        public StatusCodeHandler404(IResponseNegotiator responseNegotiator)
        {
            this.responseNegotiator = responseNegotiator;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            context.NegotiationContext = new NegotiationContext();

            Negotiator negotiator = new Negotiator(context)
                .WithStatusCode(HttpServiceErrorDefinition.NotFoundError.HttpStatusCode)
                .WithModel(HttpServiceErrorDefinition.NotFoundError.ServiceErrorModel);

            context.Response = responseNegotiator.NegotiateResponse(negotiator, context);
        }
    }

    public class StatusCodeHandler500 : IStatusCodeHandler
    {
        private IResponseNegotiator responseNegotiator;

        public StatusCodeHandler500(IResponseNegotiator responseNegotiator)
        {
            this.responseNegotiator = responseNegotiator;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.InternalServerError;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            context.NegotiationContext = new NegotiationContext();

            Negotiator negotiator = new Negotiator(context)
                .WithStatusCode(HttpServiceErrorDefinition.InternalServerError.HttpStatusCode)
                .WithModel(HttpServiceErrorDefinition.InternalServerError.HttpStatusCode);

            context.Response = responseNegotiator.NegotiateResponse(negotiator, context);
        }
    }
}
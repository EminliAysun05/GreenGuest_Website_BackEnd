using GreenGuest_Web.Business.Abstractions.Exceptions;
using System.Net;

namespace GreenGuest_Web.Business.Exceptions;

public class InvalidInputException : Exception, IBaseException
{
	public InvalidInputException(string message = "Not Found") : base(message)
	{

	}
	public HttpStatusCode StatusCode { get ; set ; } = HttpStatusCode.BadRequest;
}

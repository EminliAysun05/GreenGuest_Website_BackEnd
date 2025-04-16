using GreenGuest_Web.Business.Abstractions.Exceptions;
using System.Net;

namespace GreenGuest_Web.Business.Exceptions;

public class AlreadyExistException : Exception, IBaseException
{
	public AlreadyExistException(string message) : base(message)
	{
	}

	HttpStatusCode IBaseException.StatusCode { get ; set ; } = HttpStatusCode.Conflict;
}

using GreenGuest_Web.Business.Abstractions.Exceptions;
using System.Net;

namespace GreenGuest_Web.Business.Exceptions;

public class NotFoundException : Exception, IBaseException
{
	public NotFoundException(string message) : base(message)
	{
	}
	public HttpStatusCode StatusCode { get ; set ; } = HttpStatusCode.NotFound;

}



using GreenGuest_Web.Business.Abstractions.Exceptions;
using System.Net;

namespace GreenGuest_Web.Business.Exceptions;

public class UnAuthorizedException : Exception, IBaseException
{
	public UnAuthorizedException(string message = "Qeydiyyatdan keçməyən istifadəçi") : base(message)
	{

	}
	public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Unauthorized;
}

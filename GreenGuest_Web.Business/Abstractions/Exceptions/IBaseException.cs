using System.Net;

namespace GreenGuest_Web.Business.Abstractions.Exceptions;

public interface IBaseException
{
	public HttpStatusCode StatusCode { get; set; }
}

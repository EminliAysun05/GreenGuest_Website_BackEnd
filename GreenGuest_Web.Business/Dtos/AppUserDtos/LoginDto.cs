namespace GreenGuest_Web.Business.Dtos.AppUserDtos;

//public class LoginDto : IDto
//{
//	public string Username { get; set; } = null!;
//	public string Password { get; set; } = null!;
//}
public class LoginRequestModel
{
	public string UserName { get; set; }
	public string Password { get; set; }
	public string? Email { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
}
public class LoginResponseDTO
{
	public bool Success { get; set; }
	public string Message { get; set; }
	public string? Token { get; set; }

	public LoginResponseDTO(bool success, string message, string? token = null)
	{
		Success = success;
		Message = message;
		Token = token;
	}
}

public class RegisterDto
{
	public string UserName { get; set; } = null!;
	public string Password { get; set; } = null!;
	public string? Email { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
}

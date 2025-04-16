using AutoMapper;
using GreenGuest_Web.Business.Dtos.AppUserDtos;
using GreenGuest_Web.Core.Entities;

namespace GreenGuest_Web.Business.AutoMappers;

public class AppUserAutoMapper : Profile
{
        public AppUserAutoMapper()
        {
		// 1. RegisterDto → AppUser
		CreateMap<RegisterDto, AppUser>()
			.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
			.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
			.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
			.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

		// 2. AppUser → RegisterDto (əgər profil görüntüləmək və ya dəyişmək üçün istifadə olunacaqsa)
		CreateMap<AppUser, RegisterDto>();
	}
    }

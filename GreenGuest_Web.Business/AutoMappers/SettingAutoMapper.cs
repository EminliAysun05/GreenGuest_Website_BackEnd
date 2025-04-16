using AutoMapper;
using GreenGuest_Web.Business.Dtos.SettingDtos;
using GreenGuest_Web.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Business.AutoMappers
{
	public class SettingAutoMapper : Profile
	{
		public SettingAutoMapper()
		{
			// 1. CreateDto → Entity
			CreateMap<SettingCreateDto, Setting>();

			// 2. UpdateDto → Entity (yalnız null olmayan dəyərlər map olunur)
			CreateMap<SettingUpdateDto, Setting>()
				.ForAllMembers(opt =>
					opt.Condition((src, dest, srcMember) => srcMember != null));

			// 3. Entity → ListDto
			CreateMap<Setting, SettingListDto>();
		}
	}
	
}

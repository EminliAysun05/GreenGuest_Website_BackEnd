using FluentValidation;
using GreenGuest_Web.Business.Dtos.SettingDtos;

namespace GreenGuest_Web.Business.Validators.SettingItemValidators;

public class SettingCreateDtoValidation : AbstractValidator<SettingCreateDto>
{
        public SettingCreateDtoValidation()
        {
		RuleFor(x => x.Key)
		   .NotEmpty().WithMessage("Açar (Key) boş ola bilməz.")
		   .MaximumLength(100).WithMessage("Açar maksimum 100 simvol ola bilər.");

		RuleFor(x => x.Value)
			.NotEmpty().WithMessage("Dəyər (Value) boş ola bilməz.")
			.MaximumLength(1000).WithMessage("Dəyər maksimum 1000 simvol ola bilər.");
	}
    }

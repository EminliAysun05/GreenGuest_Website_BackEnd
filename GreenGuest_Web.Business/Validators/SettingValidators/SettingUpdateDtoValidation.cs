using FluentValidation;
using GreenGuest_Web.Business.Dtos.SettingDtos;

namespace GreenGuest_Web.Business.Validators.SettingItemValidators;

public class SettingUpdateDtoValidation : AbstractValidator<SettingUpdateDto>
{
        public SettingUpdateDtoValidation()
        {
		RuleFor(x => x.Id)
		.GreaterThan(0).WithMessage("Id sıfırdan böyük olmalıdır.");

		RuleFor(x => x.Key)
			.MaximumLength(100).WithMessage("Açar maksimum 100 simvol ola bilər.")
			.When(x => x.Key is not null);

		RuleFor(x => x.Value)
			.NotEmpty().WithMessage("Dəyər boş ola bilməz.")
			.MaximumLength(1000).WithMessage("Dəyər maksimum 1000 simvol ola bilər.");
	}
    }

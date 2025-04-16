using FluentValidation;
using GreenGuest_Web.Business.Dtos.SliderDtos;
using GreenGuest_Web.Business.Extensions;

namespace GreenGuest_Web.Business.Validators.SliderValidators;

public class SliderUpdateDtoValidation : AbstractValidator<SliderUpdateDto>
{
        public SliderUpdateDtoValidation()
        {

		RuleFor(x => x.Id)
		.GreaterThan(0).WithMessage("Id sıfırdan böyük olmalıdır.");

		RuleFor(x => x.Title)
			.MaximumLength(150).WithMessage("Başlıq maksimum 150 simvol ola bilər.")
			.When(x => x.Title is not null);

		RuleFor(x => x.Description)
			.MaximumLength(500).WithMessage("Açıqlama maksimum 500 simvol ola bilər.")
			.When(x => x.Description is not null);

		RuleFor(x => x.ButtonPath)
			.MaximumLength(300).WithMessage("ButtonPath maksimum 300 simvol ola bilər.")
			.When(x => x.ButtonPath is not null);

		RuleFor(x => x.Image)
			.Must(img => img.ValidateType()).WithMessage("Yalnız şəkil formatına icazə verilir.")
			.Must(img => img.ValidateSize(2)).WithMessage("Şəkil maksimum 2MB olmalıdır.")
			.When(x => x.Image is not null);
	}
    }

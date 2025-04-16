using FluentValidation;
using GreenGuest_Web.Business.Dtos.SliderDtos;
using GreenGuest_Web.Business.Extensions;

namespace GreenGuest_Web.Business.Validators.SliderValidators;

public class SliderCreateDtoValidation : AbstractValidator<SliderCreateDto>
{
        public SliderCreateDtoValidation()
        {
		RuleFor(x => x.Title)
		.NotEmpty().WithMessage("Başlıq boş ola bilməz.")
		.MaximumLength(150).WithMessage("Başlıq maksimum 150 simvol ola bilər.");

		RuleFor(x => x.Description)
			.MaximumLength(500).WithMessage("Açıqlama maksimum 500 simvol ola bilər.")
			.When(x => x.Description is not null);

		RuleFor(x => x.ButtonPath)
			.MaximumLength(300).WithMessage("ButtonPath maksimum 300 simvol ola bilər.")
			.When(x => x.ButtonPath is not null);

		RuleFor(x => x.Image)
			.NotNull().WithMessage("Şəkil seçilməlidir.")
			.Must(img => img.ValidateType()).WithMessage("Yalnız şəkil formatına (.jpeg, .png və s.) icazə verilir.")
			.Must(img => img.ValidateSize(2)).WithMessage("Şəkil ölçüsü maksimum 2MB olmalıdır.");
	}
    }

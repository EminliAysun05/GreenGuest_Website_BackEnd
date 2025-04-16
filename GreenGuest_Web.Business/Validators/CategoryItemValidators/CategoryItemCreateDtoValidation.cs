using FluentValidation;
using GreenGuest_Web.Business.Dtos.CategoryItemDtos;

namespace GreenGuest_Web.Business.Validators.CategoryItemValidators;

public class CategoryItemCreateDtoValidation : AbstractValidator<CategoryItemCreateDto>
{
        public CategoryItemCreateDtoValidation()
        {
		RuleFor(x => x.Title)
		.NotEmpty().WithMessage("Title boş ola bilməz.")
		.MaximumLength(100).WithMessage("Title 100 simvoldan uzun ola bilməz.");

		RuleFor(x => x.Icon)
			.NotEmpty().WithMessage("Icon boş ola bilməz.")
			.MaximumLength(150).WithMessage("Icon 150 simvoldan uzun ola bilməz.");

		RuleFor(x => x.ButtonPath)
			.MaximumLength(300).WithMessage("ButtonPath 300 simvoldan uzun ola bilməz.");
	}
    }

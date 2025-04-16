using FluentValidation;
using GreenGuest_Web.Business.Dtos.CategoryItemDtos;

namespace GreenGuest_Web.Business.Validators.CategoryItemValidators;

public class CategoryItemUpdateDtoValidation : AbstractValidator<CategoryItemUpdateDto>
{
        public CategoryItemUpdateDtoValidation()
        {
		RuleFor(x => x.Id)
		.GreaterThan(0).WithMessage("Id sıfırdan böyük olmalıdır.");

		RuleFor(x => x.Title)
			.MaximumLength(100).WithMessage("Title maksimum 100 simvol ola bilər.")
			.When(x => x.Title is not null);

		RuleFor(x => x.Icon)
			.MaximumLength(150).WithMessage("Icon maksimum 150 simvol ola bilər.")
			.When(x => x.Icon is not null);

		RuleFor(x => x.ButtonPath)
			.MaximumLength(300).WithMessage("ButtonPath maksimum 300 simvol ola bilər.")
			.When(x => x.ButtonPath is not null);
	}
}
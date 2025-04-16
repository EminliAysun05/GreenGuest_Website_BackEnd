using FluentValidation;
using GreenGuest_Web.Business.Dtos.FaqItemDtos;

namespace GreenGuest_Web.Business.Validators.FaqItemValidators;

public class FaqItemUpdateDtoValidation : AbstractValidator<FaqItemUpdateDto>
{
        public FaqItemUpdateDtoValidation()
        {
		RuleFor(x => x.Id)
		.GreaterThan(0).WithMessage("Id sıfırdan böyük olmalıdır.");

		RuleFor(x => x.Question)
			.MaximumLength(300).WithMessage("Sual maksimum 300 simvol ola bilər.")
			.When(x => x.Question is not null);

		RuleFor(x => x.Answer)
			.MaximumLength(1000).WithMessage("Cavab maksimum 1000 simvol ola bilər.")
			.When(x => x.Answer is not null);
	}
    }

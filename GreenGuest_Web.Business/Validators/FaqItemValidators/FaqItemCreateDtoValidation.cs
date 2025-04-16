using FluentValidation;
using GreenGuest_Web.Business.Dtos.FaqItemDtos;

namespace GreenGuest_Web.Business.Validators.FaqItemValidators;

public class FaqItemCreateDtoValidation : AbstractValidator<FaqItemCreateDto>
{
        public FaqItemCreateDtoValidation()
        {
		RuleFor(x => x.Question)
		   .NotEmpty().WithMessage("Sual boş ola bilməz.")
		   .MaximumLength(300).WithMessage("Sual maksimum 300 simvol ola bilər.");

		RuleFor(x => x.Answer)
			.NotEmpty().WithMessage("Cavab boş ola bilməz.")
			.MaximumLength(1000).WithMessage("Cavab maksimum 1000 simvol ola bilər.");
	}
    }

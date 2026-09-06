using FluentValidation;

namespace Application.Children.Create;

internal sealed class CreateChildCommandValidator : AbstractValidator<CreateChildCommand>
{
    public CreateChildCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
    }
}

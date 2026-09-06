using FluentValidation;

namespace Application.Children.CheckIn;

internal sealed class CheckInChildCommandValidator : AbstractValidator<CheckInChildCommand>
{
    public CheckInChildCommandValidator()
    {
        RuleFor(c => c.ChildId).NotEmpty();
    }
}

using FluentValidation;

namespace Application.Children.Delete;

internal sealed class DeleteChildCommandValidator : AbstractValidator<DeleteChildCommand>
{
    public DeleteChildCommandValidator()
    {
        RuleFor(c => c.ChildId).NotEmpty();
    }
}

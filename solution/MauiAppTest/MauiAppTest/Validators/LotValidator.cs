using FluentValidation;
using MauiAppTest.Models;

namespace MauiAppTest.Validators;

public class LotValidator : AbstractValidator<Lot>
{
    public LotValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}

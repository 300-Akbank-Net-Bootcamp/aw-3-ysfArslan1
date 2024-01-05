using FluentValidation;
using Vb.Schema;

namespace Vb.Business.Validator;

public class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountValidator()
    {       
        RuleFor(x => x.CustomerNumber).NotEmpty();
        RuleFor(x => x.CurrencyType).NotEmpty().MaximumLength(3);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
{
    public UpdateAccountValidator()
    {
        RuleFor(x => x.Balance).NotEmpty().ScalePrecision(4, 18); // percision - scale 
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
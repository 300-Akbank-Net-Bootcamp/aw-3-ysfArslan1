using FluentValidation;
using Vb.Schema;

namespace Vb.Business.Validator;

public class CreateContactValidator : AbstractValidator<CreateContactRequest>
{
    public CreateContactValidator()
    {       
        RuleFor(x => x.CustomerNumber).NotEmpty();
        RuleFor(x => x.ContactType).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Information).NotEmpty().MaximumLength(100);
        RuleFor(x => x.IsDefault).NotEmpty();
    }
}
public class UpdateContactValidator : AbstractValidator<UpdateContactRequest>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.ContactType).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Information).NotEmpty().MaximumLength(100);
        RuleFor(x => x.IsDefault).NotEmpty();
    }
}
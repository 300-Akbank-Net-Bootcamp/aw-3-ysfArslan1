using FluentValidation;
using Vb.Schema;

namespace Vb.Business.Validator;

public class CreateEftTransactionValidator : AbstractValidator<CreateEftTransactionRequest>
{
    public CreateEftTransactionValidator()
    {       
        RuleFor(x => x.AccountNumber).NotEmpty();
        RuleFor(x => x.ReferenceNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Amount).NotEmpty().ScalePrecision(4, 18);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        RuleFor(x => x.SenderAccount).NotEmpty().MaximumLength(50);
        RuleFor(x => x.SenderIban).NotEmpty().MaximumLength(50);
        RuleFor(x => x.SenderName).NotEmpty().MaximumLength(50);
    }
}
public class UpdateEftTransactionValidator : AbstractValidator<UpdateEftTransactionRequest>
{
    public UpdateEftTransactionValidator()
    {
        RuleFor(x => x.Amount).NotEmpty().ScalePrecision(4, 18);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
    }
}
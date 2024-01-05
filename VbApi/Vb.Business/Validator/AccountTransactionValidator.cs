using FluentValidation;
using Vb.Schema;

namespace Vb.Business.Validator;

public class CreateAccountTransactionValidator : AbstractValidator<CreateAccountTransactionRequest>
{
    public CreateAccountTransactionValidator()
    {       
        RuleFor(x => x.AccountNumber).NotEmpty();
        RuleFor(x => x.ReferenceNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Amount).NotEmpty().ScalePrecision(4,18);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        RuleFor(x => x.TransferType).NotEmpty().MaximumLength(10);
        }
}

public class UpdateAccountTransactionValidator : AbstractValidator<UpdateAccountTransactionRequest>
{
    public UpdateAccountTransactionValidator()
    {
        RuleFor(x => x.Amount).NotEmpty().ScalePrecision(4, 18);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
    }
}
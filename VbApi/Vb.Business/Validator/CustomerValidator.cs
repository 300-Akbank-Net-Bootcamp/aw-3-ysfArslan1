using FluentValidation;
using Vb.Schema;

namespace Vb.Business.Validator;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.IdentityNumber).NotEmpty().MaximumLength(11).WithName("Customer tax or identity number");
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateOfBirth).NotEmpty();

        RuleForEach(x => x.Addresses).SetValidator(new CreateAddressValidatorForCustomer());
        RuleForEach(x => x.Contacts).SetValidator(new CreateContactValidatorForCustomer());
        RuleForEach(x => x.Accounts).SetValidator(new CreateAccountValidatorForCustomer());
    }
}

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateOfBirth).NotEmpty();

    }
}

public class CreateAddressValidatorForCustomer : AbstractValidator<CreateAddressRequestForCustomer>
{
    public CreateAddressValidatorForCustomer()
    {
        RuleFor(x => x.Address1).NotEmpty().MaximumLength(150).WithName("Customer address line 1");
        RuleFor(x => x.Address2).MaximumLength(150).WithName("Customer address line 2");
        RuleFor(x => x.Country).NotEmpty().MaximumLength(100);
        RuleFor(x => x.City).NotEmpty().MaximumLength(100);
        RuleFor(x => x.County).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PostalCode).NotEmpty().MaximumLength(10).MinimumLength(6).WithName("Zip code or postal code");
        RuleFor(x => x.IsDefault).NotEmpty();
    }
}

public class CreateContactValidatorForCustomer : AbstractValidator<CreateContactRequestForCustomer>
{
    public CreateContactValidatorForCustomer()
    {
        RuleFor(x => x.ContactType).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Information).NotEmpty().MaximumLength(100);
        RuleFor(x => x.IsDefault).NotEmpty();
    }
}

public class CreateAccountValidatorForCustomer : AbstractValidator<CreateAccountRequestForCustomer>
{
    public CreateAccountValidatorForCustomer()
    {
        RuleFor(x => x.CurrencyType).NotEmpty().MaximumLength(3);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

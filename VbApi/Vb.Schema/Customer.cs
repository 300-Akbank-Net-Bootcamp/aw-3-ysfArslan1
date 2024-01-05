using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Vb.Base.Schema;

namespace Vb.Schema;
// Customer sýnýfý için request(istek) oluþturulugunda, istenilen bilgilerin alýnmasý için kullanýlan sýnýf
public class CreateCustomerRequest : BaseRequest
{
    [JsonIgnore] 
    public int CustomerNumber { get; set; }
    public string IdentityNumber { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int InsertUserId { get; set; }

    public virtual List<CreateAddressRequestForCustomer> Addresses { get; set; }
    public virtual List<CreateContactRequestForCustomer> Contacts { get; set; }
    public virtual List<CreateAccountRequestForCustomer> Accounts { get; set; }
}
public class UpdateCustomerRequest : BaseRequest
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int UpdateUserId { get; set; }

}
// Customer sýnýfý için Response(cevap) oluþturulugunda, istenilen bilgilerin gönderilmesi için kullanýlan sýnýf
public class CustomerResponse : BaseResponse
{
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CustomerNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime LastActivityDate { get; set; }

    public string CustomerName
    {
        get { return FirstName + " " + LastName; }
    }
}

public class CreateAccountRequestForCustomer : BaseRequest
{
    public string CurrencyType { get; set; }
    public string Name { get; set; }
    public int InsertUserId { get; set; }
}

public class CreateAddressRequestForCustomer : BaseRequest
{
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string PostalCode { get; set; }
    public bool IsDefault { get; set; }
    public int InsertUserId { get; set; }

}
public class CreateContactRequestForCustomer : BaseRequest
{
    [JsonIgnore]
    public int Id { get; set; }

    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
    public int InsertUserId { get; set; }
}

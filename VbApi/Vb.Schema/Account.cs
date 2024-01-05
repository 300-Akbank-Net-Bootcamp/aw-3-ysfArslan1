using System.Text.Json.Serialization;
using Vb.Base.Schema;

namespace Vb.Schema;

public class CreateAccountRequest : BaseRequest
{
    public int CustomerNumber { get; set; }
    public string CurrencyType { get; set; }
    public string Name { get; set; }
    public int InsertUserId { get; set; }
}

public class UpdateAccountRequest : BaseRequest
{
    public decimal Balance { get; set; }
    public string Name { get; set; }
    public int UpdateUserId { get; set; }
}


public class AccountResponse : BaseResponse
{
    public int AccountNumber { get; set; }
    public string IBAN { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyType { get; set; }
    public string Name { get; set; }
    public DateTime OpenDate { get; set; }

}

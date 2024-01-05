using System.Text.Json.Serialization;
using Vb.Base.Schema;

namespace Vb.Schema;

public class CreateAccountTransactionRequest : BaseRequest
{
    public int AccountNumber { get; set; }
    public string ReferenceNumber { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string TransferType { get; set; }
    public int InsertUserId { get; set; }
}
public class UpdateAccountTransactionRequest : BaseRequest
{
    public string ReferenceNumber { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string TransferType { get; set; }
    public int UpdateUserId { get; set; }
}
public class AccountTransactionResponse : BaseResponse
{
    public int AccountNumber { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string TransferType { get; set; }
}
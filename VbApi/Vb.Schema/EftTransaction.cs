using System.Text.Json.Serialization;
using Vb.Base.Schema;

namespace Vb.Schema;

public class CreateEftTransactionRequest : BaseRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    
    public int AccountNumber { get; set; }
    
    public string ReferenceNumber { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    
    public string SenderAccount { get; set; }
    public string SenderIban { get; set; }
    public string SenderName { get; set; }
    public int InsertUserId { get; set; }
}

public class UpdateEftTransactionRequest : BaseRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    public string ReferenceNumber { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int UpdateUserId { get; set; }

}

public class EftTransactionResponse : BaseResponse
{
    
    public int AccountNumber { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    
    public string SenderAccount { get; set; }
    public string SenderIban { get; set; }
    public string SenderName { get; set; }
}
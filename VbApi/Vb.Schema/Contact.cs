using System.Text.Json.Serialization;
using Vb.Base.Schema;

namespace Vb.Schema;

public class CreateContactRequest : BaseRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    
    public int CustomerNumber { get; set; }
    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
    public int InsertUserId { get; set; }
}

public class UpdateContactRequest : BaseRequest
{
    [JsonIgnore]
    public int Id { get; set; }

    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
    public int UpdateUserId { get; set; }
}
public class ContactResponse : BaseResponse
{
    public int CustomerNumber { get; set; }
    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
}

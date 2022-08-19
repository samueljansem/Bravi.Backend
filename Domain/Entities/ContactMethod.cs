using System.Text.Json.Serialization;

namespace Bravi.Backend.Domain.Entities;

public class ContactMethod
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Contact Contact { get; set; }
    public Guid ContactId { get; set; }
}
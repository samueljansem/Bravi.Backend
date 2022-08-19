using System.Text.Json.Serialization;

namespace Bravi.Backend.Domain.Entities;

public class Contact
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public DateTime BirthDate { get; set; }

    public bool IsFavorite { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ContactMethod> ContactMethods { get; set; }
}
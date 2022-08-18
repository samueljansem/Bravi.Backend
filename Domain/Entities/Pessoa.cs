using System.Text.Json.Serialization;

namespace Bravi.Backend.Domain.Entities;

public class Pessoa
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<Contato> Contatos { get; set; }
}
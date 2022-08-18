using System.Text.Json.Serialization;

namespace Bravi.Backend.Domain.Entities;

public class Contato
{
    public Guid Id { get; set; }
    public string Tipo { get; set; }
    public string Valor { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Pessoa Pessoa { get; set; }
    public Guid PessoaId { get; set; }
}
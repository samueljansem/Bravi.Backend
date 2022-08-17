namespace Bravi.Backend.Domain.Entities;

public class Contato
{
    public Guid Id { get; set; }
    public string Tipo { get; set; }
    public string Valor { get; set; }
    public Pessoa Pessoa { get; set; }
    public Guid PessoaId { get; set; }
}
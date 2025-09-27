using System.ComponentModel.DataAnnotations;

public class CriarPessoaRequest
{
    [Required]
    [StringLength(200)]
    public string NomeCompleto { get; set; }

    [StringLength(20)]
    public string Telefone { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Senha { get; set; }
}
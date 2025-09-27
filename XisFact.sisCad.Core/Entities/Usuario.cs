using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum TipoAcesso
{
    Administrador,
    Membro,
    Financeiro
}

public class Usuario
{
    [Key]
    [ForeignKey("Pessoa")] // Chave primária e estrangeira para a Pessoa
    public int PessoaId { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string SenhaHash { get; set; } // Nunca guarde a senha em texto plano!

    public TipoAcesso Acesso { get; set; }

    // Propriedade de navegação para a Pessoa
    public virtual Pessoa Pessoa { get; set; }
}
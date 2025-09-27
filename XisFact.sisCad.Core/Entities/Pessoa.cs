using System.ComponentModel.DataAnnotations;

public class Pessoa
{
    [Key] // Chave primária
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(200)]
    public string NomeCompleto { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }

    public DateTime DataNascimento { get; set; }

    // Propriedade de navegação para o Usuário
    public virtual Usuario Usuario { get; set; }
}
}
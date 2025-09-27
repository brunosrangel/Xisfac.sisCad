namespace Xisfac.SisCad.Core.DTOs
{
    public class PessoaResponse
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
    }
}
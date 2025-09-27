using Xisfac.SisCad.Core.DTOs;
namespace Xisfac.SisCad.Core.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<PessoaResponse> CadastrarPessoaAsync(CriarPessoaRequest dto);
    }
}
// Core/Interfaces/Repositories/IPessoaRepository.cs
namespace Xisfac.SisCad.Core.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> AdicionarAsync(Pessoa pessoa);
        Task<Pessoa?> ObterPorIdAsync(int id);
    }
}


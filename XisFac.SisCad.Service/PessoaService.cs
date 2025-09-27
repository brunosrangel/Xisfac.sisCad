using Xisfac.SisCad.Core.DTOs;
using Xisfac.SisCad.Core.Interfaces.Repositories;
using Xisfac.SisCad.Core.Interfaces.Services;

namespace Xisfac.SisCad.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepo;
        private readonly IUsuarioRepository _usuarioRepo;

        public PessoaService(IPessoaRepository pessoaRepo, IUsuarioRepository usuarioRepo)
        {
            _pessoaRepo = pessoaRepo;
            _usuarioRepo = usuarioRepo;
        }

        public async Task<PessoaResponse> CadastrarPessoaAsync(CriarPessoaRequest dto)
        {
            // 1. Validação de Regra de Negócio
            var usuarioExistente = await _usuarioRepo.ObterPorEmailAsync(dto.Email);
            if (usuarioExistente != null)
            {
                throw new ArgumentException("O email informado já está em uso.");
            }

            // 2. Mapeamento do DTO para Entidade
            var novaPessoa = new Pessoa
            {
                NomeCompleto = dto.NomeCompleto,
                DataNascimento = dto.DataNascimento,
                Telefone = dto.Telefone,
                Usuario = new Usuario
                {
                    Email = dto.Email,
                    // 3. Lógica de Hashing
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                    Acesso = Core.Enums.TipoAcesso.Membro
                }
            };

            // 4. Persistência
            var pessoaSalva = await _pessoaRepo.AdicionarAsync(novaPessoa);

            // 5. Mapeamento da Entidade para DTO de Resposta
            var response = new PessoaResponse
            {
                Id = pessoaSalva.Id,
                NomeCompleto = pessoaSalva.NomeCompleto,
                Telefone = pessoaSalva.Telefone,
                DataNascimento = pessoaSalva.DataNascimento,
                Email = pessoaSalva.Usuario.Email
            };

            return response;
        }
    }
}
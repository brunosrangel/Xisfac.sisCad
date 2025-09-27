using Xisfac.SisCad.Core.Interfaces.Repositories;
using XisFac.xisCad.Repositorio.Data;

public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pessoa> AdicionarAsync(Pessoa pessoa)
    {
        await _context.Pessoas.AddAsync(pessoa);
        // O SaveChanges() será chamado em outro lugar (Unit of Work)
        // mas por simplicidade inicial, podemos deixar aqui.
        // Discutiremos isso depois.
        await _context.SaveChangesAsync();
        return pessoa;
    }

    public async Task<Pessoa?> ObterPorIdAsync(int id)
    {
        return await _context.Pessoas.FindAsync(id);
    }
}
public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);
}
using Programacion3Template.Models;

namespace Programacion3Template.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> Create(Usuario usuario);
        Task<bool> Exists(String usuario);
        Task<Usuario> GetByCredentials(String username, String password);
    }
}

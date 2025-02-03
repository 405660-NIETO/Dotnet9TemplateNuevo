using Programacion3Template.Models;

namespace Programacion3Template.Interfaces
{
    public interface ITokenRepository
    {
        Task<string> GenerateToken(Guid usuarioId);
        
    }
}

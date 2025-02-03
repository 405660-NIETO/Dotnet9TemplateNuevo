using Programacion3Template.Response;

namespace Programacion3Template.Interfaces
{
    public interface IUsuarioService
    {
        Task<ApiResponse<bool>> Register(string username, string password);
        Task<ApiResponse<string>> Login(string username, string password);
    }
}

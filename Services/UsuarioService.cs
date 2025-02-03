using Programacion3Template.Interfaces;
using Programacion3Template.Models;
using Programacion3Template.Response;
using System.Net;

namespace Programacion3Template.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenRepository _tokenRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenRepository tokenRepository)
        {
            _usuarioRepository = usuarioRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<ApiResponse<string>> Login(string username, string password)
        {
            var response = new ApiResponse<string>();

            var usuario = await _usuarioRepository.GetByCredentials(username, password);
            if (usuario == null)
            {
                response.SetError("Credenciales inválidas", HttpStatusCode.Unauthorized);
                return response;
            }

            response.Data = await _tokenRepository.GenerateToken(usuario.Id);
            return response;
        }

        public async Task<ApiResponse<bool>> Register(string username, string password)
        {
            var response = new ApiResponse<bool>();

            if (await _usuarioRepository.Exists(username))
            {
                response.SetError("Usuario ya existe", HttpStatusCode.BadRequest);
                return response;
            }

            var usuario = new Usuario
            {
                Username = username,
                Password = password
            };

            response.Data = await _usuarioRepository.Create(usuario);
            return response;
        }
    }
}

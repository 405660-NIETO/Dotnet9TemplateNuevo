using Microsoft.EntityFrameworkCore;
using Programacion3Template.Data;
using Programacion3Template.Interfaces;
using Programacion3Template.Models;

namespace Programacion3Template.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            await _context.Usuarios.AddAsync(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Exists(string username)
        {
            return await _context.Usuarios.AnyAsync(u => u.Username == username);
        }

        public async Task<Usuario?> GetByCredentials(string username, string password)
        {
            return await _context.Usuarios
                .Include(u => u.Token)
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}

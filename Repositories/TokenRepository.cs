using Microsoft.EntityFrameworkCore;
using Programacion3Template.Data;
using Programacion3Template.Interfaces;
using Programacion3Template.Models;

namespace Programacion3Template.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDbContext _context;

        public TokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateToken(Guid userId)
        {
            // Eliminar token existente si existe
            var existingToken = await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == userId);
            if (existingToken != null)
            {
                _context.Tokens.Remove(existingToken);
            }

            // Crear nuevo token
            var token = new Token
            {
                Id = Guid.NewGuid(),
                Value = Guid.NewGuid().ToString(),
                UserId = userId,
                ExpirationDate = DateTime.UtcNow.AddHours(1)
            };

            await _context.Tokens.AddAsync(token);
            await _context.SaveChangesAsync();

            return token.Value;
        }
    }
}

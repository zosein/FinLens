using Microsoft.EntityFrameworkCore;
using FinLensAPI.Interfaces;
using FinLensAPI.Models;
using FinLensAPI.Data;

namespace FinLensAPI.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDBContext _context;
        public ComentarioRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comentario>> ObterTodosAsync()
        {
            return await _context.Comentarios.ToListAsync();
        }
    }
}
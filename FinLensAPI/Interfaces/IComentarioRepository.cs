using FinLensAPI.Models;

namespace FinLensAPI.Interfaces
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> ObterTodosAsync();
    }
}
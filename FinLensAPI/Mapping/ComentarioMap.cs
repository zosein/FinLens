using FinLensAPI.DTOs.ComentarioDTO;
using FinLensAPI.Models;

namespace FinLensAPI.Mapping
{
    public static class ComentarioMap
    {
        public static ComentarioDTO ToComentarioDTO(this Comentario comentarioModel)
        {
            return new ComentarioDTO
            {
                Id = comentarioModel.Id,
                Titulo = comentarioModel.Titulo,
                Conteudo = comentarioModel.Conteudo,
                CriadoEm = comentarioModel.CriadoEm,
                MercadoId = comentarioModel.MercadoId
            };
        }
    }
}
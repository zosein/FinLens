using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinLensAPI.DTOs.ComentarioDTO
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public int? MercadoId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinLensAPI.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public int? MercadoId { get; set; }
        // Navigation property
        public Mercado? Mercado { get; set; }
    }
}
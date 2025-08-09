using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinLensAPI.Models
{
    public class Mercado
    {
        public int Id { get; set; }
        public string Simbolo { get; set; } = string.Empty;
        public string NomeEmpresa { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoCompra { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UltimoDividendo { get; set; }
        public string Industria { get; set; } = string.Empty;
        public long CapitalizacaoMercado { get; set; }

        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();


    }
}
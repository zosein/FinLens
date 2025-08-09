using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinLensAPI.DTOs.MercadoDTO
{
    public class CreateMercadoRequestDTO
    {
        public string Simbolo { get; set; } = string.Empty;
        public string NomeEmpresa { get; set; } = string.Empty;
        public decimal PrecoCompra { get; set; }
        public decimal UltimoDividendo { get; set; }
        public string Industria { get; set; } = string.Empty;
        public long CapitalizacaoMercado { get; set; }
    }
}
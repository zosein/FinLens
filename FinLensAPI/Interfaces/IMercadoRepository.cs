using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinLensAPI.Models;
using FinLensAPI.DTOs.MercadoDTO;

namespace FinLensAPI.Interfaces
{
    public interface IMercadoRepository
    {
        Task<List<Mercado>> ObterTodosAsync();
        Task<Mercado?> ObterPorIdAsync(int id);
        Task<Mercado> CreateAsync(Mercado mercadoModel);
        Task<Mercado?> UpdateAsync(int id, UpdateMercadoRequestDTO mercadoDTO);
        Task<Mercado?> DeleteAsync(int id);
    }
}
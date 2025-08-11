using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinLensAPI.Data;
using FinLensAPI.Interfaces;
using FinLensAPI.Models;
using FinLensAPI.DTOs.MercadoDTO;

namespace FinLensAPI.Repository
{
    public class MercadoRepository : IMercadoRepository
    {
        private readonly AppDBContext _context;

        public MercadoRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Mercado> CreateAsync(Mercado mercadoModel)
        {
            await _context.Mercados.AddAsync(mercadoModel);
            await _context.SaveChangesAsync();
            return mercadoModel;
        }
        public async Task<Mercado?> DeleteAsync(int id)
        {
            var mercadoModel = await _context.Mercados.FirstOrDefaultAsync(s => s.Id == id);

            if (mercadoModel == null)
            {
                return null;
            }

            _context.Mercados.Remove(mercadoModel);
            await _context.SaveChangesAsync();
            return mercadoModel;
        }
        public async Task<List<Mercado>> ObterTodosAsync()
        {
            return await _context.Mercados.ToListAsync();
        }

        public async Task<Mercado?> ObterPorIdAsync(int id)
        {
            return await _context.Mercados.FindAsync(id);
        }

        public async Task<Mercado?> UpdateAsync(int id, UpdateMercadoRequestDTO mercadoDto)
        {
            var existingMercado = await _context.Mercados.FirstOrDefaultAsync(s => s.Id == id);

            if (existingMercado == null)
            {
                return null;
            }

            existingMercado.Simbolo = mercadoDto.Simbolo;
            existingMercado.NomeEmpresa = mercadoDto.NomeEmpresa;
            existingMercado.PrecoCompra = mercadoDto.PrecoCompra;
            existingMercado.UltimoDividendo = mercadoDto.UltimoDividendo;
            existingMercado.Industria = mercadoDto.Industria;
            existingMercado.CapitalizacaoMercado = mercadoDto.CapitalizacaoMercado;

            await _context.SaveChangesAsync();
            return existingMercado;
        }
    }
}
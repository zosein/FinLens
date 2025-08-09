using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinLensAPI.DTOs.MercadoDTO;
using FinLensAPI.Models;

namespace FinLensAPI.Mapping
{
    public static class MercadoMap
    {
        public static MercadoDTO ToMercadoDTO(this Mercado mercadoModel)
        {
            return new MercadoDTO
            {
                Id = mercadoModel.Id,
                Simbolo = mercadoModel.Simbolo,
                NomeEmpresa = mercadoModel.NomeEmpresa,
                PrecoCompra = mercadoModel.PrecoCompra,
                UltimoDividendo = mercadoModel.UltimoDividendo,
                Industria = mercadoModel.Industria,
                CapitalizacaoMercado = mercadoModel.CapitalizacaoMercado
            };
        }

        public static Mercado ToMercadoFromCreateDTO(this CreateMercadoRequestDTO mercadoDto)
        {
            return new Mercado
            {
                Simbolo = mercadoDto.Simbolo,
                NomeEmpresa = mercadoDto.NomeEmpresa,
                PrecoCompra = mercadoDto.PrecoCompra,
                UltimoDividendo = mercadoDto.UltimoDividendo,
                Industria = mercadoDto.Industria,
                CapitalizacaoMercado = mercadoDto.CapitalizacaoMercado
            };
        }
    }
}
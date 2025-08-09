using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinLensAPI.Data;
using FinLensAPI.DTOs.MercadoDTO;
using FinLensAPI.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace FinLensAPI.Controllers
{
    [Route("api/mercado")]
    [ApiController]
    public class MercadoController : ControllerBase
    {
        private readonly AppDBContext _context;
        public MercadoController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var mercados = _context.Mercados.ToList()
            .Select(s => s.ToMercadoDTO());

            return Ok(mercados);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var mercado = _context.Mercados.Find(id);

            if (mercado == null)
            {
                return NotFound();
            }

            return Ok(mercado.ToMercadoDTO());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMercadoRequestDTO mercadoDto)
        {
            var mercadoModel = mercadoDto.ToMercadoFromCreateDTO();

            _context.Mercados.Add(mercadoModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = mercadoModel.Id }, mercadoModel.ToMercadoDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateMercadoRequestDTO updateDto)
        {
            var mercadoModel = _context.Mercados.FirstOrDefault(s => s.Id == id);

            if (mercadoModel == null)
            {
                return NotFound();
            }

            mercadoModel.Simbolo = updateDto.Simbolo;
            mercadoModel.NomeEmpresa = updateDto.NomeEmpresa;
            mercadoModel.PrecoCompra = updateDto.PrecoCompra;
            mercadoModel.UltimoDividendo = updateDto.UltimoDividendo;
            mercadoModel.Industria = updateDto.Industria;
            mercadoModel.CapitalizacaoMercado = updateDto.CapitalizacaoMercado;

            _context.SaveChanges();

            return Ok(mercadoModel.ToMercadoDTO());
        }


    }
}
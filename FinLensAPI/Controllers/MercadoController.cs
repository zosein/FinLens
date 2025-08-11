using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinLensAPI.Data;
using FinLensAPI.DTOs.MercadoDTO;
using FinLensAPI.Interfaces;
using FinLensAPI.Mapping;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinLensAPI.Controllers
{
    [Route("api/mercado")]
    [ApiController]
    public class MercadoController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMercadoRepository _mercadoRepo;
        public MercadoController(AppDBContext context, IMercadoRepository mercadoRepo)
        {
            _mercadoRepo = mercadoRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var mercados = await _mercadoRepo.ObterTodosAsync();

            var mercadoDto = mercados.Select(s => s.ToMercadoDTO());

            return Ok(mercados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var mercado = await _mercadoRepo.ObterPorIdAsync(id);

            if (mercado == null)
            {
                return NotFound();
            }

            return Ok(mercado.ToMercadoDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMercadoRequestDTO mercadoDto)
        {
            var mercadoModel = mercadoDto.ToMercadoFromCreateDTO();

            await _mercadoRepo.CreateAsync(mercadoModel);

            return CreatedAtAction(nameof(ObterPorId), new { id = mercadoModel.Id }, mercadoModel.ToMercadoDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMercadoRequestDTO updateDto)
        {
            var mercadoModel = await _mercadoRepo.UpdateAsync(id, updateDto);

            if (mercadoModel == null)
            {
                return NotFound();
            }

            return Ok(mercadoModel.ToMercadoDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var mercadoModel = await _mercadoRepo.DeleteAsync(id);

            if (mercadoModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }

    }
}
using Microsoft.AspNetCore.Mvc;
using FinLensAPI.Interfaces;
using FinLensAPI.Mapping;



namespace FinLensAPI.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var comentarios = await _comentarioRepository.ObterTodosAsync();

            var comentarioDto = comentarios.Select(s => s.ToComentarioDTO());

            return Ok(comentarioDto);
        }

    }
}
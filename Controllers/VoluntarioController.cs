using BackEnd.Classes;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoluntarioController : ControllerBase
    {
        private readonly VoluntarioService _voluntarioService;

        public VoluntarioController(VoluntarioService voluntarioService)
        {
            _voluntarioService = voluntarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var instituicoes = await _voluntarioService.Get();
            return Ok(instituicoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var instituicao = await _voluntarioService.ObterPorId(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return Ok(instituicao);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] Voluntario model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var resultado = await _voluntarioService.Salvar(model);

            if (model.Id == 0)
            {
                return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado); /// 202
            }

            return NoContent(); /// 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var instituicao = await _voluntarioService.ObterPorId(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            await _voluntarioService.Excluir(id);
            return NoContent();
        }
    }
}

using BackEnd.Classes;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoService _instituicaoService;

        public InstituicaoController(InstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var instituicoes = await _instituicaoService.Get();
            return Ok(instituicoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var instituicao = await _instituicaoService.ObterPorId(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return Ok(instituicao);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] Instituicao instituicao)
        {
            if (instituicao == null)
            {
                return BadRequest();
            }

            // Usa o método Salvar para adicionar ou atualizar a instituição
            var resultado = await _instituicaoService.Salvar(instituicao);

            // Se a instituição for nova (não tiver ID), então o código de status será 201 (Criado)
            if (instituicao.Id == 0)
            {
                return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
            }

            // Caso contrário, o código de status será 204 (Sem Conteúdo)
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var instituicao = await _instituicaoService.ObterPorId(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            await _instituicaoService.Excluir(id);
            return NoContent();
        }
    }
}

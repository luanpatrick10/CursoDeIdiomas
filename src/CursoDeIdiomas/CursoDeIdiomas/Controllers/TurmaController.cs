using AutoMapper;
using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.Servicos;
using CursoDeIdiomas.Servicos.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private ICadastroDeTurmaServico _cadastroDeTurma;
        private IMapper _mapper;
        public TurmaController(ICadastroDeTurmaServico cadastroDeTurma, IMapper mapper)
        {
            _cadastroDeTurma = cadastroDeTurma;
            _mapper = mapper;
        }
        [HttpPost("cadastrar-turma")]
        public async Task<IActionResult> CadastrarTurma(NovaTurmaDTO novaTurmaDTO)
        {
            await _cadastroDeTurma.Criar(_mapper.Map<Turma>(novaTurmaDTO));
            return Ok();
        }
        [HttpGet("obter-todas-turmas")]
        public async Task<ActionResult<IEnumerable<TurmaDTO>>> ObterTurmas()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<TurmaDTO>>(_cadastroDeTurma.ObterTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obter-turmas/{id}")]
        public async Task<ActionResult<IEnumerable<TurmaDTO>>> ObterTurma(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<TurmaDTO>>(_cadastroDeTurma.ObterPorId(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("deletar-turma")]
        public async Task<ActionResult> DeletarTurma(int id)
        {
            try
            {
                await _cadastroDeTurma.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("atualizar-turma")]
        public async Task<ActionResult> AtualizarTurma(TurmaDTO turmaDTO)
        {
            try
            {
                await _cadastroDeTurma.Atualizar(_mapper.Map<Turma>(turmaDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

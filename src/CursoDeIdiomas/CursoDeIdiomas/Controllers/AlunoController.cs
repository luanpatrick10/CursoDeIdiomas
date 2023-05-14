using AutoMapper;
using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.Servicos;
using CursoDeIdiomas.Servicos.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private ICadastroDeAlunoServico _cadastroDeAluno;
        private IMapper _mapper;
        public AlunoController(ICadastroDeAlunoServico cadastroDeAluno, IMapper mapper)
        {
            _cadastroDeAluno = cadastroDeAluno;
            _mapper = mapper;
        }

        [HttpPost("cadastrar-aluno")]
        public async Task<IActionResult> CadastrarAluno(NovoAlunoDTO novoAlunoDTO)
        {
            try
            {
                await _cadastroDeAluno.Criar(_mapper.Map<Aluno>(novoAlunoDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cancelar-matricula-aluno")]
        public async Task<IActionResult> CancelaMatriculaDoAluno(int id)
        {
            try
            {
                await _cadastroDeAluno.CancelarMatriculaDoAluno(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("obter-todos-alunos")]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> ObterAlunos()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(await _cadastroDeAluno.ObterTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obter-aluno/{id}")]
        public async Task<ActionResult<AlunoDTO>> ObterAluno(int id)
        {
            try
            {
                return Ok(_mapper.Map<AlunoDTO>(await _cadastroDeAluno.ObterPorId(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deletar-aluno")]
        public async Task<ActionResult> DeletarAluno(int id)
        {
            try
            {
                await _cadastroDeAluno.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar-aluno")]
        public async Task<ActionResult> AtualizarAluno(AtualizarAlunoDTO atualizarAlunoDTO)
        {
            try
            {
                await _cadastroDeAluno.Atualizar(_mapper.Map<Aluno>(atualizarAlunoDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

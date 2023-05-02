using CursoDeIdiomas.Dominio.Servicos;
using CursoDeIdiomas.Servicos.DTOS;
using CursoDeIdiomas.Servicos.DTOS.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private ICadastroDeAlunoServico _cadastroDeAluno;
        public AlunoController(ICadastroDeAlunoServico cadastroDeAluno)
        {
            _cadastroDeAluno = cadastroDeAluno;
        }

        [HttpPost("cadastrar-aluno")]
        public async Task<IActionResult> CadastrarAluno(AlunoDTO alunoDTO)
        {
            try
            {
                await _cadastroDeAluno.Criar(alunoDTO.AlunoDTOAluno());
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
                return Ok(_cadastroDeAluno.ObterTodos().Result.AlunosToAlunosDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obter-aluno/{id}")]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> ObterAluno(int id)
        {
            try
            {
                return Ok(_cadastroDeAluno.ObterPorId(id).Result.AlunoToAlunoDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("deletar-aluno")]
        public async Task<ActionResult> DeletarAluno(AlunoDTO alunoDTO)
        {
            try
            {
                await _cadastroDeAluno.Deletar(alunoDTO.AlunoDTOAluno());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("atualizar-aluno")]
        public async Task<ActionResult> AtualizarAluno(AlunoDTO alunoDTO)
        {
            try
            {
                await _cadastroDeAluno.Atualizar(alunoDTO.AlunoDTOAluno());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

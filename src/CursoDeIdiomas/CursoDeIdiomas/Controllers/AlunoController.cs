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
        [HttpGet("obter-todos-alunos")]
        public async Task<ActionResult<ICollection<Aluno>>> ObterAlunos()
        {
            try
            {
                var todos = await _cadastroDeAluno.ObterTodos();
                return Ok(todos);
                //return Ok(_mapper.Map<ICollection<Aluno>>(_cadastroDeAluno.ObterTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obter-aluno/{id}")]
        public async Task<ActionResult<ICollection<AlunoDTO>>> ObterAluno(int id)
        {
            try
            {
                return Ok(_mapper.Map<ICollection<AlunoDTO>>(_cadastroDeAluno.ObterPorId(id)));
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
                await _cadastroDeAluno.Deletar(_mapper.Map<Aluno>(alunoDTO));
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
                await _cadastroDeAluno.Atualizar(_mapper.Map<Aluno>(alunoDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

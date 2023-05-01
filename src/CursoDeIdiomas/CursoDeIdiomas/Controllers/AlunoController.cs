using CursoDeIdiomas.Dominio.Entidades;
using CursoDeIdiomas.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private ICadastroDeTurmaServico _cadastroDeTurma;
        public AlunoController(ICadastroDeTurmaServico cadastroDeTurma)
        {
            _cadastroDeTurma = cadastroDeTurma;
        }
        [HttpPost]
        public async Task<IActionResult> CadastraTurma(Turma turma)
        {
            _cadastroDeTurma.Criar(turma);
            return Ok();
        }
    }
}

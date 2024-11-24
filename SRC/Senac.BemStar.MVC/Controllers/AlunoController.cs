using Microsoft.AspNetCore.Mvc;
using Senac.BemStar.Application.Interfaces;
using Senac.BemStar.Domain.DTOS;

namespace Senac.BemStar.MVC.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            var alunos = await _alunoService.ObterTodosAsync();
            return View(alunos);
        }

        // GET: Aluno/Detalhes/5
        public async Task<IActionResult> Detalhes(int id)
        {
            var aluno = await _alunoService.ObterPorIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // GET: Aluno/Criar
        public IActionResult Criar()
        {
            return View(new AlunoDTO());
        }

        // POST: Aluno/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([FromForm] AlunoDTO alunoDto)
        {
            if (ModelState.IsValid)
            {
                await _alunoService.CriarAsync(alunoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(alunoDto);
        }

        // GET: Aluno/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var aluno = await _alunoService.ObterPorIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [FromForm] AlunoDTO alunoDto)
        {
            if (id != alunoDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _alunoService.AtualizarAsync(id, alunoDto);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alunoDto);
        }

        // GET: Aluno/Excluir/5
        public async Task<IActionResult> Excluir(int id)
        {
            var aluno = await _alunoService.ObterPorIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmado(int id)
        {
            await _alunoService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

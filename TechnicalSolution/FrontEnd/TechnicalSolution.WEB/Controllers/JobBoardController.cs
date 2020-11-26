using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalSolution.EL;
using TechnicalSolution.EL.Configurations;
using TechnicalSolution.WEB.Helpers;

namespace TechnicalSolution.WEB.Controllers
{
    public class JobBoardController : Controller
    {
        private IApiService _helper;
        public JobBoardController()
        {
            _helper = new ApiService();
        }

        public async Task<IActionResult> Index()
        {
            var data = await _helper.GetListAsync<JobBoard>("JobBoard");
            return View(data.Data);
        }

        public async Task<IActionResult> Formulario(int id = 0)
        {
            ViewData["Action"] = "Add";
            var model = new JobBoard();
            if (id > 0)
            {
                var request = await _helper.GetSingleAsync<JobBoard>($"JobBoard/{id}");
                model = request.Data;
                ViewData["Action"] = "Edit";
            }
            return View(model);
        }

        public async Task<IActionResult> EjecutarTransaccion(JobBoard model, TransactionType tipoTransaccion)
        {
            var request = new BusinessValue<JobBoard>();
            switch (tipoTransaccion)
            {
                case TransactionType.Add:
                    request = await _helper.PostAsync("JobBoard", model);
                    break;
                case TransactionType.Edit:
                    request = await _helper.PutAsync($"JobBoard/{model.Id}", model);
                    break;
                case TransactionType.Delete:
                    request = await _helper.DeleteAsync<JobBoard>($"JobBoard/{model.Id}");
                    break;
            }
            if (request.Status.Equals(Status.OK))
                return RedirectToAction("Index");
            else
                return null;//Here we can show error view
        }

        public async Task<IActionResult> Delete(int id)
        {
            return await EjecutarTransaccion(new JobBoard { Id = id }, TransactionType.Delete);
        }
    }

    public enum TransactionType
    {
        Add, Edit, Delete, Get
    }
}

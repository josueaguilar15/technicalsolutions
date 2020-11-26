using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalSolution.EL;
using TechnicalSolution.EL.Configurations;
using TechnicalSolution.WEB.Helpers;
using TechnicalSolution.WEB.Models;

namespace TechnicalSolution.WEB.Controllers
{
    public class JobBoardController : Controller
    {
        private IApiService _helper;
        public JobBoardController()
        {
            _helper = new ApiService();
        }

        /// <summary>
        /// Show View with data
        /// </summary>
        /// <returns>View Action</returns>
        public async Task<IActionResult> Index()
        {
            var data = await _helper.GetListAsync<JobBoard>("JobBoard");
            return View(data.Data);
        }

        /// <summary>
        /// Show view with information in case edit or empty if it is a new record
        /// </summary>
        /// <param name="id">record id</param>
        /// <returns></returns>
        public async Task<IActionResult> Form(int id = 0)
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

        /// <summary>
        /// Invoke api method 
        /// </summary>
        /// <param name="model">Model with information</param>
        /// <param name="transactionType">DatatyTransactinon</param>
        public async Task<IActionResult> ExecuteTransaction(JobBoard model, TransactionType transactionType)
        {
            var request = new BusinessValue<JobBoard>();
            switch (transactionType)
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

        /// <summary>
        /// Invoke ExecuteTransaction to Delete
        /// </summary>
        /// <param name="id">record id to remove</param>
        public async Task<IActionResult> Delete(int id)
        {
            return await ExecuteTransaction(new JobBoard { Id = id }, TransactionType.Delete);
        }
    }
}

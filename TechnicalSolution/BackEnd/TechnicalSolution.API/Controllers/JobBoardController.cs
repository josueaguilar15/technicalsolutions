using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalSolution.BL.Interfaces;
using TechnicalSolution.EL;

namespace TechnicalSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobBoardController : APIControllerBase
    {
        private IJobBoardBL _blJobBoard;
        public JobBoardController(IJobBoardBL bl)
        {
            _blJobBoard = bl;
        }

        /// <summary>
        /// Add a new record by Business Layer
        /// </summary>
        /// <param name="model">Object with information to save</param>
        /// <returns>Action Result with information</returns>
        [HttpPost]
        public async Task<ActionResult<JobBoard>> PostAsync(JobBoard model)
        {
            return Result(await _blJobBoard.AddAsync(model));
        }

        //[HttpGet]
        //public async Task<ActionResult<JobBoard>> GetAsync()
        //{
        //    return Result(await _blJobBoard.GetAsync());
        //}

        
    }
}

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
        public async Task<ActionResult<JobBoard>> PostAsync(JobBoard model) => Result(await _blJobBoard.AddAsync(model));

        /// <summary>
        /// Update record by Business Layer
        /// </summary>
        /// <param name="id">record id</param>
        /// <param name="model">object with the information</param>
        /// <returns>Action Result with information</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, JobBoard model) => Result(await _blJobBoard.Update(id, model));

        /// <summary>
        /// Get  data by Business Layer
        /// </summary>
        /// <returns>Data from database</returns>
        [HttpGet]
        public async Task<ActionResult<JobBoard>> GetAsync() => Result(await _blJobBoard.GetAsync());

        /// <summary>
        /// delete record by Business Layer
        /// </summary>
        /// <param name="id">record id</param>
        /// <param name="model">object with the information</param>
        /// <returns>Action Result with information</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => Result(await _blJobBoard.Remove(id));

        /// <summary>
        /// Get record by Id by Business Layer
        /// </summary>
        /// <returns>Data from database</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<JobBoard>> GetByIdAsync(int id) => Result(await _blJobBoard.FindByIdAsync(id));


    }
}

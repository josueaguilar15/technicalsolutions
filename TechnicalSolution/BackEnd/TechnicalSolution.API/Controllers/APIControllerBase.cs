using Microsoft.AspNetCore.Mvc;
using System.Net;
using TechnicalSolution.EL.Configurations;

namespace TechnicalSolution.API.Controllers
{
    public abstract class APIControllerBase : ControllerBase
    {
        /// <summary>
        /// Format the response for the user
        /// </summary>
        /// <typeparam name="T">Datatype to process</typeparam>
        /// <param name="data">data to process</param>
        /// <returns>Information with Status</returns>
        public ActionResult Result<T>(BusinessValue<T> data)
        {
            return data.Status switch
            {
                Status.OK => Ok(new { Status = (int)HttpStatusCode.OK, data.Data, data.Message }),
                Status.NOT_FOUND => NotFound(new { Status = (int)HttpStatusCode.NotFound, data.Message }),
                _ => StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, data.Message })
            };
        }
    }
}

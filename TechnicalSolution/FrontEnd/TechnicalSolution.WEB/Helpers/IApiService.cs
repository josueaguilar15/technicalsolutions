using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalSolution.EL.Configurations;

namespace TechnicalSolution.WEB.Helpers
{
    public interface IApiService
    {
        /// <summary>
        /// Get a list of elements (GET verb)
        /// </summary>
        /// <typeparam name = "TResult"> Type of data expected in the result </typeparam>
        /// <param name = "url"> Segment of the url of the API to execute </param>
        /// <returns> Result of the action execution </returns>
        Task<BusinessValue<List<TResult>>> GetListAsync<TResult>(string url);

        /// <summary>
        /// Get an element (GET verb)
        /// </summary>
        /// <typeparam name = "TResult"> Type of data expected in the result </typeparam>
        /// <param name = "url"> Segment of the url of the API to execute </param>
        /// <returns> Result of the action execution </returns>
        Task<BusinessValue<TResult>> GetSingleAsync<TResult>(string url);

        /// <summary>
        /// Performs the insertion of an element (POST verb)
        /// </summary>
        /// <typeparam name = "TResult"> Type of data expected in the result </typeparam>
        /// <typeparam name = "TData"> Data type of the action content </typeparam>
        /// <param name = "url"> Segment of the url of the API to execute </param>
        /// <param name = "data"> Data to send in the action </param>
        /// <returns> Result of the action execution </returns>
        Task<BusinessValue<TData>> PostAsync<TData>(string url, TData data);

        /// <summary>
        /// Perform the complete update of an element (PUT verb)
        /// </summary>
        /// <typeparam name = "TResult"> Type of data expected in the result </typeparam>
        /// <typeparam name = "TData"> Data type of the action content </typeparam>
        /// <param name = "url"> Segment of the url of the API to execute </param>
        /// <param name = "data"> Data to send in the action </param>
        /// <returns> Result of the action execution </returns>
        Task<BusinessValue<TData>> PutAsync<TData>(string url, TData data);

        /// <summary>
        /// Execute the delete action (DELETE verb)
        /// </summary>
        /// <typeparam name = "TResult"> Type of data expected in the result </typeparam>
        /// <param name = "url"> Segment of the url of the API to execute </param>
        /// <returns> Result of the action execution </returns>
        Task<BusinessValue<TData>> DeleteAsync<TData>(string url);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalSolution.EL.Configurations;

namespace TechnicalSolution.WEB.Helpers
{
    public interface IApiService
    {
        /// <summary>
        /// Obtiene una lista de elementos (verbo GET)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        Task<BusinessValue<List<TResult>>> GetListAsync<TResult>(string url);

        /// <summary>
        /// Obtiene un elemento (verbo GET)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        Task<BusinessValue<TResult>> GetSingleAsync<TResult>(string url);

        /// <summary>
        /// Realiza la inserción de un elemento (verbo POST)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <typeparam name="TData">Tipo de dato del contenido de la acción</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <param name="data">Datos a enviar en la acción</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        Task<BusinessValue<TData>> PostAsync<TData>(string url, TData data);


        /// <summary>
        /// Realiza la actualización completa de un elemento (verbo PUT)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <typeparam name="TData">Tipo de dato del contenido de la acción</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <param name="data">Datos a enviar en la acción</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        Task<BusinessValue<TData>> PutAsync<TData>(string url, TData data);

        /// <summary>
        /// Ejecuta la acción de eliminación (verbo DELETE)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        Task<BusinessValue<TData>> DeleteAsync<TData>(string url);
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechnicalSolution.EL.Configurations;
using TechnicalSolution.WEB.Extensions;
using TechnicalSolution.WEB.Models;

namespace TechnicalSolution.WEB.Helpers
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;
        private string urlApiBase = "https://localhost:44351/api/";
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Servicio de gestión de HttpClient</param>
        public ApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(urlApiBase);
        }

        /// <summary>
        /// Indica si ocurrió un error (4xx a 5xx) durante la ejecución de la acción
        /// </summary>
        public bool IsError { get; private set; }

        /// <summary>
        /// Datos de error de la acción
        /// </summary>
        public ErrorDetails Error { get; private set; }

        /// <summary>
        /// Indica si ocurrió una excepción no controlada durante la ejecución de la acción
        /// </summary>
        public bool IsException { get; private set; }

        /// <summary>
        /// Excepción no controlada ocurrida durante la ejecución de la acción
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Excepción interna de la excepción no controlada (si aplica)
        /// </summary>
        public Exception InnerException { get; private set; }

        /// <summary>
        /// Acción previa a ejecutar antes del método Http
        /// </summary>
        public Action<HttpClient> PreExecution { get; set; }

        /// <summary>
        /// Realiza la ejecución de las acciones Http
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="operation">Acción Http a realizar</param>
        /// <param name="customResult">Acción personalizada para crear el resultado de la acción</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        private async Task<TResult> ExecuteOperationAsync<TResult>(Func<HttpClient, Task<HttpResponseMessage>> operation, Action<HttpResponseMessage, string, TResult> customResult)
        {
            TResult resultado;
            if (typeof(TResult).IsClass && typeof(TResult).GetConstructors().Where(x => x.GetParameters().Count() == 0).Count() != 0)
            {
                resultado = Activator.CreateInstance<TResult>();
            }
            else
            {
                resultado = default;
            }
            try
            {
                PreExecution?.Invoke(_client);
                HttpResponseMessage response = await operation.Invoke(_client);
                string stringResult = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    if (customResult != null)
                    {
                        customResult.Invoke(response, stringResult, resultado);
                    }
                    else
                    {
                        resultado = JsonConvert.DeserializeObject<TResult>(stringResult);
                    }
                }
                else
                {
                    IsError = true;
                    Error = JsonConvert.DeserializeObject<ErrorDetails>(stringResult);
                }
            }
            catch (Exception ex)
            {
                IsException = true;
                Exception = ex;
                InnerException = ex.DeepInnerException();
                throw;
            }
            return resultado;
        }

        /// <summary>
        /// Realiza la ejecución de las acciones Http
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="operation">Acción Http a realizar</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        private async Task<TResult> ExecuteOperationAsync<TResult>(Func<HttpClient, Task<HttpResponseMessage>> operation)
        {
            return await ExecuteOperationAsync<TResult>(operation, null);
        }

        /// <summary>
        /// Obtiene una lista de elementos (verbo GET)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        public Task<BusinessValue<List<TResult>>> GetListAsync<TResult>(string url)
        {
            if (url.StartsWith("/"))
            {
                throw new ArgumentException("Los segmentos de la Url no deben iniciar con el caracter \"/\"", "url");
            }
            return ExecuteOperationAsync<BusinessValue<List<TResult>>>(client =>
            {
                return client.GetAsync(url);
            });
        }

        /// <summary>
        /// Obtiene un elemento (verbo GET)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        public Task<BusinessValue<TResult>> GetSingleAsync<TResult>(string url)
        {
            if (url.StartsWith("/"))
            {
                throw new ArgumentException("Los segmentos de la Url no deben iniciar con el caracter \"/\"", "url");
            }
            return ExecuteOperationAsync<BusinessValue<TResult>>(client =>
            {
                return client.GetAsync(url);
            });
        }

        /// <summary>
        /// Realiza la inserción de un elemento (verbo POST)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <typeparam name="TData">Tipo de dato del contenido de la acción</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <param name="data">Datos a enviar en la acción</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        public Task<BusinessValue<TData>> PostAsync<TData>(string url, TData data)
        {
            if (url.StartsWith("/"))
            {
                throw new ArgumentException("Los segmentos de la Url no deben iniciar con el caracter \"/\"", "url");
            }
            return ExecuteOperationAsync<BusinessValue<TData>>(client =>
            {
                return client.PostAsJsonAsync(url, data);
            });
        }

        /// <summary>
        /// Realiza la actualización completa de un elemento (verbo PUT)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <typeparam name="TData">Tipo de dato del contenido de la acción</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <param name="data">Datos a enviar en la acción</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        public async Task<BusinessValue<TData>> PutAsync<TData>(string url, TData data)
        {
            if (url.StartsWith("/"))
            {
                throw new ArgumentException("Los segmentos de la Url no deben iniciar con el caracter \"/\"", "url");
            }
            return await ExecuteOperationAsync<BusinessValue<TData>>(client =>
            {
                return client.PutAsJsonAsync(url, data);
            });
        }

        /// <summary>
        /// Ejecuta la acción de eliminación (verbo DELETE)
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato esperado en el resultado</typeparam>
        /// <param name="url">Segmento de la url de la API a ejecutar</param>
        /// <returns>Resultado de la ejecución de la acción</returns>
        public async Task<BusinessValue<TData>> DeleteAsync<TData>(string url)
        {
            if (url.StartsWith("/"))
            {
                throw new ArgumentException("Los segmentos de la Url no deben iniciar con el caracter \"/\"", "url");
            }
            return await ExecuteOperationAsync<BusinessValue<TData>>(client =>
            {
                return client.DeleteAsync(url);
            });
        }
    }
}

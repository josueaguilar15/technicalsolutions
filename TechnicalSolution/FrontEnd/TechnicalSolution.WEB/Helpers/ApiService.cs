using Microsoft.Extensions.Configuration;
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
    /// <summary>
    /// Implement IApiService interface, if you want to see the methods comments, you must place the cursor over the method, comments are inherited
    /// </summary>
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;
        private string urlApiBase = "";
        private readonly IConfiguration _config;

        public ApiService(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
            urlApiBase = _config.GetValue<string>("UrlApi");
            _client.BaseAddress = new Uri(urlApiBase);
        }
        public bool IsError { get; private set; }
        public ErrorDetails Error { get; private set; }
        public bool IsException { get; private set; }
        public Exception Exception { get; private set; }

        public Exception InnerException { get; private set; }
        public Action<HttpClient> PreExecution { get; set; }

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

        private async Task<TResult> ExecuteOperationAsync<TResult>(Func<HttpClient, Task<HttpResponseMessage>> operation)
        {
            return await ExecuteOperationAsync<TResult>(operation, null);
        }

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

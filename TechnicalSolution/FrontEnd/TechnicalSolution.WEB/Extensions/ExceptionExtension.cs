using System;

namespace TechnicalSolution.WEB.Extensions
{
    public static class ExceptionExtension
    {
        /// <summary>
        /// Devuelve la excepción interna segun datos de configuración
        /// </summary>
        /// <param name="ex">Excepción a buscar su excepción interna</param>
        /// <returns>Excepción interna</returns>
        public static Exception DeepInnerException(this Exception ex, int maxDeep = 3)
        {
            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    return GetInnerException(ex, 0, maxDeep);
                }
            }
            return null;
        }

        /// <summary>
        /// Realiza un recorrido recursivo para encontrar la excepción interna
        /// </summary>
        /// <param name="ex">Excepción</param>
        /// <param name="recursion">Nivel de recursión actual</param>
        /// <returns>Excepción interna</returns>
        private static Exception GetInnerException(Exception ex, int recursion, int maxDeep)
        {
            if (ex.InnerException == null)
            {
                return ex;
            }
            else
            {
                if (recursion > maxDeep)
                {
                    return ex;
                }
                else
                {
                    recursion++;
                    return GetInnerException(ex.InnerException, recursion, maxDeep);
                }
            }
        }
    }
}

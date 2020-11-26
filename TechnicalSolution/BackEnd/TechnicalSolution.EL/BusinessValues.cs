using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalSolution.EL
{
    public class BusinessValue<TDTO>
    {
        public BusinessValue()
        {
        }

        public BusinessValue(string message, Status status)
        {
            Message = message;
            Status = status;
        }

        public BusinessValue(TDTO data, Status status)
        {
            Data = data;
            Status = status;
        }

        public BusinessValue(TDTO data, string message, Status status)
        {
            Data = data;
            Status = status;
            Message = message;
        }

        public TDTO Data { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
    }

    public enum Status
    {
        OK, // Indica que la operación es correcta
        ERROR, // Es un error general provocado por una excepción comunmente
        NOT_FOUND, // Indica que un recurso no se encuentra o no existe
    }
}

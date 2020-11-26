using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalSolution.EL.Configurations
{
    public enum Status
    {
        OK, // Indicates that the operation is correct
        ERROR, // It is a general error caused by an exception
        NOT_FOUND, // Indicates that a resource can't be found or doesn't exist
    }
}

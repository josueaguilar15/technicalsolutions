using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalSolution.EL.Configurations
{
    public enum Status
    {
        OK=200, // Indicates that the operation is correct
        ERROR=500, // It is a general error caused by an exception
        NOT_FOUND=404, // Indicates that a resource can't be found or doesn't exist
    }
}

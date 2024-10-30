using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.Exceptions
{
    public class InputFormatException : Exception
    {
        public InputFormatException(string message) : base(message) { }
    }
}

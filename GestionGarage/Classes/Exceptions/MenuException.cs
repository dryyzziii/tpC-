using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.Exceptions
{
    internal class MenuException : Exception
    {
        public MenuException(string message) : base(message)
        {
        }
    }
}

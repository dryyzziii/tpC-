using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.Exceptions
{
    public class NegativeValueException : Exception
    {
        public NegativeValueException(string attribute)
            : base($"La valeur de {attribute} ne peut pas être négative.") { }
    }
}

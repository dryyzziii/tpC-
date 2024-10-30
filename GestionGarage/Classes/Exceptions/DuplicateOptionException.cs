using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.Exceptions
{
    public class DuplicateOptionException : Exception
    {
        public DuplicateOptionException(string nom)
            : base($"L'option '{nom}' est déjà présente pour ce véhicule.") { }
    }
}

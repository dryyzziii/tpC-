using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace GestionGarage.Classes.Exceptions
{
    public class OptionNotFoundException : Exception
    {
        public OptionNotFoundException(int id)
            : base($"L'option avec l'ID {id} n'existe pas dans le garage.") { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace GestionGarage.Classes.Exceptions
{
    public class EmptyGarageException : Exception
    {
        public EmptyGarageException(string entity)
            : base($"Aucun {entity} n'est disponible dans le garage.") { }
    }
}

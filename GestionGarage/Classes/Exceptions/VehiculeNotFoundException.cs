﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace GestionGarage.Classes.Exceptions
{
    public class VehiculeNotFoundException : Exception
    {
        public VehiculeNotFoundException(int id)
            : base($"Le véhicule avec l'ID {id} n'existe pas dans le garage.") { }
    }
}


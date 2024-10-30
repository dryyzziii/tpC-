using System;


namespace GestionGarage.Classes.Exceptions
{
    public class MoteurNotFoundException : Exception
    {
        public MoteurNotFoundException(int id)
            : base($"Le moteur avec l'ID {id} n'existe pas dans le garage.") { }
    }
}


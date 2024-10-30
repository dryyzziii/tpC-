using System;


namespace GestionGarage.Classes.Exceptions
{
    public class GarageFileException : Exception
    {
        public GarageFileException(string message) : base(message) { }
    }
}


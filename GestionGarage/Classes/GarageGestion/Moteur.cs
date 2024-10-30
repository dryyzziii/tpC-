using GestionGarage.Classes.GarageGestion.Enum_Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionGarage.Classes.GarageGestion
{
    internal class Moteur
    {
        #region private attributes
        private static int increment = 0;

        private TypeMoteur type;
        private decimal puissance;
        private int id;
        #endregion

        #region public attributes
        public TypeMoteur Type { get => type; set => type = value; }
        public decimal Puissance { get => puissance; set => puissance = value; }
        public int Id { get => id; set => id = value; }
        #endregion

        #region constructor
        public Moteur() { }

        
        public Moteur(TypeMoteur Type, decimal Puissance)
        {
            this.id = ++increment;
            this.type = Type;
            this.puissance = Puissance;
        }

        [JsonConstructor]
        public Moteur(TypeMoteur Type, decimal Puissance, int Id)
        {
            this.Id = Id;
            this.Type = Type;
            this.Puissance = Puissance;
        }

        #endregion


        public void Afficher()
        {
            Console.WriteLine($"Moteur {id} \nPuissance : {puissance} \nType: {type}\n");
        }
    }
}

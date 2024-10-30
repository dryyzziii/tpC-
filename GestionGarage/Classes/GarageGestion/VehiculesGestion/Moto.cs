using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.Enum_Garage;

namespace GestionGarage.Classes.GarageGestion.VehiculesGestion
{
    internal class Moto : Vehicule
    {
        #region private attributes
        private int cylindres;
        #endregion

        #region public attributes
        public int Cylindres { get => cylindres; set => cylindres = value; }
        #endregion

        #region constructor 
        public Moto() { }

        public Moto(int Cylindres, string Nom,
            int PrixHT,
            Marque Marque,
            Moteur Moteur) : base(Nom, PrixHT, Marque, Moteur)
        {
            this.Cylindres = Cylindres;
        }


        [JsonConstructor]
        public Moto(int id, string nom, int prixHT,
            List<Option> optionsList, Marque marque, Moteur moteur, int cylindres)
            : base(nom, prixHT, marque, moteur, optionsList, id)
        {
            this.Cylindres = cylindres;
        }

        #endregion
        public override decimal CalculerTaxe()
        {
            return (decimal)Math.Floor(Cylindres * 0.3);
        }
    }
}

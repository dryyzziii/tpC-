using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Moto(int cylindres, string nom,
            int prixHT,
            Marque marque,
            Moteur moteur) : base(nom, prixHT, marque, moteur)
        {
            this.cylindres = cylindres;
        }
        #endregion
        public override decimal CalculerTaxe()
        {
            return (decimal)Math.Floor(cylindres * 0.3);
        }
    }
}

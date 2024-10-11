using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.Enum_Garage;

namespace GestionGarage.Classes.GarageGestion.VehiculesGestion
{
    internal class Camion : Vehicule
    {
        #region private attributes
        private int nbEssieu;
        private int poids;
        private int volume;
        #endregion

        #region public attributes
        public int NbEssieu { get => nbEssieu; set => nbEssieu = value; }
        public int Poids { get => poids; set => poids = value; }
        public int Volume { get => volume; set => volume = value; }
        #endregion

        #region constructor 
        public Camion() { }

        public Camion(int nbEssieu, int poids, int volume, string nom, int prixHT, Marque marque, Moteur moteur)
            : base(nom, prixHT, marque, moteur)
        {
            this.nbEssieu = nbEssieu;
            this.poids = poids;
            this.volume = volume;
        }
        #endregion
        public override decimal CalculerTaxe()
        {
            return nbEssieu * 50;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes
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

        public Camion(int nbEssieu, int poids, int volume, string nom, int prixHT, List<Option> options, Marque marque, Moteur moteur)
            : base(nom, prixHT, options, marque, moteur)
        {
            this.nbEssieu = nbEssieu;
            this.poids = poids;
            this.volume = volume;
        }
        #endregion
        public override decimal CalculerTaxe()
        {
            return this.nbEssieu * 50;
        }
    }
}

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

        public Camion(int NbEssieu, int Poids, int Volume, string Nom, int PrixHT, Marque Marque, Moteur Moteur)
            : base(Nom, PrixHT, Marque, Moteur)
        {
            this.nbEssieu = NbEssieu;
            this.poids = Poids;
            this.volume = Volume;
        }

        [JsonConstructor]
        public Camion(int NbEssieu, int Poids, int Volume, string Nom, int PrixHT, Marque Marque, Moteur Moteur, List<Option> OptionsList, int Id)
            : base(Nom, PrixHT, Marque, Moteur, OptionsList, Id)
        {
            this.NbEssieu = NbEssieu;
            this.Poids = Poids;
            this.Volume = Volume;
        }
        #endregion
        public override decimal CalculerTaxe()
        {
            return nbEssieu * 50;
        }
    }
}

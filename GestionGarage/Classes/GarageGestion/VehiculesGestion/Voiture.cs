using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.Enum_Garage;

namespace GestionGarage.Classes.GarageGestion.VehiculesGestion
{
    internal class Voiture : Vehicule
    {
        #region private attributes
        private int cheveauxFiscaux;
        private int nbSiege;
        private int nbPorte;
        private int tailleCoffre;
        #endregion

        #region public attributes 
        public int CheveauxFiscaux { get => cheveauxFiscaux; set => cheveauxFiscaux = value; }
        public int NbSiege { get => nbSiege; set => nbSiege = value; }
        public int NbPorte { get => nbPorte; set => nbPorte = value; }
        public int TailleCoffre { get => tailleCoffre; set => tailleCoffre = value; }
        #endregion

        #region constructor
        public Voiture() { }

        public Voiture(
            string nom,
            int prixHT,
            Marque marque,
            Moteur moteur,
            int tailleCoffre,
            int cheveauxFiscaux,
            int nbPorte,
            int nbSiege) : base(nom, prixHT, marque, moteur)
        {
            this.tailleCoffre = tailleCoffre;
            this.nbPorte = nbPorte;
            this.nbSiege = nbSiege;
            this.cheveauxFiscaux = cheveauxFiscaux;
        }


        #endregion
        public override decimal CalculerTaxe()
        {
            return cheveauxFiscaux * 10;
        }

    }
}

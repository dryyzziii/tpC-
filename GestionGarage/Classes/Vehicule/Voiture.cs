using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes
{
    internal class Voiture: Vehicule
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
            List<Option> options,
            Marque marque,
            Moteur moteur,
            int tailleCoffre,
            int cheveauxFiscaux,
            int nbPorte,
            int nbSiege) : base(nom, prixHT, options, marque, moteur)
        {
            this.tailleCoffre = tailleCoffre;
            this.nbPorte = nbPorte;
            this.nbSiege = nbSiege;
            this.cheveauxFiscaux = cheveauxFiscaux;
        }


        #endregion
        public override decimal CalculerTaxe()
        {
            return this.cheveauxFiscaux * 10;
        }

    }
}

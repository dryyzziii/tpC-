using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes
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
            List<Option> options,
            Marque marque,
            Moteur moteur) : base(nom, prixHT, options, marque, moteur)
        {
            this.cylindres = cylindres;
        }
        #endregion
        public override decimal CalculerTaxe()
        {
            return (decimal)Math.Floor(this.cylindres * 0.3);
        }
    }
}

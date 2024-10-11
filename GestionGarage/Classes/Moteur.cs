using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes
{
    internal class Moteur
    {
        #region private attributes
        private static int increment = 0;

        private int id;
        private string nom;
        private decimal puissance;
        #endregion

        #region public attributes
        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Puissance { get => puissance; set => puissance = value; }
        #endregion

        #region constructor
        public Moteur() {}


        public Moteur(string name, decimal prix)
        {
            this.id = ++increment;
            this.nom = name;
            this.puissance = prix;
        }
        #endregion


        public void Afficher()
        {
            Console.WriteLine($"Moteur {id} \nName : {nom}\nPuissance : {puissance}");
        }
    }
}

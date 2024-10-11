using GestionGarage.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes
{
    internal abstract class Vehicule
    {
        #region private attributes
        private static int increment = 0;

        private int id;
        private string nom;
        private decimal prixHT;
        private List<Option> optionsList;
        private Marque marque;
        private Moteur moteur;
        #endregion

        #region public attributes
        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public decimal PrixHT { get => prixHT; set => prixHT = value; }
        public List<Option> OptionsList { get => optionsList; set => optionsList = value; }
        public Marque Marque { get => marque; set => marque = value; }
        public Moteur Moteur { get => moteur; set => moteur = value; }
        #endregion

        #region constructor
        public Vehicule() { }


        public Vehicule(string nom, int prixHT, List<Option> options, Marque marque, Moteur moteur)
        {
            this.id = ++increment;
            this.nom = nom;
            this.prixHT = prixHT;
            this.optionsList = options;
            this.marque = marque;
            this.moteur = moteur;
        }
        #endregion

        #region public methodes
        public void Afficher()
        {
            Console.WriteLine($"Vehicule {id} \nNom : {this.nom}\nMarque : {marque}\nPrix: {this.prixHT}\n");
            this.optionsList.ForEach( option => option.Afficher() );
            this.Moteur.Afficher();
        }
        public void AfficherOptions()
        {
            this.optionsList.ForEach(op => op.Afficher());
        }
        public void AjouterOptions(Option op)
        {
            this.optionsList.Add(op);
        }
        public decimal PrixTotal()
        {
            decimal price = this.prixHT + CalculerTaxe();
            this.optionsList.ForEach(op => price += op.Prix);
            return price;
        }
        #endregion

        #region abstract public methodes
        public abstract decimal CalculerTaxe();
        #endregion
    }
}

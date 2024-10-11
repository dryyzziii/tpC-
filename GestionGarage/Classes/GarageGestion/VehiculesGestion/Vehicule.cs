using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.Enum_Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.GarageGestion.VehiculesGestion
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


        public Vehicule(string nom, int prixHT, Marque marque, Moteur moteur)
        {
            id = ++increment;
            this.nom = nom;
            this.prixHT = prixHT;
            optionsList = new List<Option>();
            this.marque = marque;
            this.moteur = moteur;
        }
        #endregion

        #region public methodes
        public void Afficher()
        {
            // Affichage avec couleurs et structure
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n========== Détails du véhicule (ID: {id}) ==========");
            Console.ResetColor();

            Console.WriteLine($"Nom       : {nom}");
            Console.WriteLine($"Marque    : {marque}");
            Console.WriteLine($"Prix Total: {PrixTotal()}€ (HT : {prixHT}€, Taxes : {CalculerTaxe()}€)");

            // Affichage des options
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nOptions :");
            Console.ResetColor();
            if (optionsList.Count > 0)
            {
                optionsList.ForEach(option => option.Afficher());
            }
            else
            {
                Console.WriteLine("Aucune option disponible.");
            }

            // Affichage du moteur
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMoteur :");
            Console.ResetColor();
            Moteur.Afficher();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=============================================\n");
            Console.ResetColor();
        }
        public void AfficherOptions()
        {
            optionsList.ForEach(op => op.Afficher());
        }
        public void AjouterOptions(Option op)
        {
            optionsList.Add(op);
        }
        public decimal PrixTotal()
        {
            decimal price = prixHT + CalculerTaxe();
            optionsList.ForEach(op => price += op.Prix);
            return price;
        }
        #endregion

        #region abstract public methodes
        public abstract decimal CalculerTaxe();
        #endregion
    }
}

using GestionGarage.Classes.Exceptions;
using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.Enum_Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal PrixHT { get => prixHT; set => prixHT = value; }
        public List<Option> OptionsList { get => optionsList; set => optionsList = value; }
        public Marque Marque { get => marque; set => marque = value; }
        public Moteur Moteur { get => moteur; set => moteur = value; }
        #endregion

        #region constructor
  
        public Vehicule() 
        {
            this.id = ++increment;
            OptionsList = new List<Option>();
        }

        public Vehicule(string Nom, int PrixHT, Marque Marque, Moteur Moteur)
        {
            id = ++increment;
            this.nom = Nom;
            this.prixHT = PrixHT;
            this.optionsList = new List<Option>();
            this.marque = Marque;
            this.moteur = Moteur;
        }

        [JsonConstructor]
        public Vehicule(string Nom, int PrixHT, Marque Marque, Moteur Moteur, List<Option> OptionsList, int Id)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.prixHT = PrixHT;
            this.optionsList = OptionsList;
            this.marque = Marque;
            this.moteur = Moteur;
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
            Console.WriteLine($"Prix Total: {PrixTotal()}€ (HT : {prixHT}€, Taxes : {PrixTotal() - prixHT}€)");

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
            if (optionsList.Any(o => o.Id == op.Id))
            {
                throw new DuplicateOptionException(op.Nom);
            }
            optionsList.Add(op);
        }


        public void SupprimerOption(int id)
        {
            Option op = optionsList.Find(v => v.Id == id);
            if (op != null)
            {
                optionsList.Remove(op);
            }
            else
            {
                throw new Exception("Option non trouvé.");
            }
        }
        public bool OptionExiste(int id)
        {
            return optionsList.Find(v => v.Id == id) != null;
        }


        public Option GetOptionById(int id)
        {
            Option op = optionsList.Find(o => o.Id == id);
            if (op != null)
            {
                return op;
            }
            else
            {
                throw new Exception("Option non trouvé.");
            }
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

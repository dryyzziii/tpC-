using GestionGarage.Classes.GarageGestion.Enum_Garage;
using GestionGarage.Classes.GarageGestion.VehiculesGestion;
using GestionGarage.Classes.GarageGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.MenuGestion
{
    internal class MenuVehicule
    {
        private Garage garage;

        public MenuVehicule(Garage garage)
        {
            this.garage = garage;
        }

        public void AjouterVehicule()
        {
            Console.WriteLine("\n===== Ajouter un nouveau véhicule =====");

            // Saisie du nom du véhicule
            Console.Write("Entrez le nom du véhicule : ");
            string nom = Console.ReadLine();

            // Saisie du prix du véhicule
            Console.Write("Entrez le prix HT du véhicule : ");
            decimal prixHT;
            while (!decimal.TryParse(Console.ReadLine(), out prixHT))
            {
                Console.WriteLine("Le prix doit être un nombre valide.");
                Console.Write("Entrez le prix HT du véhicule : ");
            }

            // Afficher toutes les marques et choisir une marque
            Console.WriteLine("\n===== Sélectionnez la marque =====");
            Array marques = Enum.GetValues(typeof(Marque));
            for (int i = 0; i < marques.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {marques.GetValue(i)}");
            }
            Console.Write("Entrez le numéro de la marque : ");
            int choixMarque;
            while (!int.TryParse(Console.ReadLine(), out choixMarque) || choixMarque < 1 || choixMarque > marques.Length)
            {
                Console.WriteLine("Choix non valide. Sélectionnez une marque valide.");
                Console.Write("Entrez le numéro de la marque : ");
            }
            Marque marque = (Marque)marques.GetValue(choixMarque - 1);

            // Sélection du moteur
            Console.WriteLine("\n===== Sélectionnez le moteur =====");
            garage.AfficherTypesMoteursDisponibles();
            Console.Write("Entrez l'ID du moteur : ");
            int moteurId;
            while (!int.TryParse(Console.ReadLine(), out moteurId) || !garage.MoteurExiste(moteurId))
            {
                Console.WriteLine("ID du moteur non valide.");
                Console.Write("Entrez l'ID du moteur : ");
            }
            Moteur moteur = garage.GetMoteurById(moteurId);

            // Création et ajout du véhicule
            Vehicule vehicule = new Voiture(nom, prixHT, new List<Option>(), marque, moteur, 5, 300, 5, 5);
            garage.AjouterVehicule(vehicule);

            Console.WriteLine($"\nLe véhicule {nom} a été ajouté avec succès !");
        }

        public void SupprimerVehicule()
        {
            Console.WriteLine("\n===== Supprimer un véhicule =====");

            garage.AfficherTousVehicules();

            Console.Write("Entrez l'ID du véhicule à supprimer : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.WriteLine("ID du véhicule non valide.");
                Console.Write("Entrez l'ID du véhicule à supprimer : ");
            }

            garage.SupprimerVehicule(vehiculeId);
            Console.WriteLine($"Le véhicule avec l'ID {vehiculeId} a été supprimé avec succès.");
        }

        public void SelectionnerVehicule()
        {
            Console.WriteLine("\n===== Sélectionner un véhicule =====");

            garage.Afficher();

            Console.Write("Entrez l'ID du véhicule à sélectionner : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.WriteLine("ID du véhicule non valide.");
                Console.Write("Entrez l'ID du véhicule à sélectionner : ");
            }

            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);
            Console.WriteLine($"\nVéhicule sélectionné : {vehicule.Nom}");
            vehicule.Afficher();
        }

        public void AfficherOptionsVehicule()
        {
            Console.WriteLine("\n===== Afficher les options d'un véhicule =====");

            garage.AfficherTousVehicules();

            Console.Write("Entrez l'ID du véhicule : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.WriteLine("ID du véhicule non valide.");
                Console.Write("Entrez l'ID du véhicule : ");
            }

            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);
            vehicule.AfficherOptions();
        }

        public void AjouterOptionsVehicule()
        {
            Console.WriteLine("\n===== Ajouter des options à un véhicule =====");

            garage.AfficherTousVehicules();

            Console.Write("Entrez l'ID du véhicule : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.WriteLine("ID du véhicule non valide.");
                Console.Write("Entrez l'ID du véhicule : ");
            }

            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);

            garage.AfficherToutesOptions();
            Console.Write("Entrez l'ID de l'option à ajouter : ");
            int optionId;
            while (!int.TryParse(Console.ReadLine(), out optionId) || !garage.OptionExiste(optionId))
            {
                Console.WriteLine("ID de l'option non valide.");
                Console.Write("Entrez l'ID de l'option à ajouter : ");
            }

            Option option = garage.GetOptionById(optionId);
            vehicule.AjouterOptions(option);

            Console.WriteLine($"L'option {option.Nom} a été ajoutée au véhicule {vehicule.Nom}.");
        }

        public void SupprimerOptionsVehicule()
        {
            Console.WriteLine("\n===== Supprimer des options d'un véhicule =====");

            garage.AfficherTousVehicules();

            Console.Write("Entrez l'ID du véhicule : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.WriteLine("ID du véhicule non valide.");
                Console.Write("Entrez l'ID du véhicule : ");
            }

            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);

            vehicule.AfficherOptions();
            Console.Write("Entrez l'ID de l'option à supprimer : ");
            int optionId;
            while (!int.TryParse(Console.ReadLine(), out optionId) || !vehicule.OptionExiste(optionId))
            {
                Console.WriteLine("ID de l'option non valide.");
                Console.Write("Entrez l'ID de l'option à supprimer : ");
            }

            Option option = vehicule.GetOptionById(optionId);
            vehicule.SupprimerOption(optionId);

            Console.WriteLine($"L'option {option.Nom} a été supprimée du véhicule {vehicule.Nom}.");
        }
    }
}

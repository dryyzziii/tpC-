using System;
using System.Collections.Generic;

namespace GestionGarage.Classes.Test
{
    internal class GarageTest
    {
        public void TesterGarage()
        {
            // Début des tests
            AfficherTitre("\nDémarrage des tests de gestion du garage...\n");

            // Création de plusieurs options
            Option option1 = new Option("Climatisation", 1200);
            Option option2 = new Option("GPS", 800);
            Option option3 = new Option("Sièges chauffants", 600);
            Option option4 = new Option("Caméra de recul", 500);
            Option option5 = new Option("Toit ouvrant", 1500);

            // Création de plusieurs véhicules avec options spécifiques
            List<Option> optionsVoiture1 = new List<Option> { option1, option2, option3 };
            List<Option> optionsVoiture2 = new List<Option> { option4, option5 };
            List<Option> optionsMoto1 = new List<Option> { option1 };
            List<Option> optionsMoto2 = new List<Option> { option2, option3 };
            List<Option> optionsCamion1 = new List<Option> { option4, option5 };

            Moteur moteur1 = new Moteur("nom moteur1", 2000);
            Moteur moteur2 = new Moteur("nom moteur2", 2000);
            Moteur moteur3 = new Moteur("nom moteur3", 2000);
            Moteur moteur4 = new Moteur("nom moteur4", 2000);
            Moteur moteur5 = new Moteur("nom moteur5", 2000);

            Voiture voiture1 = new Voiture("Renault Clio", 15000, optionsVoiture1, Marque.Renault, moteur1, 5, 300, 5, 5);
            Voiture voiture2 = new Voiture("Peugeot 308", 18000, optionsVoiture2, Marque.Peugeot, moteur2, 8, 400, 5, 5);
            Moto moto1 = new Moto(10, "Yamaha MT-07", 8000, optionsMoto1, Marque.Peugeot, moteur3);
            Moto moto2 = new Moto(11, "Ducati Monster", 12000, optionsMoto2, Marque.Renault, moteur4);
            Camion camion1 = new Camion(10, 1000, 10, "Mercedes Actros", 80000, optionsCamion1, Marque.Audi, moteur5);

            // Création du garage
            Garage monGarage = new Garage("Mon Garage", new List<Vehicule>());

            // Ajout des véhicules au garage
            monGarage.AjouterVehicule(voiture1);
            monGarage.AjouterVehicule(voiture2);
            monGarage.AjouterVehicule(moto1);
            monGarage.AjouterVehicule(moto2);
            monGarage.AjouterVehicule(camion1);

            // Afficher tous les véhicules avant le tri
            AfficherTitre("\nVéhicules avant le tri :\n");
            monGarage.Afficher();

            // Tester le tri des véhicules par prix total (HT + taxe)
            monGarage.TrierVehicule();

            // Afficher les véhicules après le tri
            AfficherTitre("\nVéhicules après le tri par prix total :\n");
            monGarage.Afficher();

            // Fin des tests
            AfficherTitre("\nFin des tests du garage.\n");
        }

        private void AfficherTitre(string titre)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n==============================");
            Console.WriteLine(titre);
            Console.WriteLine("==============================");
            Console.ResetColor();
        }
    }
}

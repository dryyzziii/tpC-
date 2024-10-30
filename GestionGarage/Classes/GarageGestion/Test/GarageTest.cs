using System;
using System.Collections.Generic;
using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.Enum_Garage;
using GestionGarage.Classes.GarageGestion.VehiculesGestion;

namespace GestionGarage.Classes.GarageGestion.Test
{
    internal class GarageTest
    {
        public Garage TesterGarage()
        {
            // Début des tests
            AfficherTitre("\nDémarrage des tests de gestion du garage...\n");
            Garage monGarage = new Garage("Mon Garage");
            // Création de plusieurs options
            Option option1 = new Option("Climatisation", 1200);
            Option option2 = new Option("GPS", 800);
            Option option3 = new Option("Sièges chauffants", 600);
            Option option4 = new Option("Caméra de recul", 500);
            Option option5 = new Option("Toit ouvrant", 1500);

            monGarage.AjouterOption(option1);
            monGarage.AjouterOption(option2);
            monGarage.AjouterOption(option3);
            monGarage.AjouterOption(option4);
            monGarage.AjouterOption(option5);


            Moteur moteur1 = new Moteur(TypeMoteur.Diesel, 2000);
            Moteur moteur2 = new Moteur(TypeMoteur.Hybride, 2000);
            Moteur moteur3 = new Moteur(TypeMoteur.Electrique, 2000);
            Moteur moteur4 = new Moteur(TypeMoteur.Essence, 2000);
            Moteur moteur5 = new Moteur(TypeMoteur.Diesel, 2000);

            monGarage.AjouterMoteur(moteur1);
            monGarage.AjouterMoteur(moteur2);
            monGarage.AjouterMoteur(moteur3);
            monGarage.AjouterMoteur(moteur4);
            monGarage.AjouterMoteur(moteur5);

            Voiture voiture1 = new Voiture("Renault Clio", 15000, Marque.Renault, moteur1, 5, 300, 5, 5);
            Voiture voiture2 = new Voiture("Peugeot 308", 18000, Marque.Peugeot, moteur2, 8, 400, 5, 5);
            Moto moto1 = new Moto(10, "Yamaha MT-07", 8000, Marque.Peugeot, moteur3);
            Moto moto2 = new Moto(11, "Ducati Monster", 12000, Marque.Renault, moteur4);
            Camion camion1 = new Camion(10, 1000, 10, "Mercedes Actros", 80000, Marque.Audi, moteur5);

            voiture1.AjouterOptions(option1);
            voiture2.AjouterOptions(option2);
            moto1.AjouterOptions(option3);
            moto2.AjouterOptions(option4);
            camion1.AjouterOptions(option5);


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

            return monGarage;
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

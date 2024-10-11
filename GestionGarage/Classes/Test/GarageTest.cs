using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.Test
{
    internal class GarageTest
    {
        public void TesterGarage()
        {
            Console.WriteLine("Démarrage des tests de gestion du garage...");

            // Création de plusieurs véhicules
            List<Option> options = new List<Option>();
            Marque marque = new Marque(); 
            Voiture voiture1 = new Voiture("Renault Clio", 15000, options, marque, 5, 5, 300,);
            Voiture voiture2 = new Voiture("Peugeot 308", 18000, 8, 5, 5, 400);
            Moto moto1 = new Moto("Yamaha MT-07", 8000, 689);
            Moto moto2 = new Moto("Ducati Monster", 12000, 937);
            Camion camion1 = new Camion("Mercedes Actros", 80000, 4, 18, 40);

            // Création du garage
            Garage monGarage = new Garage("Mon Garage");

            // Ajout des véhicules au garage
            monGarage.AjouterVehicule(voiture1);
            monGarage.AjouterVehicule(voiture2);
            monGarage.AjouterVehicule(moto1);
            monGarage.AjouterVehicule(moto2);
            monGarage.AjouterVehicule(camion1);

            // Afficher tous les véhicules avant le tri
            Console.WriteLine("Véhicules avant le tri :");
            monGarage.Afficher();

            // Tester le tri des véhicules par prix total (HT + taxe)
            monGarage.TrierVehicule();

            // Afficher les véhicules après le tri
            Console.WriteLine("\nVéhicules après le tri par prix total :");
            monGarage.Afficher();

            Console.WriteLine("Fin des tests du garage.");
        }
    }

using GestionGarage.Classes.Exceptions;
using GestionGarage.Classes.GarageGestion.Enum_Garage;
using GestionGarage.Classes.GarageGestion.VehiculesGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GestionGarage.Classes.GarageGestion.Test
{
    internal class TestMenu
    {
        public bool AfficherMenuTests()
        {
            Console.WriteLine("Souhaitez-vous exécuter les tests avant de démarrer l'application ?");
            Console.WriteLine("1. Oui");
            Console.WriteLine("2. Non");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine();
            return choix == "1";
        }

        public void ExecuterTests()
        {
            Console.WriteLine("Exécution des tests...\n");

            try
            {
                ExecuterTest("AjouterVehicule_ShouldAddVehicleToGarage", AjouterVehicule_ShouldAddVehicleToGarage);
                ExecuterTest("SupprimerVehicule_ShouldRemoveVehicleFromGarage", SupprimerVehicule_ShouldRemoveVehicleFromGarage);
                ExecuterTest("SupprimerVehicule_ShouldThrowExceptionIfVehicleNotFound", SupprimerVehicule_ShouldThrowExceptionIfVehicleNotFound);
                ExecuterTest("TrierVehicule_ShouldSortVehiclesByTotalPrice", TrierVehicule_ShouldSortVehiclesByTotalPrice);
                ExecuterTest("TrierVehicule_ShouldThrowEmptyGarageException_WhenGarageIsEmpty", TrierVehicule_ShouldThrowEmptyGarageException_WhenGarageIsEmpty);
                ExecuterTest("AjouterOption_ShouldAddOptionToVehicle", AjouterOption_ShouldAddOptionToVehicle);
                ExecuterTest("GetVehiculeById_ShouldReturnCorrectVehicle", GetVehiculeById_ShouldReturnCorrectVehicle);
                ExecuterTest("GetVehiculeById_ShouldThrowExceptionIfVehicleNotFound", GetVehiculeById_ShouldThrowExceptionIfVehicleNotFound);
                ExecuterTest("ChargerGarage_ShouldThrowExceptionIfFileDoesNotExist", ChargerGarage_ShouldThrowExceptionIfFileDoesNotExist);
                ExecuterTest("AjouterMoteur_ShouldAddMoteurToGarage", AjouterMoteur_ShouldAddMoteurToGarage);
                ExecuterTest("AjouterOptionExistante_ShouldNotDuplicateOptionInVehicle", AjouterOptionExistante_ShouldThrowDuplicateOptionException);
                ExecuterTest("ChargerGarage_ShouldLoadGarageFromJsonFile", ChargerGarage_ShouldLoadGarageFromJsonFile);
                ExecuterTest("AfficherMarquesDisponibles_ShouldListAllCarBrands", AfficherMarquesDisponibles_ShouldListAllCarBrands);
                ExecuterTest("AfficherTypesMoteursDisponibles_ShouldListAllEngineTypes", AfficherTypesMoteursDisponibles_ShouldListAllEngineTypes);


                Console.WriteLine("\nTous les tests sont terminés avec succès.\n");
            }
            catch (TestFailureException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExecuterTest(string nomDuTest, Action testMethod)
        {
            try
            {
                testMethod();
                Console.WriteLine($"Test {nomDuTest} est passé avec succès.");
            }
            catch (Exception ex)
            {
                throw new TestFailureException(nomDuTest, ex.Message);
            }
        }


       
        public void AjouterVehicule_ShouldAddVehicleToGarage()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Diesel, 2000);
            var voiture = new Voiture("Renault Clio", 15000, Marque.Renault, moteur, 5, 300, 5, 5);

            // Act
            garage.AjouterVehicule(voiture);

            // Assert
            Assert.Contains(voiture, garage.Vehicules);
        }

       
        public void SupprimerVehicule_ShouldRemoveVehicleFromGarage()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Diesel, 2000);
            var voiture = new Voiture("Renault Clio", 15000, Marque.Renault, moteur, 5, 300, 5, 5);
            garage.AjouterVehicule(voiture);

            // Act
            garage.SupprimerVehicule(voiture.Id);

            // Assert
            Assert.DoesNotContain(voiture, garage.Vehicules);
        }

       
        public void SupprimerVehicule_ShouldThrowExceptionIfVehicleNotFound()
        {
            // Arrange
            var garage = new Garage("Test Garage");

            // Act & Assert
            Assert.Throws<VehiculeNotFoundException>(() => garage.SupprimerVehicule(999));
        }

       
        public void TrierVehicule_ShouldSortVehiclesByTotalPrice()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            var moteur1 = new Moteur(TypeMoteur.Diesel, 2000);
            var moteur2 = new Moteur(TypeMoteur.Hybride, 2000);
            var voiture1 = new Voiture("Renault Clio", 15000, Marque.Renault, moteur1, 5, 300, 5, 5);
            var voiture2 = new Voiture("Peugeot 308", 18000, Marque.Peugeot, moteur2, 8, 400, 5, 5);

            voiture1.AjouterOptions(new Option("Climatisation", 1200));
            voiture2.AjouterOptions(new Option("GPS", 800));

            garage.AjouterVehicule(voiture1);
            garage.AjouterVehicule(voiture2);

            // Act
            garage.TrierVehicule();

            // Assert
            Assert.Equal(voiture1, garage.Vehicules[0]);
            Assert.Equal(voiture2, garage.Vehicules[1]);
        }

       
        public void AjouterOption_ShouldAddOptionToVehicle()
        {
            // Arrange
            var moteur = new Moteur(TypeMoteur.Essence, 1200);
            var voiture = new Voiture("Toyota Yaris", 10000, Marque.Peugeot, moteur, 3, 100, 4, 5);
            var option = new Option("GPS", 800);

            // Act
            voiture.AjouterOptions(option);

            // Assert
            Assert.Contains(option, voiture.OptionsList);
        }

       
        public void GetVehiculeById_ShouldReturnCorrectVehicle()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Diesel, 2000);
            var voiture = new Voiture("Renault Clio", 15000, Marque.Renault, moteur, 5, 300, 5, 5);
            garage.AjouterVehicule(voiture);

            // Act
            var result = garage.GetVehiculeById(voiture.Id);

            // Assert
            Assert.Equal(voiture, result);
        }

       
        public void GetVehiculeById_ShouldThrowExceptionIfVehicleNotFound()
        {
            // Arrange
            var garage = new Garage("Test Garage");

            // Act & Assert
            Assert.Throws<VehiculeNotFoundException>(() => garage.GetVehiculeById(999));
        }

       
        public void ChargerGarage_ShouldThrowExceptionIfFileDoesNotExist()
        {
            // Arrange
            var garage = new Garage("Test Garage");

            // Act & Assert
            Assert.Throws<GarageFileException>(() => garage.ChargerGarage("FichierInexistant"));
        }

       
        public void TrierVehicule_ShouldThrowEmptyGarageException_WhenGarageIsEmpty()
        {
            // Arrange
            var garage = new Garage("Empty Garage");

            // Act & Assert
            Assert.Throws<EmptyGarageException>(() => garage.TrierVehicule());
        }

       
        public void AjouterMoteur_ShouldAddMoteurToGarage()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Hybride, 1500);

            // Act
            garage.AjouterMoteur(moteur);

            // Assert
            Assert.Contains(moteur, garage.Moteurs);
            Console.WriteLine("Test AjouterMoteur_ShouldAddMoteurToGarage est passé avec succès.");
        }

       
        public void AjouterOptionExistante_ShouldThrowDuplicateOptionException()
        {
            // Arrange
            var moteur = new Moteur(TypeMoteur.Essence, 1200);
            var voiture = new Voiture("Toyota Yaris", 10000, Marque.Peugeot, moteur, 3, 100, 4, 5);
            var option = new Option("GPS", 800);

            // Act
            voiture.AjouterOptions(option);

            // Assert
            var exception = Assert.Throws<DuplicateOptionException>(() => voiture.AjouterOptions(option));
            Assert.Contains("GPS", exception.Message); // Vérifie que "GPS" est dans le message de l'exception
            Console.WriteLine("Test AjouterOptionExistante_ShouldThrowDuplicateOptionException est passé avec succès.");
        }



       
        public void ChargerGarage_ShouldLoadGarageFromJsonFile()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            garage.AjouterVehicule(new Voiture("Renault Clio", 15000, Marque.Renault, new Moteur(TypeMoteur.Diesel, 2000), 5, 300, 5, 5));
            garage.SauvegarderGarage(); // Sauvegarde pour créer un fichier JSON

            // Act
            var garageCharge = new Garage("Test Garage Chargé");
            garageCharge.ChargerGarage("Test Garage");

            // Assert
            Assert.Equal(garage.Vehicules.Count, garageCharge.Vehicules.Count);
            Console.WriteLine("Test ChargerGarage_ShouldLoadGarageFromJsonFile est passé avec succès.");
        }

       
        public void AfficherMarquesDisponibles_ShouldListAllCarBrands()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            var originalOutput = Console.Out;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                garage.AfficherMarquesDisponibles();
                var output = sw.ToString().Trim();

                // Assert
                Assert.Contains("Peugeot", output);
                Assert.Contains("Renault", output);
                Assert.Contains("Citroen", output);
                Assert.Contains("Audi", output);
                Assert.Contains("Ferrari", output);
                Console.WriteLine("Test AfficherMarquesDisponibles_ShouldListAllCarBrands est passé avec succès.");
            }
            Console.SetOut(originalOutput); // Restaure la sortie console
        }

       
        public void AfficherTypesMoteursDisponibles_ShouldListAllEngineTypes()
        {
            // Arrange
            var garage = new Garage("Test Garage");
            var originalOutput = Console.Out;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                garage.AfficherTypesMoteursDisponibles();
                var output = sw.ToString().Trim();

                // Assert
                Assert.Contains("Diesel", output);
                Assert.Contains("Essence", output);
                Assert.Contains("Hybride", output);
                Assert.Contains("Electrique", output);
                Console.WriteLine("Test AfficherTypesMoteursDisponibles_ShouldListAllEngineTypes est passé avec succès.");
            }
            Console.SetOut(originalOutput); // Restaure la sortie console
        }
    }
}

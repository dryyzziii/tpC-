using GestionGarage.Classes.Exceptions;
using GestionGarage.Classes.GarageGestion.Enum_Garage;
using GestionGarage.Classes.GarageGestion.VehiculesGestion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace GestionGarage.Classes.GarageGestion.Test
{
    public class GarageTests
    {
        [Fact]
        public void AjouterVehicule_ShouldAddVehicleToGarage()
        {
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Diesel, 2000);
            var voiture = new Voiture("Renault Clio", 15000, Marque.Renault, moteur, 5, 300, 5, 5);

            garage.AjouterVehicule(voiture);

            Assert.Contains(voiture, garage.Vehicules);
        }

        [Fact]
        public void SupprimerVehicule_ShouldRemoveVehicleFromGarage()
        {
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Diesel, 2000);
            var voiture = new Voiture("Renault Clio", 15000, Marque.Renault, moteur, 5, 300, 5, 5);
            garage.AjouterVehicule(voiture);

            garage.SupprimerVehicule(voiture.Id);

            Assert.DoesNotContain(voiture, garage.Vehicules);
        }

        [Fact]
        public void SupprimerVehicule_ShouldThrowExceptionIfVehicleNotFound()
        {
            var garage = new Garage("Test Garage");

            Assert.Throws<VehiculeNotFoundException>(() => garage.SupprimerVehicule(999));
        }

        [Fact]
        public void TrierVehicule_ShouldSortVehiclesByTotalPrice()
        {
            var garage = new Garage("Test Garage");
            var moteur1 = new Moteur(TypeMoteur.Diesel, 2000);
            var moteur2 = new Moteur(TypeMoteur.Hybride, 2000);
            var voiture1 = new Voiture("Renault Clio", 15000, Marque.Renault, moteur1, 5, 300, 5, 5);
            var voiture2 = new Voiture("Peugeot 308", 18000, Marque.Peugeot, moteur2, 8, 400, 5, 5);

            voiture1.AjouterOptions(new Option("Climatisation", 1200));
            voiture2.AjouterOptions(new Option("GPS", 800));

            garage.AjouterVehicule(voiture1);
            garage.AjouterVehicule(voiture2);

            garage.TrierVehicule();

            Assert.Equal(voiture1, garage.Vehicules[0]);
            Assert.Equal(voiture2, garage.Vehicules[1]);
        }

        [Fact]
        public void AjouterOption_ShouldAddOptionToVehicle()
        {
            var moteur = new Moteur(TypeMoteur.Essence, 1200);
            var voiture = new Voiture("Toyota Yaris", 10000, Marque.Peugeot, moteur, 3, 100, 4, 5);
            var option = new Option("GPS", 800);

            voiture.AjouterOptions(option);

            Assert.Contains(option, voiture.OptionsList);
        }

        [Fact]
        public void GetVehiculeById_ShouldReturnCorrectVehicle()
        {
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Diesel, 2000);
            var voiture = new Voiture("Renault Clio", 15000, Marque.Renault, moteur, 5, 300, 5, 5);
            garage.AjouterVehicule(voiture);

            var result = garage.GetVehiculeById(voiture.Id);

            Assert.Equal(voiture, result);
        }

        [Fact]
        public void GetVehiculeById_ShouldThrowExceptionIfVehicleNotFound()
        {
            var garage = new Garage("Test Garage");

            Assert.Throws<VehiculeNotFoundException>(() => garage.GetVehiculeById(999));
        }

        [Fact]
        public void ChargerGarage_ShouldThrowExceptionIfFileDoesNotExist()
        {
            var garage = new Garage("Test Garage");

            Assert.Throws<GarageFileException>(() => garage.ChargerGarage("FichierInexistant"));
        }

        [Fact]
        public void TrierVehicule_ShouldThrowEmptyGarageException_WhenGarageIsEmpty()
        {
            var garage = new Garage("Empty Garage");

            Assert.Throws<EmptyGarageException>(() => garage.TrierVehicule());
        }

        [Fact]
        public void AjouterMoteur_ShouldAddMoteurToGarage()
        {
            var garage = new Garage("Test Garage");
            var moteur = new Moteur(TypeMoteur.Hybride, 1500);

            garage.AjouterMoteur(moteur);

            Assert.Contains(moteur, garage.Moteurs);
        }

        [Fact]
        public void AjouterOptionExistante_ShouldThrowDuplicateOptionException()
        {
            var moteur = new Moteur(TypeMoteur.Essence, 1200);
            var voiture = new Voiture("Toyota Yaris", 10000, Marque.Peugeot, moteur, 3, 100, 4, 5);
            var option = new Option("GPS", 800);

            voiture.AjouterOptions(option);

            var exception = Assert.Throws<DuplicateOptionException>(() => voiture.AjouterOptions(option));
            Assert.Contains("GPS", exception.Message);
        }
    }
}

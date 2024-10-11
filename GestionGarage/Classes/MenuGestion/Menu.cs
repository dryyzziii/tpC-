﻿using GestionGarage.Classes.Exceptions;
using GestionGarage.Classes.GarageGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes.MenuGestion
{
    internal class Menu
    {
        private Garage garage;

        public Menu(Garage garage)
        {
            this.garage = garage;
        }

        public void Start()
        {
            bool continuer = true;

            while (continuer)
            {
                try
                {
                    Console.WriteLine("\n===== Menu Gestion du Garage =====");
                    Console.WriteLine("1. Afficher les véhicules");
                    Console.WriteLine("2. Ajouter un véhicule");
                    Console.WriteLine("3. Supprimer un véhicule");
                    Console.WriteLine("4. Sélectionner un véhicule");
                    Console.WriteLine("5. Afficher les options d'un véhicule");
                    Console.WriteLine("6. Ajouter des options à un véhicule");
                    Console.WriteLine("7. Supprimer des options à un véhicule");
                    Console.WriteLine("8. Afficher les options");
                    Console.WriteLine("9. Afficher les marques");
                    Console.WriteLine("10. Afficher les types de moteurs");
                    Console.WriteLine("11. Charger le garage");
                    Console.WriteLine("12. Sauvegarder le garage");
                    Console.WriteLine("13. Quitter l'application");

                    int choix = GetChoixMenu();
                    switch (choix)
                    {
                        case 1:
                            AfficherVehicules();
                            break;
                        case 2:
                            AjouterVehicule();
                            break;
                        case 3:
                            SupprimerVehicule();
                            break;
                        case 4:
                            SelectionnerVehicule();
                            break;
                        case 5:
                            AfficherOptionsVehicule();
                            break;
                        case 6:
                            AjouterOptionsVehicule();
                            break;
                        case 7:
                            SupprimerOptionsVehicule();
                            break;
                        case 8:
                            AfficherOptions();
                            break;
                        case 9:
                            AfficherMarques();
                            break;
                        case 10:
                            AfficherTypesMoteurs();
                            break;
                        case 11:
                            ChargerGarage();
                            break;
                        case 12:
                            SauvegarderGarage();
                            break;
                        case 13:
                            continuer = false;
                            Console.WriteLine("Fermeture de l'application...");
                            break;
                        default:
                            throw new MenuException("Le choix n'est pas compris entre 1 et 13.");
                    }
                }
                catch (MenuException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Le choix saisie n'est pas un nombre.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Une erreur est survenue : {ex.Message}");
                }
            }
        }

        public int GetChoixMenu()
        {
            int choix = GetChoix();
            if (choix < 1 || choix > 13)
            {
                throw new MenuException("Le choix n'est pas compris entre 1 et 13.");
            }
            return choix;
        }

        public int GetChoix()
        {
            Console.Write("Veuillez saisir votre choix : ");
            string saisie = Console.ReadLine();
            try
            {
                return int.Parse(saisie);
            }
            catch (FormatException)
            {
                throw new FormatException("Le choix saisie n'est pas un nombre.");
            }
        }

        // Méthodes pour chaque commande du menu
        public void AfficherVehicules()
        {
            garage.Afficher();
        }

        public void AjouterVehicule()
        {
            // Implémenter la logique pour ajouter un véhicule (entrer les données via la console)
        }

        public void SupprimerVehicule()
        {
            // Implémenter la logique pour supprimer un véhicule par ID
        }

        public void SelectionnerVehicule()
        {
            // Implémenter la logique pour sélectionner un véhicule
        }

        public void AfficherOptionsVehicule()
        {
            // Implémenter la logique pour afficher les options d'un véhicule
        }

        public void AjouterOptionsVehicule()
        {
            // Implémenter la logique pour ajouter des options à un véhicule
        }

        public void SupprimerOptionsVehicule()
        {
            // Implémenter la logique pour supprimer des options d'un véhicule
        }

        public void AfficherOptions()
        {
            garage.AfficherToutesOptions();
        }

        public void AfficherMarques()
        {
            garage.AfficherMarquesDisponibles();
        }

        public void AfficherTypesMoteurs()
        {
            garage.AfficherTypesMoteursDisponibles();
        }

        public void ChargerGarage()
        {
            // Implémenter la logique pour charger les informations du garage depuis un fichier
        }

        public void SauvegarderGarage()
        {
            // Implémenter la logique pour sauvegarder les informations du garage dans un fichier
        }
    }
}
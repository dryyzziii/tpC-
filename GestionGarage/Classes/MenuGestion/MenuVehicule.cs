using GestionGarage.Classes.GarageGestion.Enum_Garage;
using GestionGarage.Classes.GarageGestion.VehiculesGestion;
using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.Exceptions;

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
            // Titre de la section ajout de véhicule
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Ajouter un nouveau véhicule =====");
            Console.ResetColor();

            // Saisie du nom du véhicule
            Console.Write("Entrez le nom du véhicule : ");
            string nom = Console.ReadLine();

            // Saisie du prix du véhicule avec validation
            Console.Write("Entrez le prix HT du véhicule : ");
            int prixHT;

            while (!int.TryParse(Console.ReadLine(), out prixHT))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le prix doit être un nombre valide.");
                Console.ResetColor();
                Console.Write("Entrez le prix HT du véhicule : ");
            }
            if (prixHT < 0)
            {
                throw new NegativeValueException("prix HT");
            }


            // Sélection de la marque
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Sélectionnez la marque =====");
            Console.ResetColor();
            Array marques = Enum.GetValues(typeof(Marque));
            for (int i = 0; i < marques.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {marques.GetValue(i)}");
            }
            Console.Write("Entrez le numéro de la marque : ");
            int choixMarque;
            while (!int.TryParse(Console.ReadLine(), out choixMarque) || choixMarque < 1 || choixMarque > marques.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choix non valide. Sélectionnez une marque valide.");
                Console.ResetColor();
                Console.Write("Entrez le numéro de la marque : ");
            }
            Marque marque = (Marque)marques.GetValue(choixMarque - 1);

            // Sélection ou création d'un moteur
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Sélectionnez un moteur ou créez-en un nouveau =====");
            Console.ResetColor();

            if (garage.MoteursExistants())
            {
                // Afficher tous les moteurs existants
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Moteurs existants :");
                Console.ResetColor();
                garage.AfficherMoteursExistant();

                Console.Write("Voulez-vous utiliser un moteur existant ? (O/N) : ");
                string reponse = Console.ReadLine().ToUpper();

                if (reponse == "O")
                {
                    // Sélection d'un moteur existant
                    Console.Write("Entrez l'ID du moteur : ");
                    int moteurId;
                    while (!int.TryParse(Console.ReadLine(), out moteurId) || !garage.MoteurExiste(moteurId))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ID du moteur non valide.");
                        Console.ResetColor();
                        Console.Write("Entrez l'ID du moteur : ");
                    }
                    Moteur moteur = garage.GetMoteurById(moteurId);

                    // Création et ajout du véhicule
                    Vehicule vehicule = new Voiture(nom, prixHT, marque, moteur, 5, 300, 5, 5);
                    garage.AjouterVehicule(vehicule);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nLe véhicule {nom} a été ajouté avec succès !");
                    Console.ResetColor();
                    vehicule.Afficher();
                    return;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucun moteur déjà ajouté\n");
                Console.ResetColor();
            }

            // Création d'un nouveau moteur
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Créer un nouveau moteur =====");
            Console.ResetColor();
            Array typemoteur = Enum.GetValues(typeof(TypeMoteur));
            garage.AfficherTypesMoteursDisponibles();
            Console.Write("Entrez le numéro du type de moteur : ");
            int moteurTypeId;
            while (!int.TryParse(Console.ReadLine(), out moteurTypeId) || moteurTypeId < 1 || moteurTypeId > typemoteur.Length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Type de moteur non valide. Sélectionnez un type valide.");
                Console.ResetColor();
                Console.Write("Entrez le numéro du type de moteur : ");
            }
            TypeMoteur typeMoteur = (TypeMoteur)typemoteur.GetValue(moteurTypeId - 1);

            Console.Write("Entrez la puissance du moteur : ");
            decimal puissanceMoteur;
            while (!decimal.TryParse(Console.ReadLine(), out puissanceMoteur))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La puissance doit être un nombre valide.");
                Console.ResetColor();
                Console.Write("Entrez la puissance du moteur : ");
            }

            // Ajouter le nouveau moteur au garage
            Moteur nouveauMoteur = new Moteur(typeMoteur, puissanceMoteur);
            garage.AjouterMoteur(nouveauMoteur);

            // Création et ajout du véhicule avec le nouveau moteur
            Vehicule vehiculeNouveauMoteur = new Voiture(nom, prixHT, marque, nouveauMoteur, 5, 300, 5, 5);
            garage.AjouterVehicule(vehiculeNouveauMoteur);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nLe véhicule {nom} avec un nouveau moteur a été ajouté avec succès !");
            Console.ResetColor();
            vehiculeNouveauMoteur.Afficher();
        }

        public void SupprimerVehicule()
        {
            // Titre de la section suppression de véhicule
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Supprimer un véhicule =====");
            Console.ResetColor();

            // Afficher les véhicules existants
            garage.Afficher();

            // Demander l'ID du véhicule à supprimer avec validation
            Console.Write("Entrez l'ID du véhicule à supprimer : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID du véhicule non valide.");
                Console.ResetColor();
                Console.Write("Entrez l'ID du véhicule à supprimer : ");
            }

            // Suppression du véhicule
            garage.SupprimerVehicule(vehiculeId);

            // Confirmation de la suppression avec couleur de succès
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nLe véhicule avec l'ID {vehiculeId} a été supprimé avec succès.");
            Console.ResetColor();
        }

        // TODO demander a quoi ca sert
        public void SelectionnerVehicule()
        {
            // Titre de la section sélection de véhicule
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Sélectionner un véhicule =====");
            Console.ResetColor();

            // Afficher la liste des véhicules existants
            garage.Afficher();

            // Demander l'ID du véhicule à sélectionner avec validation
            Console.Write("Entrez l'ID du véhicule à sélectionner : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID du véhicule non valide.");
                Console.ResetColor();
                Console.Write("Entrez l'ID du véhicule à sélectionner : ");
            }

            // Récupérer et afficher les détails du véhicule sélectionné
            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nVéhicule sélectionné :\n");
            Console.ResetColor();

            vehicule.Afficher();
        }

        public void AfficherOptionsVehicule()
        {
            // Titre de la section d'affichage des options d'un véhicule
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Afficher les options d'un véhicule =====");
            Console.ResetColor();

            // Afficher la liste des véhicules existants
            garage.Afficher();

            // Demander l'ID du véhicule avec validation
            Console.Write("Entrez l'ID du véhicule : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID du véhicule non valide.");
                Console.ResetColor();
                Console.Write("Entrez l'ID du véhicule : ");
            }

            // Récupérer et afficher les options du véhicule
            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nOptions pour le véhicule : {vehicule.Nom}\n");
            Console.ResetColor();

            // Si le véhicule a des options, les afficher, sinon indiquer qu'il n'y en a pas
            if (vehicule.OptionsList.Count > 0)
            {
                vehicule.AfficherOptions();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ce véhicule ne possède aucune option.");
                Console.ResetColor();
            }
        }

        public void AjouterOptionsVehicule()
        {
            // Titre de la section pour ajouter des options
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Ajouter des options à un véhicule =====");
            Console.ResetColor();

            // Afficher tous les véhicules pour sélectionner celui à modifier
            garage.Afficher();

            // Saisie de l'ID du véhicule avec validation
            Console.Write("Entrez l'ID du véhicule : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID du véhicule non valide.");
                Console.ResetColor();
                Console.Write("Entrez l'ID du véhicule : ");
            }

            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);

            // Vérification si des options existent dans le garage
            if (garage.OptionsExistantes())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n===== Sélectionnez une option existante ou créez-en une nouvelle =====");
                Console.ResetColor();

                garage.AfficherToutesOptions();

                Console.Write("Voulez-vous utiliser une option existante ? (O/N) : ");
                string reponse = Console.ReadLine().ToUpper();

                if (reponse == "O")
                {
                    // Sélection d'une option existante avec validation de l'ID
                    Console.Write("Entrez l'ID de l'option à ajouter : ");
                    int optionId;
                    while (!int.TryParse(Console.ReadLine(), out optionId) || !garage.OptionExiste(optionId))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ID de l'option non valide.");
                        Console.ResetColor();
                        Console.Write("Entrez l'ID de l'option à ajouter : ");
                    }

                    Option option = garage.GetOptionById(optionId);
                    vehicule.AjouterOptions(option);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nL'option '{option.Nom}' a été ajoutée avec succès au véhicule '{vehicule.Nom}'.");
                    Console.ResetColor();
                    return;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nAucune option existante dans le garage. Créez une nouvelle option.");
                Console.ResetColor();
            }

            // Création d'une nouvelle option
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Créer une nouvelle option =====");
            Console.ResetColor();

            // Saisie du nom de la nouvelle option
            Console.Write("Entrez le nom de l'option : ");
            string nomOption = Console.ReadLine();

            // Saisie et validation du prix de l'option
            Console.Write("Entrez le prix de l'option (en €) : ");
            decimal prixOption;
            while (!decimal.TryParse(Console.ReadLine(), out prixOption))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le prix doit être un nombre valide.");
                Console.ResetColor();
                Console.Write("Entrez le prix de l'option : ");
            }

            // Ajout de la nouvelle option au garage
            Option nouvelleOption = new Option(nomOption, prixOption);
            garage.AjouterOption(nouvelleOption);

            // Ajout de la nouvelle option au véhicule
            vehicule.AjouterOptions(nouvelleOption);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nL'option '{nouvelleOption.Nom}' a été ajoutée avec succès au véhicule '{vehicule.Nom}'.");
            Console.ResetColor();
        }

        public void SupprimerOptionsVehicule()
        {
            // Titre de la section pour supprimer des options
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Supprimer des options d'un véhicule =====");
            Console.ResetColor();

            // Afficher tous les véhicules pour sélectionner celui à modifier
            garage.Afficher();

            // Saisie de l'ID du véhicule avec validation
            Console.Write("Entrez l'ID du véhicule : ");
            int vehiculeId;
            while (!int.TryParse(Console.ReadLine(), out vehiculeId) || !garage.VehiculeExiste(vehiculeId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID du véhicule non valide.");
                Console.ResetColor();
                Console.Write("Entrez l'ID du véhicule : ");
            }

            // Obtenir le véhicule sélectionné
            Vehicule vehicule = garage.GetVehiculeById(vehiculeId);

            // Afficher les options du véhicule
            if (vehicule.OptionsList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nOptions disponibles pour le véhicule '{vehicule.Nom}':");
                Console.ResetColor();
                vehicule.AfficherOptions();

                // Saisie de l'ID de l'option à supprimer avec validation
                Console.Write("Entrez l'ID de l'option à supprimer : ");
                int optionId;
                while (!int.TryParse(Console.ReadLine(), out optionId) || !vehicule.OptionExiste(optionId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ID de l'option non valide.");
                    Console.ResetColor();
                    Console.Write("Entrez l'ID de l'option à supprimer : ");
                }

                // Supprimer l'option du véhicule
                Option option = vehicule.GetOptionById(optionId);
                vehicule.SupprimerOption(optionId);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nL'option '{option.Nom}' a été supprimée du véhicule '{vehicule.Nom}'.");
                Console.ResetColor();
            }
            else
            {
                // Si le véhicule n'a pas d'options
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nLe véhicule '{vehicule.Nom}' ne possède aucune option.");
                Console.ResetColor();
            }
        }

    }
}

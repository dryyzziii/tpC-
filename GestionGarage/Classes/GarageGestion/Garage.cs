using GestionGarage.Classes.ConverterJson;
using GestionGarage.Classes.Exceptions;
using GestionGarage.Classes.GarageGestion.Enum_Garage;
using GestionGarage.Classes.GarageGestion.VehiculesGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionGarage.Classes.GarageGestion
{
    internal class Garage
    {
        #region private attributes
        private string nom;
        private List<Vehicule> vehicules;
        private List<Option> options;
        private List<Moteur> moteurs;
        #endregion

        #region public attributes
        public string Nom { get => nom; set => nom = value; }
        public List<Vehicule> Vehicules { get => vehicules; set => vehicules = value; }
        public List<Option> Options { get => options; set => options = value; }
        public List<Moteur> Moteurs { get => moteurs; set => moteurs = value; }
        #endregion

        #region constructor 
        public Garage() { }


        
        public Garage(string nom)
        {
            this.nom = nom;
            this.vehicules = new List<Vehicule>();
            this.options = new List<Option>();
            this.moteurs = new List<Moteur>();
        }

        [JsonConstructor]
        public Garage(string Nom, List<Vehicule> Vehicules, List<Option> Options, List<Moteur> Moteurs)
        {
            this.nom = Nom;
            this.vehicules = Vehicules;
            this.options = Options;
            this.moteurs = Moteurs;
        }
        #endregion

        #region public methodes

        #region gestion json
        public void SauvegarderGarage()
        {
            try
            {
                // Chemin du fichier dans JSON/
                string cheminProjet = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "./JSON", $"{nom}.json");
                string cheminAbsolu = Path.GetFullPath(cheminProjet);

                // Sérialiser le garage
                var optionsJson = new JsonSerializerOptions { WriteIndented = true };
                optionsJson.Converters.Add(new VehiculeConverter());
                string json = JsonSerializer.Serialize(this, optionsJson);

                // Écrire le JSON dans le fichier
                File.WriteAllText(cheminAbsolu, json);
                Console.WriteLine($"Le garage a été sauvegardé dans le fichier : {cheminAbsolu}");
            }
            catch (Exception ex)
            {
                throw new GarageFileException($"Erreur lors de la sauvegarde du fichier : {ex.Message}");
            }
        }


        public void ChargerGarage(string cheminFichier)
        {
            try
            {
                // Construire le chemin vers le dossier ./JSON et ajouter l'extension .json
                string cheminProjet = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "JSON", $"{cheminFichier}.json");
                string cheminAbsolu = Path.GetFullPath(cheminProjet);

                if (File.Exists(cheminAbsolu))
                {
                    var optionsJson = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    optionsJson.Converters.Add(new VehiculeConverter());  // Ajout du convertisseur personnalisé

                    // Lire et désérialiser le fichier JSON
                    string json = File.ReadAllText(cheminAbsolu);
                    Garage garage = JsonSerializer.Deserialize<Garage>(json, optionsJson);

                    this.vehicules = garage.vehicules;
                }
                else
                {
                    throw new GarageFileException($"Le fichier '{cheminFichier}.json' spécifié n'existe pas dans le dossier JSON.");
                }
            }
            catch (Exception ex)
            {
                throw new GarageFileException($"Erreur lors du chargement du fichier : {ex.Message}");
            }

        }
        #endregion

        #region gestion vehicules
        public void SupprimerVehicule(int id)
        {
            Vehicule vehicule = vehicules.Find(v => v.Id == id);
            if (vehicule != null)
            {
                vehicules.Remove(vehicule);
            }
            else
            {
                throw new VehiculeNotFoundException(id);
            }
        }

        public bool VehiculeExiste(int id)
        {
            return vehicules.Find(a => a.Id == id) != null;
        }
        public void AjouterVehicule(Vehicule vehicule)
        {
            vehicules.Add(vehicule);
        }
        
        public Vehicule GetVehiculeById(int id)
        {
            Vehicule vehicule = vehicules.Find(v => v.Id == id);
            if (vehicule == null)
            {
                throw new VehiculeNotFoundException(id);
            }
            return vehicule;
        }
        #endregion

        #region gestion moteurs
        public void AjouterMoteur(Moteur mot)
        {
            moteurs.Add(mot);
        }
        public Moteur GetMoteurById(int id)
        {
            Moteur mot = moteurs.Find(v => v.Id == id);
            if (mot != null)
            {
                return mot;
            }
            else
            {
                throw new MoteurNotFoundException(id);
            }
        }

        public bool MoteurExiste(int id)
        {
            return moteurs.Find(v => v.Id == id) != null;
        }
        public bool MoteursExistants()
        {
            return moteurs.Count > 0;
        }

        #endregion

        #region gestion options
        public bool OptionsExistantes()
        {
            return options.Count > 0;
        }
        public void AjouterOption(Option option)
        {
            options.Add(option);
        }
        public void SupprimerOption(int id)
        {
            Option op = options.Find(v => v.Id == id);
            if (op != null)
            {
                options.Remove(op);
            }
            else
            {
                throw new OptionNotFoundException(id);
            }
        }
        public bool OptionExiste(int id)
        {
            return options.Find(v => v.Id == id) != null;
        }
        public Option GetOptionById(int id)
        {
            Option op = options.Find(v => v.Id == id);
            if (op != null)
            {
                return op;
            }
            else
            {
                throw new OptionNotFoundException(id);
            }
        }

        #endregion

        #region affichage
        public void Afficher()
        {
            Console.WriteLine($"Garage {nom} \n Liste des véhicules : \n");
            if (vehicules.Count == 0)
               throw new EmptyGarageException("Véhicules");
            else
                vehicules.ForEach(v => v.Afficher());
        }

        public void AfficherVoiture()
        {
            vehicules.ForEach(v =>
            {
                if (v is Voiture)
                {
                    v.Afficher();
                }
            });
        }

        public void AfficherCamion()
        {
            vehicules.ForEach(v =>
            {
                if (v is Camion)
                {
                    v.Afficher();
                }
            });
        }

        public void AfficherMoto()
        {
            vehicules.ForEach(v =>
            {
                if (v is Moto)
                {
                    v.Afficher();
                }
            });
        }

        public void AfficherToutesOptions()
        {
            if (options.Count == 0)
                throw new EmptyGarageException("Options");
            else
                options.ForEach(o => o.Afficher());
        }

        public void AfficherMarquesDisponibles()
        {
            foreach (Marque marque in Enum.GetValues(typeof(Marque)))
            {
                Console.WriteLine(marque);
            }
        }

        public void AfficherTypesMoteursDisponibles()
        {
            foreach (TypeMoteur moteur in Enum.GetValues(typeof(TypeMoteur)))
            {
                Console.WriteLine(moteur);
            }
        }

        public void AfficherMoteursExistant()
        {
            if(moteurs.Count == 0)
                throw new EmptyGarageException("Moteur");
            else
                moteurs.ForEach(o => o.Afficher());
        }

        #endregion

        public void TrierVehicule()
        {
            if(vehicules.Count == 0)
                throw new EmptyGarageException("Véhicules");
            else
                vehicules.Sort((v1, v2) => v1.PrixTotal().CompareTo(v2.PrixTotal()));
        }

        #endregion
    }
}

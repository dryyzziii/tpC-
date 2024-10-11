using GestionGarage.Classes.GarageGestion.VehiculesGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            vehicules = new List<Vehicule>();
        }
        #endregion

        #region public methodes

        public void AjouterVehicule(Vehicule vehicule)
        {
            vehicules.Add(vehicule);
        }
        public void AjouterOption(Option option)
        {
            options.Add(option);
        }

        public void SupprimerVehicule(int id)
        {
            Vehicule vehicule = vehicules.Find(v => v.Id == id);
            if (vehicule != null)
            {
                vehicules.Remove(vehicule);
            }
            else
            {
                throw new Exception("Véhicule non trouvé.");
            }
        }

        public void Afficher()
        {
            Console.WriteLine($"Garage {nom} \n Liste des véhicules : \n");
            if (vehicules.Count == 0)
                Console.WriteLine("Aucun véhicule dans le garage.");
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
                Console.WriteLine("Aucune option disponible.");
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

        public void TrierVehicule()
        {
            Vehicules.Sort((v1, v2) => v1.PrixTotal().CompareTo(v2.PrixTotal()));
        }

        #endregion
    }
}

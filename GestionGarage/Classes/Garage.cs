using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes
{
    internal class Garage
    {
        #region private attributes
        private string nom;
        private List<Vehicule> vehicules;
        #endregion

        #region public attributes
        public string Nom {  get => nom; set => nom = value; }
        public List<Vehicule> Vehicules { get => vehicules; set => vehicules = value; }
        #endregion

        #region constructor 
        public Garage() { }

        public Garage(string nom, List<Vehicule> vehicules)
        {
            this.nom = nom;
            this.vehicules = vehicules;
        }
        #endregion

        #region public methodes

        public void AjouterVehicule(Vehicule vehicule)
        {
           this.vehicules.Add(vehicule);
        }

        public void Afficher()
        {
            Console.WriteLine($"Garage {nom} \n Liste des véhicules : \n");
            this.vehicules.ForEach(v => v.Afficher());
        }

        public void AfficherVoiture()
        {
            this.vehicules.ForEach(v => {
                if(v is Voiture) {
                    v.Afficher();
                }
            });
        }

        public void AfficherCamion()
        {
            this.vehicules.ForEach(v => {
                if (v is Camion)
                {
                    v.Afficher();
                }
            });
        }

        public void AfficherMoto()
        {
            this.vehicules.ForEach(v => {
                if (v is Moto)
                {
                    v.Afficher();
                }
            });
        }

        public void TrierVehicule()
        {
            Vehicules.Sort((v1, v2) => v1.PrixTotal().CompareTo(v2.PrixTotal()));
        }

        #endregion
    }
}

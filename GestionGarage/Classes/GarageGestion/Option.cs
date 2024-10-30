using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionGarage.Classes.GarageGestion
{
    internal class Option
    {
        #region private attributes
        private static int increment = 0;

        private int id;
        private string nom;
        private decimal prix;
        #endregion

        #region public attributes
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Prix { get => prix; set => prix = value; }
        #endregion

        #region constructor
        public Option() { }

        public Option(string nom, decimal prix)
        {
            id = ++increment;
            this.nom = nom;
            this.prix = prix;
        }

        [JsonConstructor]
        public Option(int Id, string Nom, decimal Prix)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Prix = Prix;
        }
        #endregion


        public void Afficher()
        {
            Console.WriteLine($"Options {id} \nName : {nom}\nPrix: {prix}\n");
        }
    }
}

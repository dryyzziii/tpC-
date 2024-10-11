using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Classes
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
        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Prix { get => prix; set => prix = value; }
        #endregion

        #region constructor
        public Option() { }


        public Option(string nom, decimal prix) 
        {
            this.id = ++increment;
            this.nom = nom;
            this.prix = prix;
        }
        #endregion


        public void Afficher()
        {
            Console.WriteLine($"Options {id} \nName : {this.nom}\nPrix: {this.prix}\n");
        }
    }
}

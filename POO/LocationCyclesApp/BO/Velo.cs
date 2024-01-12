using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCycles.BO
{
    /// <summary>
    /// La classe Velo hérite de la classe Cycle
    /// </summary>
    public class Velo : Cycle
    {
        
        private const double PRIX_LOCATION = 4.9;

        public int NbVitesses { get; set; }

        /// <summary>
        /// Chaque classe fille est dans l'obligation de substituer les membres abstraits
        /// définis par la classe parent.
        /// </summary>
        public override double TarifLocationHeure
        {
            get
            {
                return PRIX_LOCATION;
            }
        }

        public Velo(DateTime dateAchat, String marque, String modele, int nbVitesses)
            :base(dateAchat, marque, modele)
        {
            this.NbVitesses = nbVitesses;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Nombre de vitesse : {this.NbVitesses}";
        }


    }
}

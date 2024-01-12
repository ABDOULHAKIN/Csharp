using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCycles.BO
{
    /// <summary>
    /// La classe Gyropode hérite de la classe CycleGyroscopique
    /// par héritage, elle est rechargeable
    /// </summary>
    public class Gyropode : CycleGyroscopique
    {
        private const double PRIX_LOCATION = 29.9;

        public int TailleMinCm { get; set; }

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

        public Gyropode(DateTime dateAchat, String marque, String modele, int autonomieKm, int tailleMinCm)
            :base(dateAchat, marque, modele, autonomieKm)
        {
            this.TailleMinCm = tailleMinCm;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Taille minimale : {this.TailleMinCm} cm";
        }
    }
}

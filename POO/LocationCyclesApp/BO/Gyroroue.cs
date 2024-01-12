using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCycles.BO
{
    /// <summary>
    /// La classe Gyroroue hérite de la classe CycleGyroscopique
    /// par héritage, elle est rechargeable
    /// </summary>
    public class Gyroroue : CycleGyroscopique
    {
        private const double PRIX_LOCATION = 18.9;

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

        public Gyroroue(DateTime dateAchat, String marque, String modele, int autonomieKm)
            : base(dateAchat, marque, modele, autonomieKm)
        {
        }
    }
}

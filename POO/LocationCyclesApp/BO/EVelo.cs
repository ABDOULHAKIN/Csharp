using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCycles.BO
{
    /// <summary>
    /// La classe EVelo hérite de la classe Velo
    /// Et implémente l'interface IRechargeable
    /// Chaque instance de EVelo devient donc rechargeable.
    /// </summary>
    public class EVelo : Velo, IRechargeable
    {

        private const double PRIX_LOCATION = 14.9;
        public int AutonomieKm { get; set; }

        public EVelo(DateTime dateAchat, String marque, String modele, int autonomieKm, int nbVitesses)
            : base(dateAchat, marque, modele, nbVitesses)
        {
            this.AutonomieKm = autonomieKm;
        }

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

        public override string ToString()
        {
            return $"{base.ToString()} Autonomie : {this.AutonomieKm} km";
        }

        //Implémentation de l'interface IRechargeable
        //La classe Cycle est dans l'obligation de rédéfinir chaque membre décrit dans l'interface
        public int MINIMUM_PERCENT_LEVEL { get => 30; }
        public int NiveauBatterie { get; private set; }

        public void Charger(int nouveauNiveau)
        {
            NiveauBatterie = nouveauNiveau;
        }
    }
}

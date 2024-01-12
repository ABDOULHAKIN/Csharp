using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCycles.BO
{
    /// <summary>
    /// La classe CycleGyroscopique hérite de la classe Cycle
    /// Elle est abstraite. Son concept est jugé trop flou pour être instanciable
    /// Elle implémente l'interface IRechargeable
    /// Chaque instance de CycleGyroscopique devient donc rechargeable.
    /// </summary>
    public abstract class CycleGyroscopique : Cycle, IRechargeable
    {
        public int AutonomieKm { get; set; }

        protected CycleGyroscopique(DateTime dateAchat, String marque, String modele, int autonomieKm)
            : base(dateAchat, marque, modele)
        {
            this.AutonomieKm = autonomieKm;
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

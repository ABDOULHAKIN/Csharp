namespace Tp_Cycle
{
    public interface IRechargeable
    {
        abstract int NiveauBatterie { get; }
        void Recharger();
    }

    public abstract class Cycle
    {
        protected static string r => Environment.NewLine;
        public string Marque { get; set; }
        public string Modele { get; set; }
        public double Tarif { get; protected set; }
        public DateTime DateAchat { get; set; }

        protected Cycle(string marque, string modele, DateTime dateAchat)
        {
            Marque = marque;
            Modele = modele;
            DateAchat = dateAchat;
        }

        public override string ToString()
        {
            return $"Type : {GetType().Name + r}Marque : {Marque} Modele : {Modele}" +
                $" Date Achat : {DateAchat} Tarif : {string.Format("{0:0.00}", Tarif)}€/heure";
        }
    }
    public class Velo : Cycle
    {
        public Velo(string marque, string modele, DateTime dateAchat, int nombreVitesse) : base(marque, modele, dateAchat)
        {
            NombreVitesse = nombreVitesse;
            Tarif = 4.9;
        }

        public int NombreVitesse { get; set; }

        public override string ToString() => base.ToString() + r + "Nombre de vitesses : " + NombreVitesse;

    }
    public class EVelo : Velo, IRechargeable
    {
        public EVelo(string marque, string modele, DateTime dateAchat, int nombreVitesse, int autonomie) : base(marque, modele, dateAchat, nombreVitesse)
        {
            Autonomie = autonomie;
            Tarif = 14.9;
        }

        public int Autonomie { get; set; }

        public int NiveauBatterie => CalculNiveauBatterie();

        private int CalculNiveauBatterie()
        {
            return Random.Shared.Next(100);
        }

        public void Recharger()
        {
          
        }

        public override string ToString() => base.ToString() + $" Autonomie : {Autonomie} km";

    }
    public abstract class CycleGyroscopique : Cycle,IRechargeable
    {
        protected CycleGyroscopique(string marque, string modele, DateTime dateAchat, int autonomie) : base(marque, modele, dateAchat)
        {
            Autonomie = autonomie;
        }

        public int Autonomie { get; set; }
        public override string ToString() => base.ToString() + r + $"Autonomie : {Autonomie} km";
        public int NiveauBatterie => CalculNiveauBatterie();

        private int CalculNiveauBatterie()
        {
            return Random.Shared.Next(100);
        }

        public void Recharger()
        {

        }
    }

    public class GyroRoue : CycleGyroscopique
    {
        public GyroRoue(string marque, string modele, DateTime dateAchat, int autonomie) : base(marque, modele, dateAchat, autonomie)
        {
            Tarif = 18.9;
        }
    }
    public class GyroPode : CycleGyroscopique
    {
        public GyroPode(string marque, string modele, DateTime dateAchat, int autonomie, int tailleMini) : base(marque, modele, dateAchat, autonomie)
        {
            TailleMini = tailleMini;
            Tarif = 29.9;
        }

        public int TailleMini { get; set; }
        public override string ToString() => base.ToString() + $" Taille Mininum : {TailleMini} cm";
    }
}

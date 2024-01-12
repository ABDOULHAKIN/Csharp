using System;

namespace GestionComptes.BO
{
    public class ComptePayant : Compte
    {
        private float commission;
        public ComptePayant(string proprietaire, DateTime dateOuverture, float commission) : base(proprietaire, dateOuverture)
        {
            this.commission = commission;
        }
        public override string Visualiser()
        {
            return base.Visualiser() + Environment.NewLine + $"Commission : {commission}€";
        }

        public override void Crediter(double montant)
        {
            base.Crediter(montant);
            AppliquerComission();
        }

        public override void Debiter(double montant)
        {
            base.Debiter(montant);
            AppliquerComission();
        }

        private void AppliquerComission()
        {
            Solde -= commission;
        }
    }
}

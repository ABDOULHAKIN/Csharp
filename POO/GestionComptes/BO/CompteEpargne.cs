using System;

namespace GestionComptes.BO
{
    public class CompteEpargne : Compte
    {
        private const int tauxFixe = 6;
        public CompteEpargne(string proprietaire, DateTime dateOuverture, double solde = 0) : base(proprietaire, dateOuverture)
        {
            Solde = solde;
        }
        public void CalculerInteret()
        {
            Solde += Solde*tauxFixe/100;
        }
        public override string Visualiser()
        {
            return base.Visualiser() + Environment.NewLine + $"Taux d'intérêt : {tauxFixe}%";
        }
    }
}

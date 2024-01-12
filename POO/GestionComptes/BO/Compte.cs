using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComptes.BO
{
    /// <summary>
    /// La classe Compte définit un type de données
    /// La classe Compte est public pour être visible du projet GestionComptes
    /// </summary>
    public abstract class Compte
    {
        //les attributs définissent les données associées à ce concept
        //par convention, les attributs sont privés (ils sont encapsulés dans la classe)

        //l'attribut compteurNumero est défini comme un membre de classe
        //cette donnée est partagée par toutes les instances de compte
        private static int compteurNumero;
        //les autres attributs sont définis comme des membres d'instance
        //les données sont propres à chaque instance de compte
        private int numero;
        private string nom;
        private DateTime dateOuverture;
        private double solde;

        //les propriétés (ou accesseurs) offrent des accès en lecture, lecture/écriture, écriture sur les attributs
        //généralement les propriétés sont publiques pour être visible des instances de compte créées par l'application
        //le numero, le nom et le solde sont en lecture seule
        //la dateOuverture est en lecture/écriture
        public int Numero
        {
            get { return numero; }
        }
        public string Nom
        {
            get { return nom; }
        }
        public DateTime DateOuverture
        {
            get { return dateOuverture; }
            set { dateOuverture = value; }
        }
        public double Solde
        {
            get { return solde; }
            protected set { solde = value; }
        }

        //les constructeurs sont des méthodes spécifiques, ils portent le nom de la classe.
        //Ils représentent les processus de création d'instances de compte pour les applications
        //Une application ne peut utiliser qu'un des constructeurs proposés pour instancier un objet de type Compte
        /// <summary>
        /// Construire une instance de compte en fournissant le propriétaire et la date d'ouverture
        /// </summary>
        /// <param name="proprietaire"></param>
        /// <param name="dateOuverture"></param>
        public Compte(string proprietaire, DateTime dateOuverture)
            : this(proprietaire) //appel à un autre constructeur de la classe pour faire une partie du travail
        {
            this.dateOuverture = dateOuverture;
        }
        /// <summary>
        /// Construire une instance de compte en fournissant que le propriétaire
        /// </summary>
        /// <param name="proprietaire"></param>
        public Compte(string proprietaire)
        {
            //le mot clé this permet d'accéder aux membres d'instance
            this.nom = proprietaire;
            this.dateOuverture = DateTime.Now;
            this.solde = 0;
            //le nom de la classe permet d'accéder aux membres de classe
            this.numero = ++Compte.compteurNumero;//on incrémente de 1 le dernier numero affecté à un Compte et stocké dans la classe Compte
        }

        //les méthodes définissent les comportements associés au concept de Compte
        //le compte peut-être crédité, débité et afficher
        public virtual void Crediter(double montant)
        {
            solde += montant;
        }
        public virtual void Debiter(double montant)
        {
            solde -= montant;
        }
        public void Crediter(double montant, Compte debiteur)
        {
            Crediter(montant);
            debiteur.Debiter(montant);
        }
        public void Debiter(double montant, Compte crediteur)
        {
            Debiter(montant);
            crediteur.Crediter(montant);
        }

        public virtual string Visualiser()
        {
            return $"Compte n° : {this.Numero} propriétaire : {this.Nom}\n" +
                $"Date d'ouverture : {this.DateOuverture.ToString("dd/MM/yyyy")}\n" +
                $"Solde : {this.Solde}";
        }

        //une méthode de classe pour accéder aux membres de classe
        public static int VoirGenerateurCompte()
        {
            return Compte.compteurNumero;
        }
    }
}

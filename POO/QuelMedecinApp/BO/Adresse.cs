using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecin.BO
{
    /// <summary>
    /// Décrit le concept d'Adresse
    /// La classe doit être publique pour être visible du projet QuelMedecinApp
    /// </summary>
    public class Adresse
    {
        //les attributs privés
        private String mentionsCompl;
        private int numero;
        private String complNumero;
        private String rue;
        private int cp;
        private String ville;


        //les propriétés d'instances en syntaxe simplifiée
        public string MentionsCompl { get => mentionsCompl; set => mentionsCompl = value; }
        public int Numero { get => numero; set => numero = value; }
        public string ComplNumero { get => complNumero; set => complNumero = value; }
        public string Rue { get => rue; set => rue = value; }
        public int Cp { get => cp; set => cp = value; }
        public string Ville { get => ville; set => ville = value; }

        //les constructeurs
        public Adresse(int numero, String complNumero, String rue, int cp, String ville) :
            this(null, numero, complNumero, rue, cp, ville) //chainage entre constructeurs
        {

        }

        public Adresse(String mentionsCompl, int numero, String complNumero,
            String rue, int cp, String ville)
        {
            this.Numero = numero;
            this.ComplNumero = complNumero;
            this.Rue = rue;
            this.Cp = cp;
            this.Ville = ville.ToUpper();
            this.MentionsCompl = mentionsCompl;
        }

        //une méthode d'instance publique
        /// <summary>
        /// Affiche à la console l'état d'une instance de Adresse
        /// La méthode est marquée comme obselete
        /// Complément
        /// XXbis rue XXXXXXXXX
        /// 00000 XXXXXXXXXXXXX
        /// </summary>
        [Obsolete("Utilisez la méthode ToString", true)]
        public void Afficher()
        {
            if (this.MentionsCompl != null)
            {
                Console.WriteLine(mentionsCompl);
            }
            //formater le complément numéro
            String complNumero = this.ComplNumero != null ? this.ComplNumero : "";
            //formater le code postal
            String cp = String.Format("{0:D5}", this.Cp);
            Console.Write($"{this.Numero}{complNumero} {this.Rue}\n{cp} {this.Ville}\n");
        }

        //Une méthode substituée (redéfinie)
        /// <summary>
        /// Retourne l'état d'une instance de Adresse 
        /// sous la forme d'une chaine de caractères formatée
        /// Complément
        /// XXbis rue XXXXXXXXX
        /// 00000 XXXXXXXXXXXXX
        /// </summary>
        public override string ToString()
        {
            if (this.MentionsCompl != null)
            {
                Console.WriteLine(mentionsCompl);
            }
            //formater le complément numéro
            String complNumero = this.ComplNumero != null ? this.ComplNumero : "";
            //formater le code postal
            String cp = String.Format("{0:D5}", this.Cp);
            return ($"{this.Numero}{complNumero} {this.Rue}\n{cp} {this.Ville}\n");
        }
    }
}

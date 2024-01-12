using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niveau3 {
    public class Joueur {
        public string Nom { get; set; }
        public Anneau<Carte> Cartes { get; } = new Anneau<Carte>();
        public Joueur(string nom) {
            Nom = nom;
        }
        override public string ToString() {
            return Nom;
        }
    }
}

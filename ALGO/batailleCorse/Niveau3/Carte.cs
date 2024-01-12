using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niveau3 {
    public class Carte {
        public Valeur Valeur { get; set; }
        public Bois Bois { get; set; }
        override public string ToString() {
            return Valeur.ToString() + " de " + Bois.ToString();
        }
    }
}

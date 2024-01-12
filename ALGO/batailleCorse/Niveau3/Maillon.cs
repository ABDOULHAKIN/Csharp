using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niveau3 {
    public class Maillon<T> {
        public T Valeur { get; }
        public Maillon<T> Suivant { get; set; }
        public Maillon(T valeur, Maillon<T>? suivant = null) {
            Valeur = valeur;
            Suivant = suivant ?? this;
        }
    }
}

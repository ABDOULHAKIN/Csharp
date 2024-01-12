using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niveau3 {
    public class Anneau<T> where T : class {
        public Maillon<T>? Entree { get; private set; }
        public int NbElements { get; private set; } = 0;
        public void AjouterALaFin(T element) {
            NbElements++;
            if(Entree == null) {
                Entree = new Maillon<T>(element);
            } else {
                Maillon<T> nouveau = new Maillon<T>(element, Entree);
                Maillon<T> dernier = Entree;
                while(dernier.Suivant != Entree)
                    dernier = dernier.Suivant;
                dernier.Suivant = nouveau;
            }
        }
        public T RetirerPremier() {
            if(NbElements == 0)
                throw new Exception("Aucun élément à retirer");
            T element = Entree!.Valeur;
            Retirer(element);
            return element;
        }

        public void Retirer(T element) {
            if(NbElements > 0) {
                int i = 0;
                Maillon<T> courant = Entree!;
                while(i < NbElements && !courant.Suivant.Valeur.Equals(element)) {
                    i++;
                    courant = courant.Suivant;
                }
                if(courant.Suivant.Valeur.Equals(element)) {
                    NbElements--;
                    if(NbElements == 0)
                        Entree = null;
                    else
                        if(Entree == courant.Suivant)
                        Entree = courant;
                    courant.Suivant = courant.Suivant.Suivant;
                }
            }
        }
    }
}

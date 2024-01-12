using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niveau3 {
    public class BatailleCorse {
        private Anneau<Joueur> joueurs = new Anneau<Joueur>();
        private List<Carte> cartesJouees = new List<Carte>();

        public void Jouer() {
            joueurs.AjouterALaFin(new Joueur("Julie"));
            joueurs.AjouterALaFin(new Joueur("Maxime"));
            joueurs.AjouterALaFin(new Joueur("Mélanie"));

            Distribuer();
            Maillon<Joueur> courant = joueurs.Entree!;
            Maillon<Joueur> precedent = joueurs.Entree!;
            while(joueurs.NbElements > 1) {
                int defi = cartesJouees.Any() ? ((int)cartesJouees[^1].Valeur) : 0;
                if(defi > 0) {
                    // S'il y a un défi en cours
                    int nbTentatives = 0;
                    Carte? carte;
                    do {
                        carte = JouerUneCarte(courant);
                        nbTentatives++;
                    } while(nbTentatives < defi && carte != null && carte.Valeur < 0);
                    if(carte == null || carte.Valeur < 0) {
                        Console.WriteLine("Le défi est perdu ! " + precedent.Valeur.Nom + " remporte " + cartesJouees.Count + " cartes");
                        //  : le joueur précédent remporte les cartes mises en jeu !
                        foreach(Carte c in cartesJouees) {
                            precedent.Valeur.Cartes.AjouterALaFin(c);
                        }
                         cartesJouees.Clear();
                    }
                } else {
                    // S'il y a pas de défi
                    JouerUneCarte(courant);
                }
                precedent = courant;
                courant = courant.Suivant;
            }
            Console.WriteLine(joueurs.Entree!.Valeur.Nom + " gagne !");

        }

        private Carte? JouerUneCarte(Maillon<Joueur> courant) {
            Carte? carte = null;
            if(courant.Valeur.Cartes.NbElements == 0) {
                Console.WriteLine(courant.Valeur.Nom + " n'a plus de carte ! Elimination !");
                joueurs.Retirer(courant.Valeur);
            } else {
                carte = courant.Valeur.Cartes.RetirerPremier();
                Console.WriteLine(courant.Valeur.Nom + " joue un " + carte);
                cartesJouees.Add(carte);
            }
            Console.ReadKey(true);
              return carte;
        }

        private void Distribuer() {
            if(joueurs.NbElements == 0)
                throw new ArgumentException("Impossible de distribuer des cartes s'il n'y a aucun joueur !");
            List<Carte> cartes = new List<Carte>();
            foreach(Bois bois in Enum.GetValues(typeof(Bois)))
                foreach(Valeur valeur in Enum.GetValues(typeof(Valeur)))
                    cartes.Add(new Carte { Valeur = valeur, Bois = bois });
            Maillon<Joueur> courant = joueurs.Entree!;
            while(cartes.Any()) {
                courant.Valeur.Cartes.AjouterALaFin(cartes.RetirerAleatoirement());
                courant = courant.Suivant;
            }
        }
    }
}

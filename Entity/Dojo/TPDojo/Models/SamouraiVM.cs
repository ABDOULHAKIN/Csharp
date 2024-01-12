using BO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace TPDojo.Models {
    public class SamouraiVM {
        public Samourai Samourai { get; set; }
        public SelectList? ChoixArme { get; set; }
        public SelectList? ChoixArtsMartiaux { get; set; }
        [DisplayName("Arts martiaux pratiqués")]
        public List<int>? IdsArtsMartiaux { get; set; }

        public SamouraiVM(Samourai samourai, SelectList choixArme, SelectList choixArtsMartiaux) {
            Samourai = samourai;
            ChoixArme = choixArme;
            ChoixArtsMartiaux = choixArtsMartiaux;
        }

        public SamouraiVM() {
        }
    }
}

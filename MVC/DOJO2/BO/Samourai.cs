using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO {
    public class Samourai : Entite {
        public int Force { get; set; }
        public Arme? Arme { get; set; }
        [DisplayName("Arme")]
        public int? ArmeId { get; set; }
        [DisplayName("Arts matriaux pratiqués")]
        public List<ArtMartial>? ArtsMartiaux { get; set; }
        public int Potentiel {
            get {
                int p = Force;
                if(Arme is not null) {
                    p += Arme.Degats;
                }
                if(ArtsMartiaux != null  && ArtsMartiaux.Any()) {
                    p *= 1 + ArtsMartiaux.Count;
                }
                return p;
            }
        }
    }
}

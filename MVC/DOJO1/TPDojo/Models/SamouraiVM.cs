using BO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TPDojo.Models {
    public class SamouraiVM {
        public Samourai Samourai { get; set; }
        public SelectList? ChoixArme { get; set; }
    }
}

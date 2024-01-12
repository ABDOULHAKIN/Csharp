using Festival.BO;

namespace Festival.Web.ViewModels
{
    public class ArtisteViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int? GroupeId { get; set; }
        public Groupe? Groupe { get; set; }
    }
}

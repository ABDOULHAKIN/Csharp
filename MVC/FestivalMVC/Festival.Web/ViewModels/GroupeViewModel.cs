using System.ComponentModel;

namespace Festival.Web.ViewModels
{
    public class GroupeViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [DisplayName("Date Creation")]
        public DateTime DateCreation { get; set; }
        public string DateCreationString { get; set; }

    }
}

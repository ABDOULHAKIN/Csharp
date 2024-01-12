using BO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TPPizza.Models {
    public class PizzaVM {
        public int Id { get; set; }
        [Required(ErrorMessage ="Le nom d'une pizza est obligatoire")]
        [StringLength(20, MinimumLength =5, ErrorMessage ="Le nom de la pizza doit contenir entre {2} et {1} caractères")]
        public string Nom { get; set; }
        [Required(ErrorMessage ="Une pizza doit nécessairement avoir une pâte")]
        public int IdPate { get; set; }
        public SelectList ChoixPate => new SelectList(Pizza.PatesDisponibles, "Id", "Nom");
        public List<int> IdsIngredients { get; set; }
        public SelectList ChoixIngredients => new SelectList(Pizza.IngredientsDisponibles, "Id", "Nom");
    }
}

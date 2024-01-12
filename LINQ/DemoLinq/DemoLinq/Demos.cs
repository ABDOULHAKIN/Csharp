using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    internal class Demos
    {


        public void Demo4()
        {

            var petanque = new Livre { Nom = "Fan de Pétanque" };
            var lecture = new Livre { Nom = "Fan de Lecture" };
            var velo = new Livre { Nom = "Fan de Vélo" };
            var listePersonne = new List<Personne> {
                new Personne { Age=32, Nom="Marie", LivreEmpruntes = new List<Livre>{velo, lecture } },
                new Personne { Age=52, Nom="Jean", LivreEmpruntes = new List<Livre>() },
                new Personne { Age=32, Nom="Mélanie", LivreEmpruntes = new List<Livre>{petanque } },
                new Personne { Age=36, Nom="Julien", LivreEmpruntes = new List<Livre>{petanque, velo, lecture } }
            };

            var miaou = new Animal { Nom = "Miaou", Prorio = listePersonne[1] };
            var medor = new Animal { Prorio = listePersonne[2], Nom = "Médor" };
            var titi = new Animal { Prorio = listePersonne[1], Nom = "Titi" };
            var donald = new Animal { Nom = "Donald" };
            List<Animal> listeAnimaux = new List<Animal> { miaou, medor, titi, donald };

            var result = listePersonne.GroupBy(p => p.Age);
            


            //var firstGrp = result.First();
            //foreach (var groupe in result)
            //{
            //    Console.WriteLine(" - age : " + groupe.Key);
            //    foreach (Personne personne in groupe)
            //    {
            //        Console.WriteLine(" - " + personne.Nom);
            //    }
            //}


            //foreach (var groupe in listePersonne.GroupBy(p => p.Age,
            //    (age, listePersonnes) => new { Age = age, ListePersonnes = listePersonnes }))
            //{
            //    Console.WriteLine(" - " + groupe.Age);
            //    foreach (Personne personne in groupe.ListePersonnes)
            //    {
            //        Console.WriteLine(" - " + personne.Nom);
            //    }
            //}

            foreach (var ligne in listePersonne.Join(listeAnimaux,
                p => p,
                a => a.Prorio, (p, a) => new { Personne = p, Animal = a }))
            {
                Console.WriteLine(" - " + ligne.Personne.Nom + " -> " + ligne.Animal.Nom);
            }

        }
        public void Demo3()
        {
            var petanque = new Livre { Nom = "Fan de Pétanque" };
            var lecture = new Livre { Nom = "Fan de Lecture" };
            var velo = new Livre { Nom = "Fan de Vélo" };
            var bilboquet = new Livre { Nom = "Fan de  bilboquet" };

            var listePersonne = new List<Personne> {
new Personne { Age=32, Nom="Marie", LivreEmpruntes = new List<Livre>{velo, lecture } },
new Personne { Age=52, Nom="Jean", LivreEmpruntes = new List<Livre>() },
new Personne { Age=32, Nom="Mélanie", LivreEmpruntes = new List<Livre>{petanque } },
new Personne { Age=36, Nom="Julien", LivreEmpruntes = new List<Livre>{petanque, velo, lecture } }
};

            Console.WriteLine("Les âges des personnes");
            foreach (int age in listePersonne.Select(p => p.Age))
            {
                Console.WriteLine(" - " + age);
            }

            if (listePersonne.All(x => x.Nom == "Quentin"))
            {

            }
        }
    }
}

using LocationCycles.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCyclesApp
{
    class Program
    {
		static void Main(string[] args)
		{
			List<Cycle> cyclesALouer = new List<Cycle>();
			
			cyclesALouer.Add(new Velo(new DateTime(2017, 6, 2), "Lapierre", "speed 400", 27));
			cyclesALouer.Add(new Velo(new DateTime(2018, 4, 9), "Btwin", "riverside 900", 10));
			EVelo e_city = new EVelo(new DateTime(2019, 7, 20), "NAKAMURA", "Vélo électrique E-City Ltd", 80, 10);
			cyclesALouer.Add(e_city);
			cyclesALouer.Add(new Gyropode(new DateTime(2018, 6, 5), "Segway", "Ninebot Elite", 40, 150));
			cyclesALouer.Add(new Gyropode(new DateTime(2017, 5, 2), "Weebot", "Echo", 35, 160));
			cyclesALouer.Add(new Gyroroue(new DateTime(2018, 3, 25), "Immotion", "v8", 40));
			cyclesALouer.Add(new Gyroroue(new DateTime(2018, 3, 25), "Segway", "Ninebot One E+", 30));


			Console.WriteLine();
			Console.WriteLine("_____________ Tous les cycles proposés à la location _____________");
			foreach (Cycle cycle in cyclesALouer)
			{
				Console.WriteLine($" - {cycle.ToString()}");
			}

			Console.WriteLine();
			Console.WriteLine("_____________ Tous les velos proposés à la location ______________");
			foreach (Cycle cycle in cyclesALouer)
			{
				if (cycle is Velo) { 
					Console.WriteLine($" - {cycle.ToString()}");
				}
			}

			Console.WriteLine();
			Console.WriteLine("______ Tous les cycles rechargeables proposés à la location ______");
			foreach (Cycle cycle in cyclesALouer)
			{
				if (cycle is IRechargeable)
				{
					Console.WriteLine($" - {cycle.ToString()}");
				}
			}


			e_city.Charger(35);
			Console.WriteLine();
			Console.WriteLine("Niveau de batterie du Velo E-CITY : " + e_city.NiveauBatterie);


			Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
			Console.ReadKey();
		}

	}
}

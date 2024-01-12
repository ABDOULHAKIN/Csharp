using System.Reflection.Metadata;
using System.Text;
using Tp_Cycle;

Console.OutputEncoding = Encoding.UTF8;
List<Cycle> cycles = new List<Cycle>();
void Location(Cycle cycle)
{
    cycles.Add(cycle);
}

Cycle laPierre = new Velo("LaPierre", "speed 400", new DateTime(2017, 6, 02), 27);
Cycle btwin = new Velo("Btwin", "riversie 900", new DateTime(2018, 4, 09), 10);
Cycle nakamura = new EVelo("NAKAMURA", "Velo electrique E-City Ltd", new DateTime(2019, 7, 20), 10, 80); // Poser un question sur Evelo ou Cycle \\
Cycle segwayPode = new GyroPode("Segway", "Ninebot Elite", new DateTime(2018, 6, 05), 35, 150);
Cycle weboot = new GyroPode("Weboot", "Echo", new DateTime(2017, 5, 02), 35, 160);
Cycle immotion = new GyroRoue("Immotion", "v8", new DateTime(2018, 3, 25), 40);
Cycle segwayRoue = new GyroRoue("Segway", "Ninebot One E+", new DateTime(2018, 3, 25), 30);

Location(laPierre);
Location(btwin);
Location(nakamura);
Location(segwayPode);
Location(weboot);
Location(immotion);
Location(segwayRoue);

Console.WriteLine("____________________ Tous les cycles proposés à la location ___________________");
foreach (var cycle in cycles)
{
    Console.WriteLine(cycle);
}

Console.WriteLine("\n____________________ Tous les Velos proposés à la location ____________________");
foreach (var cycle in cycles)
{
    if (cycle is Velo velo)
        Console.WriteLine(velo);
}

Console.WriteLine("\n______________ Tous les cycles rechargeable proposés à la location ____________");
foreach (var cycle in cycles)
{
    if (cycle is IRechargeable rechargeable)
    {
        Console.WriteLine(cycle.ToString());
        Console.WriteLine(rechargeable.NiveauBatterie);
    }
   
}



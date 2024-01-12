var acceptedCoins = new int[,] { { 200, 0 }, { 100, 1 }, { 50, 0 }, { 20, 2 }, { 10, 0 }, { 5, 0 } };
var changeCoins = new int[6];
double coffeePriceInEuro = 0.6;
int coffeePriceInCents = 60;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
Console.WriteLine($"Bonjour,le café coute {coffeePriceInEuro}€ veuillez insérer une pièce");

var credit = 0;
do
{
    if (!double.TryParse(Console.ReadLine(), out double coin))
        Console.WriteLine("Ceci n'est pas une pièce");
    var coinInCents = (int)(coin * 100);

    var isCoinAccepted = false;
    for (int i = 0; i < acceptedCoins.GetLength(0); i++)
    {
        if (acceptedCoins[i, 0] == coinInCents)
        {
            acceptedCoins[i, 1]++; // on incrémente le nombre de pièces pour cette valeur
            isCoinAccepted = true;
            break;
        }
    }

    if (isCoinAccepted)
    {
        credit += coinInCents;
        Console.WriteLine($"Votre crédit est de {credit / 100.0}");
    }
} while (credit <= coffeePriceInCents);

var changeAmount = credit - coffeePriceInCents;
if (!IsChangeAvailable(changeAmount))
{
    Console.WriteLine("Je vous rend votre credit, car je ne peux faire la monnaie");
    return;
}

Console.WriteLine("Voici votre café");
Console.WriteLine($"Je vous dois {changeAmount / 100.0}");
for (int i = 0; i < changeCoins.Length; i++)
{
    if (changeCoins[i] > 0)
    {
        var s = changeCoins[i] > 1 ? "s" : "";
        Console.WriteLine($"Voici {changeCoins[i]} pièce{s} de {acceptedCoins[i, 0] / 100.0}");
    }
}


bool IsChangeAvailable(int changeAmount)
{
    for (int i = 0; i < acceptedCoins.GetLength(0); i++)
    {
        while (acceptedCoins[i, 0] <= changeAmount && acceptedCoins[i, 1] > 0)
        {
            changeCoins[i]++;
            changeAmount -= acceptedCoins[i, 0];
            acceptedCoins[i, 1]--;
        }
    }
    return changeAmount == 0;
}






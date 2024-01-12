int[] acceptedCoins = new int[] { 200, 100, 50, 20, 10, 5 };
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
    for (int i = 0; i < acceptedCoins.Length; i++)
    {
        if (acceptedCoins[i] == coinInCents)
        {
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
Console.WriteLine("Voici votre café");
var change = credit - coffeePriceInCents;
Console.WriteLine(  $"Je vous dois {change / 100.0}");

for (int i = 0; i < acceptedCoins.Length; i++)
{
    while (acceptedCoins[i] <= change)
    {
        Console.WriteLine($"Voici une pièce de {acceptedCoins[i] / 100.0}");
        change -= acceptedCoins[i];
    }
}

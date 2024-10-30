using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.Test;
using GestionGarage.Classes.MenuGestion;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
TestMenu test = new TestMenu();

if (test.AfficherMenuTests())
{
    test.ExecuterTests();
}

Garage garage = new Garage("super garage !");
Menu menu = new Menu(garage);

try
{
    menu.Start();
}
catch (Exception e)
{
    Console.WriteLine($"Une erreur est survenue : {e.Message}");
}

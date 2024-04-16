// See https://aka.ms/new-console-template for more information
using ProyectoNugetCoches;

Console.WriteLine("Mi primer package Nuget");
Garaje g = new Garaje();
List<Coche> cars = g.GetCoches();
foreach(Coche car in cars)
{
    Console.WriteLine(car.Marca + " " + car.Modelo);
}

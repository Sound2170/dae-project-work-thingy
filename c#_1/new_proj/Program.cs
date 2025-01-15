// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

int myAge = 98;
float averageScore = 21.1f;
string favoriteColor = "Blue";
favoriteColor = "green";
//bool isSunny = false;
myAge = 129;
Console.WriteLine(favoriteColor);
//Console.WriteLine(isSunny);
Console.WriteLine(averageScore);
Console.WriteLine(myAge);
// variables ^^
bool isSunny = true;

if (isSunny)
{
    Console.WriteLine("let's have some ice cream!");
}
bool isRaining = false;
bool isSnowing = true;

if (isRaining)
{
    Console.WriteLine("Stay inside brode, it's raining out!!");
}
else if (isSnowing)
{
    Console.WriteLine("it's snowing!! go outside to have fun or you could stay inside to drink some hot hot chocalate");
}

int temperture = 67;

if (temperture > 50)
{
    Console.WriteLine("it's warm outside! go out now!!");
}
else
{
    Console.WriteLine("it's not warm! you have been warned!");
}
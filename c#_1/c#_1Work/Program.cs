// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Security.Principal;
//---------------------------
// Varialbles and Data types 
//---------------------------
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
//---------------------------
// conditional 
//---------------------------

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
//---------------------------
// Loops 
//---------------------------

int shotsMade = 5;
while (shotsMade < 10) 
{
    Console.WriteLine("Shot made!");
    shotsMade++;
}


for (int jumps = 0; jumps < 20 ; jumps ++)
{
    Console.WriteLine("You've jumped " + (jumps + 1) + (" times!"));
}

//---------------------------
// functions 
//---------------------------

int add (int a, int b)
{
    return a+b;
}
int result = add(34, 21);
Console.WriteLine(result);

//---------------------------
// access levels 
//---------------------------

public int jumpLevel = 6;

private string nameOfPlayer = "booboo";

//---------------------------
// arrays and lists 
//---------------------------

int[] numbers = {5,10,15,20,25,30};
Console.WriteLine(numbers[0]);

List<string> friends = new List<string>();
friends.Add("bob");
friends.Add("bobby boo");
friends.Add("googoo");

Console.WriteLine(friends);

for(int i=0;i>friends.Count;i++)
{
    Console.WriteLine(friends[i]);
}
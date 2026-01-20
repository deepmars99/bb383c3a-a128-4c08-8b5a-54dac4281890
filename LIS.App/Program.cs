using System;
using LIS.App;

Console.WriteLine("Enter numbers:");
var input = Console.ReadLine();

var result = LISFinder.Find(input);
Console.WriteLine(result);

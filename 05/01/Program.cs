// See https://aka.ms/new-console-template for more information
string foo = "Hello:World";

int commaIndex = foo.IndexOf(':');

Console.WriteLine($"{foo.Substring(0,commaIndex)}\t{foo.Substring(commaIndex)}");

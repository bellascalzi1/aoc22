// See https://aka.ms/new-console-template for more information

List<int> calories = new List<int>();
int localTotal = 0;

string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach (string line in lines) {
    // If there is an empty line, it is the end of that elf's food
    if (String.IsNullOrEmpty(line)) {
        calories.Add(localTotal);
        // Reset the number of calories for the next elf
        localTotal = 0;
    }
    else {
        localTotal += int.Parse(line);
    }

}

// Get the calories of the last elf
calories.Add(localTotal);

calories = calories.OrderByDescending(c => c).ToList();
Console.WriteLine($"Elf with the most calories has {calories[0]}");

int topThreeCaloriesSum = calories.Take(3).Sum();
Console.WriteLine($"Top 3 Elves in total are carrying {topThreeCaloriesSum}");

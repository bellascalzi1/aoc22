// See https://aka.ms/new-console-template for more information

// Get all lines
string[] lines = System.IO.File.ReadAllLines(@"sample-input.txt");

int highestCalories = 0;
int localTotal = 0;

foreach (string line in lines) {
    // If there is an empty line, it is the end of that elf's food
    if (String.IsNullOrEmpty(line)) {
        Console.Write($"= {localTotal} \n");
        
        // Update the highest calories if needed
        if(localTotal > highestCalories) {
            highestCalories = localTotal;
        }
        // Reset the number of calories for the next elf
        localTotal = 0;
    }
    else {

        Console.Write(line + " ");
        localTotal += int.Parse(line);
    }

}

// Get the calories of the last elf
Console.Write($"= {localTotal} \n");
if(localTotal > highestCalories) {
    highestCalories = localTotal;
}

Console.WriteLine($"top is {highestCalories}");


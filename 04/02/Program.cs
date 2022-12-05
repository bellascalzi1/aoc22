int score = 0;
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(string line in lines)
{
    string[] assignments = line.Split(',');
    
    // Convert each elf's starting and ending section assignments into a list of 2 ints [start, end]
    List<int> elf1Assignment = assignments[0].Split('-').ToList().ConvertAll<int>(s => int.Parse(s));
    List<int> elf2Assignment = assignments[1].Split('-').ToList().ConvertAll<int>(s => int.Parse(s));

    bool doesOverlap = (elf1Assignment[1] >= elf2Assignment[0]) && (elf1Assignment[0] <= elf2Assignment[1]);
    if (doesOverlap) score++;
}
Console.WriteLine(score);
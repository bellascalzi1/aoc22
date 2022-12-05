// Parse the values first

string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// lines = System.IO.File.ReadAllLines(@"sample.txt");
int score = 0;
foreach(string line in lines)
{
    string[] assignments = line.Split(',');
    List<int> elf1Assignment = assignments[0].Split('-').ToList().ConvertAll<int>(s => int.Parse(s));
    List<int> elf2Assignment = assignments[1].Split('-').ToList().ConvertAll<int>(s => int.Parse(s));
    // Console.WriteLine($"Start is {elf1Assignment[0]} End is {elf1Assignment[1]}");
    List<int> elf1Range = Enumerable.Range(elf1Assignment[0], (elf1Assignment[1] - elf1Assignment[0]) + 1).ToList();
    List<int> elf2Range = Enumerable.Range(elf2Assignment[0], (elf2Assignment[1] - elf2Assignment[0]) + 1).ToList();
    
    // bool doesOverlap = ( (elf1Assignment[0] <= elf2Assignment[0]) && (elf1Assignment[1] >= elf2Assignment[1]) ) || ( (elf2Assignment[0] <= elf1Assignment[0]) && (elf2Assignment[1] >= elf1Assignment[1] ) );
    bool doesOverlap = (elf1Assignment[1] >= elf2Assignment[0]) && (elf1Assignment[0] <= elf2Assignment[1]);
    Console.WriteLine(doesOverlap);
    if (doesOverlap) score++;

    // Console.WriteLine(blah.Count);
    // blah.ForEach(Console.Write);
    // Console.WriteLine();
    // string[] assignment1 = assignments[0].Split('-');

    // string[] assignment2 = assignments[1].Split('-');

    // var hello = Enumerable.Range(int.Parse(assignment1[0]), ( int.Parse(assignment1[1]) - int.Parse(assignment1[0]) + 1));
    // int[] assignment1Numbers = int.Parse(assignment1[0])..int.Parse(assignment1[1]);
    
}
Console.WriteLine($"{score}");


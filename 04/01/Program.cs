int score = 0;
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(string line in lines)
{
    string[] assignments = line.Split(',');
    
    // Convert each elf's starting and ending section assignments into a list of 2 ints [start, end]
    List<int> elf1Assignment = assignments[0].Split('-').ToList().ConvertAll<int>(s => int.Parse(s));
    List<int> elf2Assignment = assignments[1].Split('-').ToList().ConvertAll<int>(s => int.Parse(s));

    /**
    Checks for one of the 2 types of full overlaps:
    1. Where the 2nd Elf's assignments overlaps the 1st elf's eg
    .2345678.  2-8
    ..34567..  3-7
    In this case Elf 1's start is always going to be <= Elf 2's and ELf 1's end point is always going to be >= Elf 2's, so this is what we check for.  
    2. Where the 1st Elf's assignments overlap the 2nd Elf's eg:
    .....6...  6-6
    ...456...  4-6 
    This is just the first condition reversed.
    **/  
    bool doesOverlap = ( (elf1Assignment[0] <= elf2Assignment[0]) && (elf1Assignment[1] >= elf2Assignment[1]) ) || ( (elf2Assignment[0] <= elf1Assignment[0]) && (elf2Assignment[1] >= elf1Assignment[1] ) );
    // bool doesOverlap = (elf1Assignment[1] >= elf2Assignment[0]) && (elf1Assignment[0] <= elf2Assignment[1]);
    if (doesOverlap) score++;
}
Console.WriteLine(score);


int getPriority(char c) {
    int priority = c & 31;
    if(char.IsUpper(c)) priority += 26;
    return priority;
}

int score = 0;
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(string line in lines) {
    int half = line.Length / 2;

    // Use a hashset because it only adds one instance of each character
    HashSet<char> chars = new HashSet<char>();

    string firstHalf = line.Substring(0, half);
    string secondHalf = line.Substring(half);
    
    // Console.WriteLine($"{firstHalf}\t{secondHalf}");
    
    foreach(char c in firstHalf) {
        chars.Add(c);
    }

    foreach(char c in secondHalf) {
        // Since there is only ever one character that is duplicated in each half we can stop here
        if(chars.Contains(c)) {
            score += getPriority(c);
            break;
        }
    }

}
Console.WriteLine(score);

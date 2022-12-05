
int getPriority(char c) {
    int score = c & 31;
    if(char.IsUpper(c)) score += 26;
    return score;
}

int score = 0;
// string[] lines = System.IO.File.ReadAllLines(@"sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(string line in lines) {
    int half = line.Length / 2;
    HashSet<char> chars = new HashSet<char>();

    string firstHalf = line.Substring(0, half);
    string secondHalf = line.Substring(half);
    
    Console.WriteLine($"{firstHalf}\t{secondHalf}");
    
    foreach(char c in firstHalf) {
        chars.Add(c);
        // Console.WriteLine($"{c} -> {getAlphabetPosition(c)}");
    }

    foreach(char c in secondHalf) {

        if(chars.Contains(c)) {
            score += getPriority(c);
            break;
        }
    }

}
Console.WriteLine(score);

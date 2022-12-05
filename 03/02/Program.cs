int getPriority(char c) {
    int score = c & 31;
    if(char.IsUpper(c)) score += 26;
    return score;
}

int score = 0;
int lineNo = 0;
// Keep track of characters that are present in each set of 3 lines
Dictionary<char,int> dict = new Dictionary<char, int>();

using(StreamReader sr = new StreamReader("input.txt")) {
    string line;
    while((line = sr.ReadLine()) != null) {
        // Create list of characters that appear at least once
        HashSet<char> seenChars = line.ToHashSet();
        foreach(char c in seenChars) {
            if(dict.ContainsKey(c)) {
                dict[c]++;
            }
            else {
                dict.Add(c,1);
            }
        }
        lineNo++;

        if(lineNo == 3) {
            // Find whick key had value 3
            char val = dict.FirstOrDefault(x => x.Value == 3).Key;
            Console.WriteLine($"Value is {val}");
            
            score += getPriority(val);
            dict.Clear();
            lineNo = 0;
        }
    }
}
Console.WriteLine(score);

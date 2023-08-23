int findStartOfPacket(string s) {
    // "abcde"
    
    for(int i=0; i<= s.Length - 14; i++) {
        // Console.WriteLine(s.Substring(i, 4));
        HashSet<char> foo = s.Substring(i,14).ToHashSet();
        if(foo.Count == 14) return i + 14;
    }
    return -1;
}

string input = System.IO.File.ReadAllLines(@"input.txt").FirstOrDefault();
Console.WriteLine(findStartOfPacket(input));
// Console.WriteLine(findStartOfPacket("mjqjpqmgbljsphdztnvjfqwrcgsmlb"));
// Console.WriteLine(findStartOfPacket("bvwbjplbgvbhsrlpgdmjqwftvncz"));
// Console.WriteLine(findStartOfPacket("nppdvjthqldpwncqszvftbrmjlhg"));
// Console.WriteLine(findStartOfPacket("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"));
// Console.WriteLine(findStartOfPacket("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"));


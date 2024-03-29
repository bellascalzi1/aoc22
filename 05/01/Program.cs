﻿
List<string> starting = new List<string>();

using(StreamReader sr = new StreamReader(@"input.txt")) {
   // Read to the first newline
   string? line = sr.ReadLine();
   while(!string.IsNullOrEmpty(line)) {
      starting.Add(line);
      line = sr.ReadLine();
   } 

   int startingNoLines = starting.Count;
   int noStacks = (starting[^1].Length / 4) + 1;

   List<Stack<char>> stacks = new List<Stack<char>>();
   for(int i=0; i<noStacks; i++) {
      stacks.Add(new Stack<char>());
   }

   List<string> blah = starting.GetRange(0, starting.Count - 1);
   blah.Reverse();
   // blah.ForEach(b => Console.WriteLine(b.Length));

   // Get each character into its respective stack
   foreach(string l in blah) {
      for(int i=1, j=0; i<l.Length; i+=4, j++) {
         if(!char.IsWhiteSpace(l[i])) {
            Console.WriteLine($"Push {l[i]} onto stack no {j}");
            stacks[j].Push(l[i]);
         }
      }
   }

   line = sr.ReadLine();
   while(line != null) {
      string[] lineTokens = line.Split(' ');
      int noCratesToMove = int.Parse(lineTokens[1]);
      int stackToMoveFrom = int.Parse(lineTokens[3]) - 1;
      int stackToMoveTo = int.Parse(lineTokens[5]) - 1;
      
      for(int i=0; i<noCratesToMove; i++) {
         char temp = stacks[stackToMoveFrom].Pop(); 
         stacks[stackToMoveTo].Push(temp);
      }
      Console.WriteLine($"Move {noCratesToMove} from stack {stackToMoveFrom} to stack {stackToMoveTo}");

      line = sr.ReadLine();
   }
   string res = "";
   for(int i=0; i<noStacks; i++) {
      res += stacks[i].Peek();
   }
   Console.WriteLine(res);
}


// foreach(Stack<char> stack in stacks) {
//    Console.WriteLine("New Stack");
//    foreach(char c in stack) {
//       Console.WriteLine(c);
//    }
// }

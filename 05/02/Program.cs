
// TODO: Parse fine input first and split it into two lines, starting and actions
List<string> starting = new List<string>();

using(StreamReader sr = new StreamReader(@"input.txt")) {
   // Read to the first newline
   string? line = sr.ReadLine();
   while(!string.IsNullOrEmpty(line)) {
      starting.Add(line);
      line = sr.ReadLine();
   } 
   
   // Create the starting stacks
   int noStacks = (starting[^1].Length / 4) + 1;
   List<Stack<char>> stacks = new List<Stack<char>>();
   for(int i=0; i<noStacks; i++) {
      stacks.Add(new Stack<char>());
   }

   List<string> stacksInput = starting.GetRange(0, starting.Count - 1);
   stacksInput.Reverse();

   // Get each character into its respective stack
   foreach(string l in stacksInput) {
      for(int i=1, j=0; i<l.Length; i+=4, j++) {
         if(!char.IsWhiteSpace(l[i])) {
            stacks[j].Push(l[i]);
         }
      }
   }

   line = sr.ReadLine();
   
   // Keep a list of crates that are popped off in each step so we can then push them onto the new stack in order
   List<char> crates = new List<char>();

   // Parse and perform each crane movement
   while(line != null) {
      string[] lineTokens = line.Split(' ');
      int noCratesToMove = int.Parse(lineTokens[1]);
      int stackToMoveFrom = int.Parse(lineTokens[3]) - 1;
      int stackToMoveTo = int.Parse(lineTokens[5]) - 1;
      
      for(int i=0; i<noCratesToMove; i++) {
         char temp = stacks[stackToMoveFrom].Pop(); 
         crates.Add(temp);
      }
      
      for(int i=crates.Count-1; i>=0; i--) {
         stacks[stackToMoveTo].Push(crates[i]);
      }

      crates.Clear();
      line = sr.ReadLine();
   }
   
   // Print output
   string res = "";
   for(int i=0; i<noStacks; i++) {
      res += stacks[i].Peek();
   }
   Console.WriteLine(res);
}
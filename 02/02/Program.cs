// See https://aka.ms/new-console-template for more information
// X = Lose, Y = Draw, Z = Win

int getMoveValue(char move) {
    switch(move) {
        // Rock
        case 'A':
        case 'X':
            return 0;
        // Paper
        case 'B':
        case 'Y':
            return 1;
        // Scissors
        case 'C':
        case 'Z':
            return 2;
        default:
            return 0;
    }
}

// Get the move needed for the outcome
int getMoveNeeded(int opponentMove, int outcomeNeeded) {
    // Console.WriteLine($" MOVE NEEDED Opp Move {opponentMove} Outcome Needed {outcomeNeeded}");
    switch(opponentMove) {
        // Rock
        case 0:
            switch(outcomeNeeded) {
                // Lose
                case 0:
                    // Return Scissors
                    return 2;
                // Draw
                case 1:
                    // Return Rock
                    return 0;
                // Win
                case 2:
                    // Return Paper
                    return 1;
                default:
                    return -1;
                
            }
        // Paper
        case 1:
            switch(outcomeNeeded) {
                // Lose
                case 0:
                    // Return Rock
                    return 0;
                // Draw
                case 1:
                    // Return Paper
                    return 1;
                // Win
                case 2:
                    // Return Scissors
                    return 2;
                default:
                    return -1;
            }
        // Scissors
        case 2:
            switch(outcomeNeeded) {
                // Lose
                case 0:
                    // Return Paper
                    return 1;
                // Draw
                case 1:
                    // Return Scissors
                    return 2;
                // Win
                case 2:
                    // Return Rock
                    return 0;
                default:
                    return -1;
            }
        default:
            return -1;
            
    }
}

string getMoveString(char move) {
    switch(move) {
        case 'A':
            return "Rock";
        case 'X':
            return "Lose";
        case 'B':
            return "Paper";
        case 'Y':
            return "Draw";
        case 'C':
            return "Scissors";
        case 'Z':
            return "Win";
        default:
            return "Def";
    }
}

string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// Matrix of score the user gets with each move set, index [opponentMove][yourMove]
int [,] scoreMatrix = {{4,8,3}, {1,5,9}, {7,2,6}};

int score = 0;
foreach(string line in lines) {
    string[] moves = line.Split(' ');
    // Convert into chars eg 'X', 'A'
    char outcomeNeeded = char.Parse(moves[1]);
    char opponentMove = char.Parse(moves[0]);
    
    // Get each move char's index in the win matrix
    int outcomeNeededValue = getMoveValue(outcomeNeeded);
    int opponentMoveValue = getMoveValue(opponentMove);
    
    // Console.WriteLine($"Opp Move: {getMoveString(opponentMove)} Outcome Needed {getMoveString(outcomeNeeded)} Your Move {getMoveNeeded(opponentMoveValue, outcomeNeededValue)}");

    score += scoreMatrix[opponentMoveValue,getMoveNeeded(opponentMoveValue, outcomeNeededValue)];
}

Console.WriteLine(score);


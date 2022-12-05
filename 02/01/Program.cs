// See https://aka.ms/new-console-template for more information

// Returns index into the score matrix corresponding to a particular move
int getMoveValue(char move) {
    switch(move) {
        case 'A':
        case 'X':
            return 0;
        case 'B':
        case 'Y':
            return 1;
        case 'C':
        case 'Z':
            return 2;
        default:
            return 0;
    }
}

// Get the move associated with a particular character, used for debugging
string getMoveString(char move) {
    switch(move) {
        case 'A':
        case 'X':
            return "Rock";
        case 'B':
        case 'Y':
            return "Paper";
        case 'C':
        case 'Z':
            return "Scissors";
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
    char yourMove = char.Parse(moves[1]);
    char opponentMove = char.Parse(moves[0]);
    
    // Get each move char's index in the score matrix
    int yourMoveValue = getMoveValue(yourMove);
    int opponentMoveValue = getMoveValue(opponentMove);

    score += scoreMatrix[opponentMoveValue,yourMoveValue];
    // Console.WriteLine($"Opp Move: {getMoveString(opponentMove)} Your Move: {getMoveString(yourMove)} Index {opponentMoveValue} {yourMoveValue} = {scoreMatrix[opponentMoveValue, yourMoveValue]}");
}

Console.WriteLine(score);

namespace Checkmate_The_Final_Game.Chess_Mechanics{

using namespace emscripten;

using namespace Lizard.Logic.Core;

public class ComputerSettings:Game{

    int eloRating = 0;

    public static void getELO() => eloRating;

    public static void setELO(int eloRating){
        // Set the ELO rating for the engine
        this.eloRating = eloRating; // Example ELO rating
        Stockfish.SetOption("UCI_Elo", eloRating);
        // Set the engine to limit its strength to the specified ELO rating
        Stockfish.SetOption("UCI_LimitStrength", true);
    }

    public static void modifyELO(double x){
        eloRating *= x;
        Stockfish.SetOption("UCI_Elo", eloRating);
        // Set the engine to limit its strength to the specified ELO rating
        Stockfish.SetOption("UCI_LimitStrength", true);
    }

    public string GetBestMove(string forsythEdwardsNotationString){//found on github
        var p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "stockfishExecutable";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();  
        string setupString = "position fen "+forsythEdwardsNotationString;
        p.StandardInput.WriteLine(setupString);
    
        // Process for 5 seconds
        string processString = "go movetime 5000";
    
        // Process 20 deep
        // string processString = "go depth 20";

        p.StandardInput.WriteLine(processString);
    
        string bestMoveInAlgebraicNotation = p.StandardOutput.ReadLine();

        p.Close();

    return bestMoveInAlgebraicNotation;
}

}
}
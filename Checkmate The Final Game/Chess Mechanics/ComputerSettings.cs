namespace Checkmate_The_Final_Game.Chess_Mechanics{

using namespace emscripten;

using namespace Stockfish;

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
    
    public static void initialize_stockfish{
        Stockfish.InitializeStockfish();

        // SetOptions from benchmark.cpp ????????
        Stockfish.SetOption("UCI_ChessVariant", "CTFG");
        Stockfish.SetOption()
        Stockfish.SetOption("Threads", 1);
        Stockfish.SetOption("Hash", 128);
        Stockfish.SetOption("Ponder", true);
        Stockfish.SetOption("UCI_LimitStrength", true);
        Stockfish.SetOption("UCI_Elo", 1200);
        Stockfish.SetOption("UCI_Chess960", true);
        Stockfish.SetOption("UCI_ShowRefutations", false);
        Stockfish.SetOption("UCI_AnalyseMode", false);
        Stockfish.
        
        {
            
        }
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
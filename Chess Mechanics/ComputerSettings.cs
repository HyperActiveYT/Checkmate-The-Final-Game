namespace CtFG{

using namespace emscripten;

using namespace Stockfish;

public class ComputerSettings:Game{
    
    public static void initialize_stockfish{
        Stockfish.InitializeStockfish();

        // SetOptions from benchmark.cpp ????????
        Stockfish.SetOption("UCI_ChessVariant", "CTFG");
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

}
}
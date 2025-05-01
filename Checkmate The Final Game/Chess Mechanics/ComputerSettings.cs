namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using namespace emscripten;

using namespace Lizard.Logic.Core;

public class ComputerSettings:Game{

    private int eloRating = 0;
    private static string bestmove = ""; public static void getEngineMove() => bestmove;

    public static void getELO() => eloRating;

    public static void getEngineMove(){
        bestmove = await LizardUciHelper.GetBestMoveAsync(engineExe, Board.changeFEN(), Tournament.getBaseELOnum(), timeMs);
    }

    public static async Task<string> GetBestMoveAsync(
        string enginePath,
        string fen,
        int targetElo,
        int moveTimeMs)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName               = enginePath,
            RedirectStandardInput  = true,
            RedirectStandardOutput = true,
            UseShellExecute        = false,
            CreateNoWindow         = true
        };

        using var engine = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Could not start Lizard engine.");

        // Begin listening to engine output
        var outputReader = engine.StandardOutput;

        // 1) Tell engine to start a new game and load the FEN  
        engine.StandardInput.WriteLine("ucinewgame");
        engine.StandardInput.WriteLine($"position fen {fen}");

        // 2) Limit its strength and set target Elo  
        engine.StandardInput.WriteLine("setoption name UCI_LimitStrength value true");
        engine.StandardInput.WriteLine($"setoption name UCI_Elo value {targetElo}");

        // 3) Sync: wait for engine to be ready  
        engine.StandardInput.WriteLine("isready");
        await WaitForTokenAsync(outputReader, "readyok");

        // 4) Start search for the allotted movetime  
        engine.StandardInput.WriteLine($"go movetime {moveTimeMs}");

        // 5) Capture and return the bestmove token  
        var best = await WaitForBestMoveAsync(outputReader);

        // 6) Cleanly shut down the engine  
        engine.StandardInput.WriteLine("quit");
        return best;
    }

    private static async Task WaitForTokenAsync(StreamReader reader, string token)
    {
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (line.Trim() == token)
                return;
        }
        throw new InvalidOperationException($"Engine never returned '{token}'.");
    }

    private static async Task<string> WaitForBestMoveAsync(StreamReader reader)
    {
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (line.StartsWith("bestmove "))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                    return parts[1];
            }
        }
        throw new InvalidOperationException("Engine did not return a bestmove.");
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

var position = new Position
{
    Board = CreateBoardFromFEN(fen),
    WhiteToMove = DetermineSideToMoveFromFEN(fen)
};

bool inCheck = position.IsInCheck();

}
}
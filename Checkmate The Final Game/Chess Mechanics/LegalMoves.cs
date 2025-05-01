namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections.Generic;
using System.Linq;
using Lizard;
using Lizard.Search;

public static class LizardMoveGenerator{
    public static List<string> GetLegalMoves(string fen)
    {
        // 1) Create a Position from the FEN
        //    updateNN: true initializes neural‐net data; owner is just the calling thread
        var pos = new Position(fen, updateNN: true, owner: GlobalSearchPool.MainThread);
        
        // 2) Generate all pseudo‐legal moves into a MoveList
        var moves = new MoveList();
        MoveGenerator.GenerateMoves(pos, ref moves);
        
        // 3) Filter to only truly legal moves (king not left in check)
        var legal = moves.Where(m => pos.IsLegal(m));
        
        // 4) Convert each Move to its UCI string and return
        return legal
            .Select(m => m.ToUciString())  // or m.ToString() if that’s implemented as UCI
            .ToList();
    }
}
}
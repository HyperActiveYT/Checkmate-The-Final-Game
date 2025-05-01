namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections.Generic;
using System.Linq;
using Lizard;
using Lizard.Search;

public static class LizardMoveGenerator{
    public static List<string> GetLegalMoves(string fen)
    {
        var pos = new Position(fen, updateNN: true, owner: GlobalSearchPool.MainThread);
        
        var moves = new MoveList();
        MoveGenerator.GenerateMoves(pos, ref moves);
        
        var legal = moves.Where(m => pos.IsLegal(m));
        
        return legal
            .Select(m => m.ToUciString())
            .ToList();
    }
}
}
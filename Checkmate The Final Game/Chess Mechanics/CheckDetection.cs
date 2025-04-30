namespace Checkmate_The_Final_Game.Chess_Mechanics{

using System;
using System.Collections;
using System.Collections.Generic;

public class CheckDetection{
    public class Position
{
    public Piece[,] Board; // 8x8 board
    public bool WhiteToMove;

    public bool IsInCheck()
    {
        (int kingRow, int kingCol) = FindKing(WhiteToMove);

        foreach (var (row, col, piece) in GetOpponentPieces())
        {
            var attacks = GetAttackedSquares(row, col, piece);

            foreach (var (targetRow, targetCol) in attacks)
            {
                if (targetRow == kingRow && targetCol == kingCol)
                    return true;
            }
        }

        return false;
    }

    private (int, int) FindKing(bool white)
    {
        for (int row = 0; row < 8; row++)
            for (int col = 0; col < 8; col++)
                if (Board[row, col].IsKing && Board[row, col].IsWhite == white)
                    return (row, col);
        throw new Exception("King not found");
    }

    private IEnumerable<(int row, int col, Piece piece)> GetOpponentPieces()
    {
        bool enemyColor = !WhiteToMove;
        for (int row = 0; row < 8; row++)
            for (int col = 0; col < 8; col++)
            {
                var piece = Board[row, col];
                if (piece != null && piece.IsWhite == enemyColor)
                    yield return (row, col, piece);
            }
    }
    private List<(int, int)> GetAttackedSquares(int row, int col, Piece piece)
    {
            if (piece.Type == PieceType.Pawn)
    {
        int dir = piece.Color == Color.White ? -1 : 1;

        if (IsInsideBoard(row + dir, col - 1))
        attacked.Add((row + dir, col - 1));
        if (IsInsideBoard(row + dir, col + 1))
        attacked.Add((row + dir, col + 1));
    } 
else if (piece.Type == PieceType.Knight)
    {
        int[] knightMoves = { -2, -1, 1, 2 };
        foreach (var dy in knightMoves)
        {
            if (Math.Abs(dx) != Math.Abs(dy) && IsInsideBoard(row + dx, col + dy))
                attacked.Add((row + dx, col + dy));
        }
    }
else if (piece.Type == PieceType.Bishop)
    {
        int[] directions = { -1, 1 };
        foreach (var dx in directions)

        {
            foreach (var dy in directions)
            {
                if (Math.Abs(dx) != Math.Abs(dy))
                {
                    int r = row + dx, c = col + dy;
                    while (IsInsideBoard(r, c))
                    {
                        attacked.Add((r, c));
                        if (Board[r, c] != null) break;
                        r += dx; c += dy;
                    }
                }
            }
        }
    }   
else if (piece.Type == PieceType.Rook)              
    {               
        int[] directions = { -1, 1 };   

        foreach (var dx in directions)
        {
            foreach (var dy in directions)
            {
                if (Math.Abs(dx) != Math.Abs(dy))
                {
                    int r = row + dx, c = col + dy;
                    while (IsInsideBoard(r, c))
                    {
                        attacked.Add((r, c));
                        if (Board[r, c] != null) break;
                        r += dx; c += dy;
                    }
                }
            }
        }
    }   

else if (piece.Type == PieceType.Queen)
    {   
        int[] directions = { -1, 1 };
        foreach (var dx in directions)
        {
            foreach (var dy in directions)
            {
                if (Math.Abs(dx) != Math.Abs(dy))
                {
                    int r = row + dx, c = col + dy;
                    while (IsInsideBoard(r, c))
                    {
                        attacked.Add((r, c));
                        if (Board[r, c] != null) break;
                        r += dx; c += dy;
                    }
                }
            }
        }   
    }
else if (piece.Type == PieceType.King)
    {   
        int[] kingMoves = { -1, 0, 1 };

        foreach (var dx in kingMoves)
        {
            foreach (var dy in kingMoves)
            {
                if (Math.Abs(dx) != Math.Abs(dy) && IsInsideBoard(row + dx, col + dy))
                    attacked.Add((row + dx, col + dy));
            }
        }
    }       

        return piece.GetMoves(row, col, Board, attackOnly: true);
    }
}
}
}
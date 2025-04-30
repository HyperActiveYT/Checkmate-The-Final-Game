namespace Checkmate_The_Final_Game.Chess_Mechanics{

using System;
using System.Collections;
using System.Collections.Generic;

public class PointScore
{

    public enum CheckType
    {
        None,
        DirectCheckQueen,
        DirectCheckRook,
        DirectCheckBishop,
        DirectCheckKnight,
        DirectCheckPawn,
        CaptureCheckQueen,
        CaptureCheckRook,
        CaptureCheckBishop,
        CaptureCheckKnight,
        CaptureCheckPawn,
        DiscoveredCheck,
        DoubleCheck,
        PromotionCheck,
        UnderpromotionCheck,
        EnPassantDiscoveredCheck,
        UnpinRevealedCheck,/*Same as Cross Check*/
        DoublyDisambiguatedBishopCaptureMate
    }

public static List<CheckType> Analyze(Position position, Move lastMove)
    {
        var checkTypes = new List<CheckType>();
        bool isInCheck = position.IsInCheck();

        if (!isInCheck)
            return checkTypes;

        var attackers = GetAttackersToKing(position, position.WhiteToMove);
        if (attackers.Count == 0) return checkTypes;

        if (attackers.Count == 1)
        {
            var attacker = attackers[0];
            var piece = attacker.piece;
            bool isCapture = position.Board[lastMove.ToRow, lastMove.ToCol] != null;

            if (piece.Type == PieceType.Queen)
                checkTypes.Add(isCapture ? CheckType.CaptureCheckQueen : CheckType.DirectCheckQueen);
            else if (piece.Type == PieceType.Rook)
                checkTypes.Add(isCapture ? CheckType.CaptureCheckRook : CheckType.DirectCheckRook);
            else if (piece.Type == PieceType.Bishop)
                checkTypes.Add(isCapture ? CheckType.CaptureCheckBishop : CheckType.DirectCheckBishop);
            else if (piece.Type == PieceType.Knight)
                checkTypes.Add(isCapture ? CheckType.CaptureCheckKnight : CheckType.DirectCheckKnight);
            else if (piece.Type == PieceType.Pawn)
                checkTypes.Add(isCapture ? CheckType.CaptureCheckPawn : CheckType.DirectCheckPawn);
        }

        if (attackers.Count > 1)
        {
            checkTypes.Add(CheckType.DoubleCheck);
        }

        if (IsDiscoveredCheck(position, lastMove))
        {
            checkTypes.Add(CheckType.DiscoveredCheck);
        }

        if (lastMove.IsPromotion)
        {
            if (lastMove.PromotionType == PieceType.Queen)
                checkTypes.Add(CheckType.PromotionCheck);
            else
                checkTypes.Add(CheckType.UnderpromotionCheck);
        }

        if (lastMove.IsEnPassant && IsDiscoveredCheck(position, lastMove))
        {
            checkTypes.Add(CheckType.EnPassantDiscoveredCheck);
        }

        if (UnpinnedPieceNowGivesCheck(position, lastMove))
        {
            checkTypes.Add(CheckType.UnpinRevealedCheck);
        }

        if (IsDoublyDisambiguatedBishopCheckmate(position, lastMove))
        {
            checkTypes.Add(CheckType.DoublyDisambiguatedBishopCaptureMate);
        }

        return checkTypes;
    }

    private static List<(int row, int col, Piece piece)> GetAttackersToKing(Position position, bool whiteToMove) { return new(); }
    private static bool IsDiscoveredCheck(Position position, Move lastMove) { return false; }
    private static bool UnpinnedPieceNowGivesCheck(Position position, Move lastMove) { return false; }
    private static bool IsDoublyDisambiguatedBishopCheckmate(Position position, Move lastMove) { return false; }

    public int PointScore(bool isDiscoveredCheck, bool isDoubleCheck, bool isPromotionCheck, bool isEnPassantDiscoveredCheck)
{
    int points = 0;

    if (isEnPassantDiscoveredCheck)
        points += 6;
    if (isDoubleCheck)
        points += 5;
    if (isPromotionCheck)
        points += 4;
    if (isDiscoveredCheck)
        points += 3;
    if (points == 0)
        points = 1;

    return points;
}
}

public class CheckTypeEvaluator
{
    private Dictionary<CheckType, int> checkScores = new Dictionary<CheckType, int>
    {
        { CheckType.DirectQueen, 5 },
        { CheckType.DirectRook, 6 },
        { CheckType.DirectBishop, 7 },
        { CheckType.DirectKnight, 8 },
        { CheckType.DirectPawn, 10 },
        { CheckType.CaptureQueen, 7 },
        { CheckType.CaptureRook, 8 },
        { CheckType.CaptureBishop, 9 },
        { CheckType.CaptureKnight, 10 },
        { CheckType.CapturePawn, 12 },
        { CheckType.Discovered, 12 },
        { CheckType.DoubleCheck, 15 },
        { CheckType.PromotionCheck, 13 },
        { CheckType.UnderpromotionCheck, 14 },
        { CheckType.EnPassantDiscovered, 16 },
        { CheckType.UnpinCheck, 17 },
        { CheckType.DoublyDisambiguatedBishopCaptureMate, 20 }
    };

    public int GetCheckScore(CheckType checkType)
    {
        return checkScores.TryGetValue(checkType, out int score) ? score : 0;
    }
    public static string DetectCheckType(int[] from, int[] to, Pieces movedPiece, Pieces[][] boardBeforeMove)
{
    bool causesCheck = false;
    bool isDiscovered = false;
    bool isDouble = false;
    bool isPromotion = false;
    bool isEnPassantDiscovered = false;

    // Simulate move
    Pieces[][] simulatedBoard = CloneBoard(boardBeforeMove);
    simulatedBoard[to[0]][to[1]] = movedPiece;
    simulatedBoard[from[0]][from[1]] = null;

    // 1. Find the enemy king
    int[] enemyKingPos = FindKingPosition(-movedPiece.getColor(), simulatedBoard);

    // 2. Check all allied pieces for check (including moved one)
    List<Pieces> attackers = FindAttackers(simulatedBoard, enemyKingPos, movedPiece.getColor());

    causesCheck = attackers.Count > 0;

    if (!causesCheck) return "none";

    if (attackers.Count > 1) isDouble = true;

    // Check if *this* piece is causing the check
    bool movedPieceIsChecking = IsAttacking(movedPiece, to, enemyKingPos, simulatedBoard);

    if (!movedPieceIsChecking && attackers.Count >= 1)
        isDiscovered = true;

    // Promotion check (only if piece is a promoted pawn and gave check)
    if (movedPiece is Queen && (from[0] == 1 || from[0] == 6) && Math.Abs(to[0] - from[0]) == 1)
        isPromotion = true;

    // En passant discovered check (optional: refine based on your move logic)
    if (movedPiece is Pawn && Math.Abs(from[1] - to[1]) == 1 && boardBeforeMove[to[0]][to[1]] == null)
        isEnPassantDiscovered = true;

    // Now, choose result based on priority
    if (isEnPassantDiscovered) return "en_passant_discovered";
    if (isDouble) return "double";
    if (isPromotion) return "promotion";
    if (isDiscovered) return "discovered";
    return "simple";
}

private static Pieces[][] CloneBoard(Pieces[][] board)
{
    Pieces[][] clone = new Pieces[8][];
    for (int i = 0; i < 8; i++)
    {
        clone[i] = new Pieces[8];
        for (int j = 0; j < 8; j++)
        {
            clone[i][j] = board[i][j]; // Shallow copy — fine if Pieces are immutable
        }
    }
    return clone;
}

private static int[] FindKingPosition(int color, Pieces[][] board)
{
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (board[i][j] != null && board[i][j] is King && board[i][j].getColor() == color)
                return new int[] { i, j };
        }
    }
    return null;
}

private static List<Pieces> FindAttackers(Pieces[][] board, int[] kingPos, int attackingColor)
{
    var attackers = new List<Pieces>();
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            Pieces p = board[i][j];
            if (p != null && p.getColor() == attackingColor && IsAttacking(p, new int[] { i, j }, kingPos, board))
                attackers.Add(p);
        }
    }
    return attackers;
}

private static bool IsAttacking(Pieces piece, int[] from, int[] target, Pieces[][] board)
{
    // You must implement piece-specific movement logic here.
    // This is just a placeholder.
    return piece.canMove(from, target, board); // If your Pieces have a canMove method
}

string checkType = DetectCheckType(from, to, movingPiece, CloneBoard(board));

}

public static void Main()
    {
        var evaluator = new CheckTypeEvaluator();

        foreach (var checkType in checkTypesToTest)
        {
            int score = evaluator.GetCheckScore(checkType);
            Console.WriteLine($"Check Type: {checkType} => Score: {score}");
        }
    }

}
}
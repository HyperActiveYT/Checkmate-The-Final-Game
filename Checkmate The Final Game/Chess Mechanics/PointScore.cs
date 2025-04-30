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
        UnpinRevealedCheck,
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

    // analyze the position and return a CheckType
    public CheckType IdentifyCheckType(Position position, Move move)
    {
        // implement specific detection here
        return CheckType.None;
    }
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
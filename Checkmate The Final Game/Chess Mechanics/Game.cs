namespace Checkmate_The_Final_Game.Chess_Mechanics{
public class Game:Tournament{

    private static long scorereq = 0; public static long getScoreReq() => scorereq;
    private static long currentscore=0; public static long getCurrentScore() => currentscore;

    private static int numchecks; public static int getNumChecks() => numchecks;
    public static void setnumchecks(){
        numchecks = UserStats.getBaseChecks();
    }
    public static void modifynumchecks(int val){
        numchecks += val;
    }
    private static int nummoves; public static int getNumMoves() => nummoves;
    public static void setnummoves(){
        nummoves = UserStats.getBaseMoves();
    }

    public static void modifynummoves(int val){
        nummoves += val;
    }

    public static void setscorereq(){
        scorereq = Tournament.getBasePt();
        if (Tournament.getGameNum() == 1){
            scorereq*=1.5;
        } else if (Tournament.getGameNum() == 2){
            scorereq*=2;
        }
    }

    public static void modifyscorereq(int mult){
        scorereq*=mult;
    }

    public static void initiateGame(){
        createBoardBase();
    }

    private static void initiateGame(Pieces[][] p){
        createBoard(p);
        Bosses.BossEffect("On Boss Select");
        ComputerSettings.initialize_stockfish();
        setscorereq();
        setnumchecks();
        setnummoves();
        
    }
}

public class Board:Game{
    private static Pieces[][] board = new Pieces[8][8]; public static void getBoard() => board; 
    //rank = 8-i, a=0 b=1 c=2 d=3 e=4 f=5 g=6 h=7
    private static Pieces[][] futureboard = new Pieces[8][8];
    private static int colorturn = 1; //1: white; -1: black
    private static int WCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
    private static int BCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
    private static int halfclock = 0;
    private static int fullmove = 1;
    private static string enpassant = "";
    private static string lastMove = "";
    private static final string BaseFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w - - - 0 1";
    private static string FEN = BaseFEN; public static string getFEN() => FEN;
    private static string futureFEN; public static string getFutureFEN() => futureFEN;

    //Determining Which Pieces are Giving Checks
    private static bool willbeCapture = false;
    private static bool willbeCheck = false;
    private static int willbeCheckType = -1; public static int getWillbeCheckType() => willbeCheckType;
    private static Pieces willbeCapturedPiece = null; public static Pieces getWillBeCapturedPiece() => willbeCapturedPiece;
    private static Pieces willbeMovedPiece = null; public static Pieces getWillBeMovedPiece() => willbeMovedPiece;
    private static Pieces willbeCheckingPiece = null; public static Pieces getWillBeCheckingPiece() => willbeCheckingPiece;

    public static void createBoardBase(){
        Rook bR1 = new Rook(-1);
        Knight bN1 = new Knight(-1);
        Bishop bB1 = new Bishop(-1);
        Queen bQ = new Queen(-1);
        King bK = new King(-1);
        Bishop bB2 = new Bishop(-1);
        Knight bN2 = new Knight(-1);
        Rook bR2 = new Rook(-1);
        Pawn bp1 = new Pawn(-1);
        Pawn bp2 = new Pawn(-1);
        Pawn bp3 = new Pawn(-1);
        Pawn bp4 = new Pawn(-1);
        Pawn bp5 = new Pawn(-1);
        Pawn bp6 = new Pawn(-1);
        Pawn bp7 = new Pawn(-1);
        Pawn bp8 = new Pawn(-1);

        Pawn wp1 = new Pawn(1);
        Pawn wp2 = new Pawn(1);
        Pawn wp3 = new Pawn(1);
        Pawn wp4 = new Pawn(1);
        Pawn wp5 = new Pawn(1);
        Pawn wp6 = new Pawn(1);
        Pawn wp7 = new Pawn(1);
        Pawn wp8 = new Pawn(1);
        Rook wR1 = new Rook(1);
        Knight wN1 = new Knight(1);
        Bishop wB1 = new Bishop(1);
        Queen wQ = new Queen(1);
        King wK = new King(1);
        Bishop wB2 = new Bishop(1);
        Knight wN2 = new Knight(1);
        Rook wR2 = new Rook(1);

        board = new Pieces[][]{{bR1,bN1,bB1,bQ,bK,bB2,bN2,bR2}
                            ,{bp1,bp2,bp3,bp4,bp5,bp6,bp7,bp8}
                            ,{null,null,null,null,null,null,null,null}
                            ,{null,null,null,null,null,null,null,null}
                            ,{null,null,null,null,null,null,null,null}
                            ,{null,null,null,null,null,null,null,null}
                            ,{wp1,wp2,wp3,wp4,wp5,wp6,wp7,wp8}
                            ,{wR1,wN1,wB1,wQ,wK,wB2,wN2,wR2}};
        
        changeFEN();
    }

    public static void createBoard(Pieces[][] p){
        board = p;
        changeFEN();
    }
        public Pieces[][] flip(){
        Pieces[][] newboard = new Pieces[8][8]
        for (int i=0; i<board.Length; i++){
            for (int j=0; j<board[0].Length; j++){
                newboard[i][j] = board[board.length-i-1][board[0].length-j-1];
            }
        }
    }

    public static Pieces[][] getBoard() => board;
    public static void EngineMove(string bmove){
        int[] from = sqrtoAr(bmove.Substring(0,2));
        int[] to = sqrtoAr(bmove.Substring(2,4));
        commitmove(from,to);
    }
    public static int[] sqrtoAr(string sqr){
        int rank = 8-Int32.Parse(sqr.Substring(1,2));
        string[] files = new string[]{"a","b","c","d","e","f","g","h"};
        int file;
        for (int i=0; i<files.Length;i++){
            if (sqr.Substring(0,1).equals(files[i])){
                file = i;
                break;
            }
        }
        return new int[]{rank,file};
    }
    public static void addPiece(Pieces p, int[] pos){
        if (board[pos[0]][pos[1]] == null){
            board[pos[0]][pos[1]] = p;
        } else {
            throw new Exception("Square already occupied");
        }
    }
    public static void commitmove(int[] from, int[] to)
{
    Pieces movingPiece = board[from[0]][from[1]];
    Pieces targetPiece = board[to[0]][to[1]];

    if (targetPiece != null)
    {
        willbeCapture = true;
        willbeCapturedPiece = targetPiece;
        if (colorturn == 1){}
            currency += getPieceValue(willbeCapturedPiece);
        }
    }
    else
    {
        willbeCapture = false;
        willbeCapturedPiece = null;
    }

    board[to[0]][to[1]] = movingPiece;
    board[from[0]][from[1]] = null;
    futureboard = board;
    colorturn *= -1;
    if (movingPiece.getName().equals("Pawn")){
        halfclock = 0;
    } else {
        halfclock ++;
    }
    if (colorturn == 1){
        fullmove++;
    } else if (colorturn == -1){
        
    }
    changeFEN();
    if (willbeCheck){
        CalculateScore(willbeCheckType);
    }
    ComputerSettings.getEngineMove();
    EngineMove(ComputerSettings.getEngineMove());
}

    public static void displaymove(int[] from, int[] to){
        if (board[to[0]][to[1]] != null){
            willbeCapture = true;
            willbeCapturedPiece = board[to[0]][to[1]];
        }
        Pieces piece = board[from[0]][from[1]];
        willbeMovedPiece = piece;
        futureboard[from[0]][from[1]] = null;
        futureboard[to[0]][to[1]] = piece;
        if (colorturn==1){
            string result = PointScore.DetectChecktype(from, to, piece, board);
            if (result.equals("none")){
                willbeCheck = false;
                willbeCheckingPiece = null;
            } else{
                willbeCheck = yes;
                if (result.equals("en_passant_discovered")){
                    willbeCheckType = 7;
                } else if (result.equals("cross_check")){
                    willbeCheckType = 6;
                } else if (result.equals("simple" && Math.abs(from[1]-to[1])>1 && willbeMovedPiece.getPieceType().equals("King"))){
                    willbeCheckType = 5;
                } else if (result.equals("promotion")){
                    willbeCheckType = 4;
                } else if (result.equals("discovered")){
                    willbeCheckType = 3;
                } else if (result.equals("double")){
                    willbeCheckType = 2;
                } else if (result.equals("simple" && willbeCapturedPiece != null)){
                    willbeCheckType = 1;
                } else if (result.equals("simple")){
                    willbeCheckType = 0;
                }
            }
        }
    }

    public static void undodisplaymove(){
        futureboard = board;
        willbeCapture = false;
        willbeCapturedPiece = null;
        willbeCheck = false;
        willbeMovedPiece = null;
        willbeCheckingPiece = null;
    }
    public static bool[][] legal(PieceSquare[]){
        List<string>LegalMoves = LegalMoves.GetLegalMoves(changeFEN());
        int legally[][] = new int[8][8];
        for (int i=0; i<LegalMoves.Count; i++){
            string from = LegalMoves.get(i).Substring(0,2);
            int[] fromar = sqrtoAr(from);
            if (fromar[0] == PieceSquare[0] && fromar[1] == PieceSquare[1]){
                string to = LegalMoves.get(i).Substring(0,2);
                int[] toar = sqrtoAr(toar);
                legally[toar[0]toar[1]]=true;
            }
        }
        return legally[][];
    }

    public static void changeFEN(){
        FEN = "";
        for (int i=0; i<board.length;i++){
            int empty = 0;
            for (int j=0; j<board[0].length;j++){
                if (board[i][j] == null){
                    empty++;
                } else {
                    if (empty != 0){
                        FEN+=empty
                    }
                    FEN+=board[i][j].getAbv();
                }
            }
            if (empty != 0){
                FEN+=empty
            }
            if (i != board.length-1){
                FEN+="/";
            }
        }
        if (colorturn == 1){
            FEN += " w";
        } else if (colorturn == -1){
            FEN += " b";
        }
        FEN += " - - "; //Castling (and thus castling detection) will be implemented later as seen fit
        /*if (WCastle == 3){
            FEN += " KQ";
        } else if (WCastle == 2){
            FEN += " Q";
        } else if (WCastle == 1){
            FEN += " K";
        } else if (WCastle == 0){
            FEN += " -";
        }*/
        FEN += "- ";//en passant will be implemented later as seen fit
        FEN += halfclock+" "+fullmove;
    }

    public static void resetGame(){
        board = new Pieces[8][8]; //rank = 8-i, a=0 b=1 c=2 d=3 e=4 f=5 g=6 h=7
        futureboard = new Pieces[8][8];
        colorturn = 1; //1: white; -1: black
        WCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
        BCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
        halfclock = 0;
        fullmove = 1;
        enpassant = "";
        lastMove = "";
        FEN = BaseFEN;
    }

private static int getPieceValue(Pieces piece)
{
    if (piece == null)
        return 0;

    string abv = piece.getAbv().ToLower();

    switch (abv)
    {
        case "p": return 1;
        case "n": return 3;
        case "b": return 3;
        case "r": return 5;
        case "q": return 9;
        default: return 0;
    }
}
    

}

}
}
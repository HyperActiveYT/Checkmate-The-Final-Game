namespace Checkmate_The_Final_Game.Chess_Mechanics{
public class Game:Tournament{

    public static void initiateGame(){
        createBoardBase();
    }

    private static void initiateGame(Pieces[][] p){
        createBoard(p);
        Bosses.BossEffect("Boss Select");
        ComputerSettings.initialize_stockfish();
    }

    public void move(){
        P/invoke StateMachine::ponder();
    }


}

public class Board:Game{
    private static PiecesBetza[][] board = new Pieces[8][8]; //rank = 8-i, a=0 b=1 c=2 d=3 e=4 f=5 g=6 h=7
    private static PiecesBetza[][] futureboard = new Pieces[8][8];
    private static int colorturn = 1; //1: white; -1: black
    private static int WCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
    private static int BCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
    private static int halfclock = 0;
    private static int fullmove = 1;
    private static string enpassant = "";
    private static string lastMove = "";
    private static final string BaseFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
    private static string FEN = BaseFEN;

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

    public static string getFEN() => FEN;

        public Pieces[][] flip(){
        Pieces[][] newboard = new Pieces[8][8]
        for (int i=0; i<board.Length; i++){
            for (int j=0; j<board[0].Length; j++){
                newboard[i][j] = board[board.length-i-1][board[0].length-j-1];
            }
        }
    }

    public static PiecesBetza[][] getBoard() => board;

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

    public static void move(int[] from, int[] to){
        Pieces piece = board[from[0]][from[1]];
        board[from[0]][from[1]] = null;
        board[to[0]][to[1]] = piece;
        futureboard = board;
        if (piece.)
        
    }

    public static void addPiece(PiecesBetza p, int[] pos){
        if (board[pos[0]][pos[1]] == null){
            board[pos[0]][pos[1]] = p;
        } else {
            throw new Exception("Square already occupied");
        }
    }

    public static void displaymove(int[] from, int[] to){
        Pieces piece = board[from[0]][from[1]];
        futureboard[from[0]][from[1]] = null;
        futureboard[to[0]][to[1]] = piece;
        detectChecktype();
    }

    public static void undodisplaymove(){
        futureboard = board;
    }

    public static void detectChecktype(){
        
    }

    public static boolean legal(){
        
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
        Pieces[][] board = new Pieces[8][8]; //rank = 8-i, a=0 b=1 c=2 d=3 e=4 f=5 g=6 h=7
        Pieces[][] futureboard = new Pieces[8][8];
        colorturn = 1; //1: white; -1: black
        WCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
        BCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
        halfclock = 0;
        fullmove = 1;
        enpassant = "";
        lastMove = "";
        FEN = BaseFEN;
    }

    

}

}
namespace CtFG{
public class Board:Game{
    private Pieces[][] board = new Pieces[8][8]; //rank = 8-i, a=0 b=1 c=2 d=3 e=4 f=5 g=6 h=7
    private Pieces[][] prevboard = new Pieces[8][8];
    private int colorturn = 1; //1: white; -1: black
    private int WCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
    private int BCastle; //0: neither; 1: kingside only; 2: queenside only; 3: both
    private int halfclock = 0;
    private int fullmove = 1;
    private string enpassant = "";
    private string lastMove = "";

    private string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
    
    public Board(){ //base game
        Rook bR1 = new Rook(2, null);
        Knight bN1 = new Knight(2, null);
        Bishop bB1 = new Bishop(2, null);
        Queen bQ = new Queen(2, null);
        King bK = new King(2, null);
        Bishop bB2 = new Bishop(2, null);
        Knight bN2 = new Knight(2, null);
        Rook bR2 = new Rook(2, null);
        Pawn bp1 = new Pawn(2, null);
        Pawn bp2 = new Pawn(2, null);
        Pawn bp3 = new Pawn(2, null);
        Pawn bp4 = new Pawn(2, null);
        Pawn bp5 = new Pawn(2, null);
        Pawn bp6 = new Pawn(2, null);
        Pawn bp7 = new Pawn(2, null);
        Pawn bp8 = new Pawn(2, null);

        Pawn wp1 = new Pawn(1, null);
        Pawn wp2 = new Pawn(1, null);
        Pawn wp3 = new Pawn(1, null);
        Pawn wp4 = new Pawn(1, null);
        Pawn wp5 = new Pawn(1, null);
        Pawn wp6 = new Pawn(1, null);
        Pawn wp7 = new Pawn(1, null);
        Pawn wp8 = new Pawn(1, null);
        Rook wR1 = new Rook(2, null);
        Knight wN1 = new Knight(1, null);
        Bishop wB1 = new Bishop(1, null);
        Queen wQ = new Queen(1, null);
        King wK = new King(1, null);
        Bishop wB2 = new Bishop(1, null);
        Knight wN2 = new Knight(1, null);
        Rook wR2 = new Rook(1, null);
        board = new Pieces[]{{bR1,bN1,bB1,bQ,bK,bB2,bN2,bR2}
                            ,{bp1,bp2,bp3,bp4,bp5,bp6,bp7,bp8}
                            ,{null,null,null,null,null,null,null,null}
                            ,{null,null,null,null,null,null,null,null}
                            ,{null,null,null,null,null,null,null,null}
                            ,{null,null,null,null,null,null,null,null}
                            ,{wp1,wp2,wp3,wp4,wp5,wp6,wp7,wp8}
                            ,{wR1,wN1,wB1,wQ,wK,wB2,wN2,wR2}};
    }

    public Board(Pieces[][] p){
        board = p;
        changeFEN();
    }

    public string getFEN(){
        return FEN;
    }

    public Pieces[][] flip(){
        Pieces[][] newboard = new Pieces[8][8]
        for (int i=0; i<board.Length; i++){
            for (int j=0; j<board[0].Length; j++){
                newboard[i][j] = board[board.length-i-1][board[0].length-j-1];
            }
        }
    }

    public Pieces[][] getBoard() => board;

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

    public void move(Piece p, int[] from; int[] to){
        
    }

    public void changeFEN(){
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
        if (colorturnturn == 1){
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

    

}
}
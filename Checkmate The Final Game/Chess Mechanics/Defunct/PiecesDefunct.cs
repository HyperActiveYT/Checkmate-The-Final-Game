/*public class Pieces{
    private int[][] moves;
    private int[] center;
    private string name;
    private string abv;
    private double[] ptscore; //0: +pts; 1: xpts; 2: +mult; 3: xmult
    private int color; //1=white, 2=black

    private boolean canCastle = false;

    public Pieces(int[][] moves, string name, int abv, int color, double[] ptscore){
        if (moves.Length % 2 == 1 && moves[0].Length % 2 == 1){ //oddxodd up to 15x15 to account for all possible moves from anywhere
            this.moves = moves;//0 = cannot move to/attack, 1 = can both move to/attack, 2 = can attack but not move to, 3 = can move to but not attack
        } else {
            WriteLine("You cannot create this piece. Please ensure the piece move dimensions are accurate");
            break;
        }
        center = findCenter();
        if (moves[center[0]][center[1]] != 0){
            WriteLine("You cannot create this piece. Please ensure the piece moves are accurate");
            break;
        }
        this.name = name;
        this.color = color;
        this.abv = abv;
        if (color==1){
            abv = abv.toUpper();
        }
        this.ptscore = ptscore;
    }

    public String ToString() => name;

    public int[] findCenter(){
        return new int[]{moves.Length/2,moves[0].Length/2};
    }

    public int[][] getMoves() => moves;

    public string getname() => name;

    public string getAbv() => abv;

    public int getcolor() => color;

    public static int[][] movecombine(Pieces p1, Pieces p2){
        movecombine(p1.getMoves(), p2.getMoves());
    }

    public static int[][] moveresize(int size){
        if (size%2 != 1 || size<moves.length){
            return null;
        }
        int[][] resize = new int[size][size];
        for (int i=0; i<moves.length; i++){
            for (int j=0; j<moves.length; j++){
                resize[i+findCenter[0]-moves.length/2][j+findCenter[1]-moves[0].length/2] = moves[i][j];
            }
        }
        return resize;
    }

    public int[][] movecombine(int[][] p1, int[][] p2){
        int[][] newmoves = new int[moves.Length][moves[0].Length];
        if (p1.Length>p2.Length){
            p2=p2.moveresize(p1.Length);
        } else if (p2.Length<p1.Length){
            p1=p1.moveresize(p2.Length);
        }
        for (int i=0; i < moves.Length;i++){
            for (int j=0; j<moves[0].Length; j++){
                if (p1[i][j] == 1 || p2[i][j] == 1 || (p1[i][j]+p2[i][j] == 5)){
                    newmoves[i][j] == 1;
                } else if (p1[i][j] + p2[i][j] == 2){
                    newmoves[i][j] = 2;
                } else if (p1[i][j] + p2[i][j] == 3){
                    newmoves[i][j] = 3;
                }
            }
        }
        return newmoves;
    }

    public static void Main(string args[]){
        Knight k1 = new Knight(2,null);
        WriteLine(k1);
    }

}

class Knight : Pieces{
    public Knight(int color, double ptscore){
        : base.({{0,1,0,1,0},{1,0,0,0,1},{0,0,0,0,0,},{1,0,0,0,1},{0,1,0,1,0}}, "Knight", "n", color, ptscore);
    }
}

class Bishop : Pieces{
    public Bishop(int color, double[] ptscore){
        : base.({{1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},{0,1,0,0,0,0,0,0,0,0,0,0,0,1,0},{0,0,1,0,0,0,0,0,0,0,0,0,1,0,0}
        ,{0,0,0,1,0,0,0,0,0,0,0,1,0,0,0},{0,0,0,0,1,0,0,0,0,0,1,0,0,0,0},{0,0,0,0,0,1,0,0,0,1,0,0,0,0,0}
        ,{0,0,0,0,0,0,1,0,1,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,1,0,1,0,0,0,0,0,0}
        ,{0,0,0,0,0,1,0,0,0,1,0,0,0,0,0},{0,0,0,0,1,0,0,0,0,0,1,0,0,0,0},{0,0,0,1,0,0,0,0,0,0,0,1,0,0,0}
        ,{0,0,1,0,0,0,0,0,0,0,0,0,1,0,0},{0,1,0,0,0,0,0,0,0,0,0,0,0,1,0},{1,0,0,0,0,0,0,0,0,0,0,0,0,0,1}}
        , "Bishop", "b", color, ptscore)
    }
}

class Pawn : Pieces{
    public Pawn(int color, double[] ptscore){
        : base.({{2,3,2},{0,0,0},{0,0,0}}, "Pawn", "p", color, ptscore);
    }
}

class King : Pieces{
    public King(int color, double[] ptscore){
        : base.({1,1,1},{1,0,1},{1,1,1}, "King", "k", color, ptscore);
    }
}

class Rook : Pieces{
    public Rook(int color, double[] ptscore){
        : base.({{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0}
        ,{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0}
        ,{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{1,1,1,1,1,1,1,0,1,1,1,1,1,1,1},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0}
        ,{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0}
        ,{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,1,0,0,0,0,0,0,0}}
        , "Rook", "r", color, ptscore)
    }
}

class Queen : Pieces{
    public Queen(int color, double[] ptscore){
        : base.(movecombine(new Bishop(), new Rook()),"Queen", "q", color, ptscore);
    }
}
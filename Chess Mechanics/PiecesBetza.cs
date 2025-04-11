namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;

public class PiecesBetza:Board{
    private string name;
    private string moves;
    private string abv;
    private string color;//1=white, 2=black
    private int[][] ptscore = new int[3][4]; 
    //first; 0: base(+bonus); 1: edition; 2: enhancement
    //second; 0: +pts; 1: xpts; 2: +mult; 3: xmult

    private List<PiecesBetza> pieces = new List<PiecesBetza>();

    public PiecesBetza(string name, string moves, string abv, color, ptscore){
        this.name = name;
        this.moves = moves;
        this.abv = abv;
        this.color = color;
        this.ptscore = ptscore;
    }
}

public class Pawn:PiecesBetza{
    public Pawn(string color, int[][] ptscore){
        base.("Pawn","fmWfceFifmnD", "P", color, ptscore)
    }
    public Pawn(string color){
        Pawn(color, new int[][]{{1,0,0,0},{0,0,0,0},{0,0,0,0}});
    }
}

public class Knight:PiecesBetza{
    public Knight(string color, int[][] ptscore){
        base.("Knight","N", "N", color, ptscore);
    }
    public Knight(string color){
        Knight(color, new int[][]{{3,0,0,0},{0,0,0,0},{0,0,0,0}});
    }
}

public class Bishop:PiecesBetza{
    public Bishop(string color, int[][] ptscore){
        base.("Bishop","B", "B", color, ptscore);
    }
    public Bishop(string color){
        Bishop(color, new int[][]{{3,0,0,0},{0,0,0,0},{0,0,0,0}});
    }
}

public class Rook:PiecesBetza{
    public Rook(string color, int[][] ptscore){
        base.("Rook","R", "R", color, ptscore);
    }
    public Rook(string color){
        Rook(color, new int[][]{{5,0,0,0},{0,0,0,0},{0,0,0,0}});
    }
}

public class Queen:PiecesBetza{
    public Queen(string color, int[][] ptscore){
        base.("Queen","Q", "Q", color, ptscore);
    }
    public Queen(string color){
        Queen(color, new int[][]{{9,0,0,0},{0,0,0,0},{0,0,0,0}});
    }
}

public class King:PiecesBetza{
    public King(string color, int[][] ptscore){
        base.("King","K", "K", color, ptscore);
    }
    public King(string color){
        King(color, new int[][]{{0,0,0,0},{0,0,0,0},{0,0,0,0}});
    }
}
}


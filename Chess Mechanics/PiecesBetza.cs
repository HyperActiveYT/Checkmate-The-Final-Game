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
        base.("Pawn","(fW~fmW) (fifmnD) (!1fmW2) ([1]fW=QNRB)", "P", color, ptscore)
    }
}

public class Knight:PiecesBetza{
    public Knight(string color, int[][] ptscore){
        base.("Knight","N", "N", color, ptscore);
    }
}

public class Bishop:PiecesBetza{
    public Bishop(string color, int[][] ptscore){
        base.("Bishop","B", "B", color, ptscore);
    }
}

public class Rook:PiecesBetza{
    public Rook(string color, int[][] ptscore){
        base.("Rook","R", "R", color, ptscore);
    }
}

public class Queen:PiecesBetza{
    public Queen(string color, int[][] ptscore){
        base.("Queen","Q", "Q", color, ptscore);
    }
}

public class King:PiecesBetza{
    public King(string color, int[][] ptscore){
        base.("King","K", "K", color, ptscore);
    }
}
}


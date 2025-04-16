namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;

public class PiecesBetza:Board{
    private string name;
    private string moves;
    private string abv;
    private string color;//1=white, 2=black
    private double[] ptscore = new double[4]; 

    private string piecetype;

    private Heads head;
    private Editions edition;
    private Aura aura;


    //first; 0: base(+bonus); 1: edition; 2: enhancement
    //second; 0: +pts; 1: xpts; 2: +mult; 3: xmult

    private List<PiecesBetza> pieces = new List<PiecesBetza>();

    public PiecesBetza(string name, string moves, string abv, string color, string piecetype, double[] ptscore, Heads head, Editions edition, Aura aura){
        this.name = name;
        this.moves = moves;
        this.abv = abv;
        this.color = color;
        this.piecetype = piecetype;
        this.ptscore = ptscore;
        this.head = head;
        this.edition = edition;
        this.aura = aura;
    }
}

public class Pawn:PiecesBetza{
    public Pawn(string color, double[] ptscore){
        base.("Pawn","fmWfceFifmnD", "P", color, "pawn", ptscore,null,null,null)
    }
    public Pawn(string color){
        Pawn(color, new double[]{1,0,0,0});
    }
}

public class Knight:PiecesBetza{
    public Knight(string color, double[] ptscore){
        base.("Knight","N", "N", color, "knight", ptscore,null,null,null);
    }
    public Knight(string color){
        Knight(color, new double[]{3,0,0,0});
    }
}

public class Bishop:PiecesBetza{
    public Bishop(string color, double[] ptscore){
        base.("Bishop","B", "B", color, "bishop", ptscore,null,null,null);
    }
    public Bishop(string color){
        Bishop(color, new double[]{3,0,0,0});
    }
}

public class Rook:PiecesBetza{
    public Rook(string color, double[] ptscore){
        base.("Rook","R", "R", color, "rook", ptscore,null,null,null);
    }
    public Rook(string color){
        Rook(color, new double[]{5,0,0,0});
    }
}

public class Queen:PiecesBetza{
    public Queen(string color, double[] ptscore){
        base.("Queen","Q", "Q", color, "queen", ptscore,null,null,null);
    }
    public Queen(string color){
        Queen(color, new double[]{9,0,0,0});
    }
}

public class King:PiecesBetza{
    public King(string color, double[] ptscore){
        base.("King","K", "K", color, "king", ptscore,null,null,null);
    }
    public King(string color){
        King(color, new double[]{4,0,0,0});
    }
}

public class Crusader:PiecesBetza{
    public Crusader(string color, double[] ptscore){
        base.("Crusader","fBbR", "C", color, "bishop", ptscore,null,null,null);
    }
    public Crusader(string color){
        Crusader(color, new double[]{3.5,0,0,0});
    }
}
public class Viking:PiecesBetza{
    public Viking(string color, double[] ptscore){
        base.("Viking","R2B1", "V", color, "king", ptscore, null, null, null);
    }
    public Viking(string color){
        Viking(color, new double[]{4.75,0,0,0});
    }
}
public class RoyalGuard:PiecesBetza{
    public RoyalGuard(string color, double[] ptscore){
        base.("Royal Guard","cQmK","G",color,"queen",ptscore,null,null,null);
    }
    public RoyalGuard(string color){
        Viking(color, new double[]{8,0,0,0});
    }
}

public class Cannon:PiecesBetza{//I believe that this is already included in fairy stockfish
    public Cannon(string color, double[] ptscore){
        base.("Cannon","mRcpR","O",color,"rook",ptscore,null,null,null);
    }
    public Cannon(string color){
        Cannon(color, new double[]{5.5,0,0,0});
    }
}
public class Musketeer:PiecesBetza{
    public Musketeer(string color, double[] ptscore){
        base.("Musketeer", "sRB1","M",color,"rook",ptscore,null,null,null);
    }
    public Musketeer(string color){
        Musketeer(color, new double[]{4.5,0,0,0});
    }
}
public class Unicorn:PiecesBetza{//I believe that this is already included in fairy stockfish
    public Unicorn(string color, double[] ptscore){
        base.("Unicorn", "RN", "U",color,"rook",ptscore,null,null,null);
    }
    public Unicorn(string color){
        Unicorn(color, new double[]{8,0,0,0});
    }
}
public class Archbishop:PiecesBetza{//I believe that this is already included in fairy stockfish
    public Archbishop(string color, double[] ptscore){
        base.("Archbishop","BN","A",color,"bishop",ptscore,null,null,null);
    }
    public Archbishop(string color){
        Archbishop(color, new double[]{7.5,0,0,0});
    }
}
public class Cardinal:PiecesBetza{
    public Cardinal(string color,double[] ptscore){
        base.("Cardinal","BK","C",color,"bishop",ptscore,null,null,null);
    }
    public Cardinal(string color){
        Cardinal(color,new double[]{3.5,0,0,0});
    }
}
public class MountedKing:PiecesBetza{
    public MountedKing(string color, double[] ptscore){
        base.("Mounted King","NK","M",color,"king",ptscore,null,null,null);
    }
    public MountedKing(string color){
        MountedKing(color, new double[]{5,0,0,0})
    }
}
public class Pegasus:PiecesBetza{
    public Pegasus(string color, double[] ptscore){
        base.("Pegasus Rider","N2","P",color,"knight",ptscore,null,null,null);
    }
    public Pegasus(string color){
        Pegasus(color,new double[]{5,0,0,0});
    }
}
public class WarWagon:PiecesBetza{
    public WarWagon(string color, double[] ptscore){
        base.("War Wagon","RK","W",color,"rook",ptscore,null,null,null);
    }
    public WarWagon(string color){
        WarWagon(color,new double[]{6,0,0,0});
    }
}
public class Templar:PiecesBetza{
    public Templar(string color, double[] ptscore){
        base.("Templar","BvR","T",color,"bishop",ptscore,null,null,null);
    }
    public Templar(string color){
        Templar(color,new double[]{6,0,0,0});
    }
}
public class Beserker:PiecesBetza{
    public Beserker(string color, double[] ptscore){
        base.("Beserker","R3NK","B",color,"rook",ptscore,null,null,null);
    }
    public Beserker(string color){
        Beserker(color,new double[]{5,0,0,0});
    }
}
public class Dragon:PiecesBetza{
    public Dragon(string color, double[] ptscore){
        base.("Dragon","BR3","D",color,"bishop",ptscore,null,null,null);
    }
    public Dragon(color){
        Dragon(color,new double[]{4,0,0,0})
    }
}



}


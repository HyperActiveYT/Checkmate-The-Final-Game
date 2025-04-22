namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;

public class PiecesBetza:Board{
    private string name; public string getName() => name;
    private string moves; public string getMoves() => moves;
    private string abv; public string getAbv() => abv;
    private string color;/*1=white, -1=black*/ public string getColor() => color;
    private double[] ptscore = new double[4]; public string getPtscore() => ptscore;
    private string piecetype; public string getPieceType() => piecetype;
    
    private int buycost=0; public int getBuyCost() => buycost;
    private int rebuycost=0; public int getRebuyCost() => rebuycost;

    private Heads head; public string getHead() => head;
    private Editions edition; public string getEdition() => edition;
    private Aura aura; public string getAura() => aura;

    //0: +pts; 1: xpts; 2: +mult; 3: xmult

    private static List<PiecesBetza> YourPieces = new List<PiecesBetza>(); public static List<PiecesBetza> getYourPieces() => YourPieces;
    public static void addYourPiece(PiecesBetza p){
        YourPieces.Add(p);
    }
    public static void removeYourPiece(PiecesBetza p){
        YourPieces.Remove(p);
    }
    private static List<PiecesBetza> YourCapturedPieces = new List<PiecesBetza>(); public static List<PiecesBetza> getYourCapturedPieces() => YourCapturedPieces;
    public static void addYourCapturedPiece(PiecesBetza p){
        YourCapturedPieces.Add(p);
    }
    public static void removeYourCapturedPiece(PiecesBetza p){
        YourCapturedPieces.Remove(p);
    }
    private static List<PiecesBetza> AllPieces = new List<PiecesBetza(); public static List<PiecesBetza> getAllPieces() => AllPieces;


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
        buycost = ptscore[0];
        rebuycost = buycost/2;
    }

    public static PiecesBetza copyPiece(PiecesBetza p){
        PiecesBetza newpiece = new PiecesBetza(p.getName(), p.getMoves(), p.getAbv(), p.getColor(), p.getPieceType(), p.getPtscore(), p.getHead(), p.getEdition(), p.getAura());
        return newpiece;
    }

    public void setHead(Heads head){
        this.head = head;
    }
    public void setEdition(Editions edition){
        this.edition = edition;
    }
    public void setAura(Aura aura){
        this.aura = aura;
    }

    public static void createAllPieces(){
        Pawn p = new Pawn(1);
        Knight n = new Knight(1);
        Bishop b = new Bishop(1);
        Rook r = new Rook(1);
        Queen q = new Queen(1);
        King k = new King(1);
        /*Crusader c = new Crusader(1);
        Viking v = new Viking(1);
        RoyalGuard g = new RoyalGuard(1);
        Cannon o = new Cannon(1);
        Musketeer m = new Musketeer(1);
        Unicorn u = new Unicorn(1);
        Archbishop a = new Archbishop(1);
        Cardinal d = new Cardinal(1);
        MountedKing o = new MountedKing(1);
        Pegasus s = new Pegasus(1);
        WarWagon w = new WarWagon(1);
        Templar t = new Templar(1);
        Beserker e = new Beserker(1);
        Dragon f = new Dragon(1);*/
        AllPieces.Add(p);
        AllPieces.Add(n);
        AllPieces.Add(b);
        AllPieces.Add(r);
        AllPieces.Add(q);
        AllPieces.Add(k);
        /*AllPieces.Add(c);
        AllPieces.Add(v);
        AllPieces.Add(g);
        AllPieces.Add(o);
        AllPieces.Add(m);
        AllPieces.Add(u);
        AllPieces.Add(a);
        AllPieces.Add(d);
        AllPieces.Add(o);
        AllPieces.Add(s);
        AllPieces.Add(w);
        AllPieces.Add(t);
        AllPieces.Add(e);
        AllPieces.Add(f);*/
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
        base.("Pegasus Rider","N2","S",color,"knight",ptscore,null,null,null);
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
        base.("Dragon","BR3","F",color,"bishop",ptscore,null,null,null);
    }
    public Dragon(color){
        Dragon(color,new double[]{4,0,0,0})
    }
}



}


namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;

public class Checks{
    
    private static List<Checks> allChecks = new List<Checks>();
    private static List<Checks> viewableChecks = new List<Checks>();
    private int lvl = 1;
    private string name;
    private int[] basescore;//pt, mult
    private int[] addition;
    private int[] score;

    public Checks(string name, int[] basescore, int[] addition){
        this.name = name;
        this.basescore = basescore;
        score = basescore;
        this.addition = addition;
        allChecks.Add(this);
    }

    public static void createChecks(){
        Checks Direct = new Checks("Direct Check", new int[]{5,1}, new int[]{10,1});
        Checks Skewer = new Checks("Skewer Check", new int[]{10,2}, new int[]{15,1});
        Checks Fork = new Checks("Fork Check", new int[]{20,2}, new int[]{20,1});
        Checks Double = new Checks("Double Check", new int[]{30,3}, new int[]{20,2});
        Checks Discover = new Checks("Discovered Check", new int[]{30,4}, new int[]{30,3});
        Checks Promotion = new Checks("Promotion Check", new int[]{35,4}, new int[]{15,2});
        Checks Castle = new Checks("Castling Check", new int[]{60,7}, new int[]{30,3});
        Checks Cross = new Checks("Cross Check", new int[]{100,8}, new int[]{40,4});
        //Secret Checks Below:
        Checks EnPassant = new Checks("En Passant Check", new int[]{120,12}, new int[]{35,3});
        Checks OneDisambig = new Checks("Singly Disambiguated Check", new int[]{140,14}, new int[]{40,4});
        Checks TwoDisambig = new Checks("Doubly Disambiguated Check", new int[]{160,16}, new int[]{50,3});

    }

    public void levelchange(int change){
        if (lvl+change<=0){
            change = 1-lvl;
        }
        lvl += change;
        score[0]+=change*addition[0];
        score[1]+=change*addition[1];
    }

}

public class ChessvolutionCards{
    private static List<ChessvolutionCards> allCVCards = new List<ChessvolutionCards>();
    private static List<ChessvolutionCards> visibleCVCards = new List<ChessvolutionCards>();
    string name;
    Checks check;

    public ChessvolutionCards(string name, Checks check){
        this.name = name;
        this.check = check;
        allCVCards.Add(this);
    }

    public Checks getCheck() => check;

        public static void consumeCVCard(ChessvolutionCards card){
        card.check.levelchange(1);
    }

}
}
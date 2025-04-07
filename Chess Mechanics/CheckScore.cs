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
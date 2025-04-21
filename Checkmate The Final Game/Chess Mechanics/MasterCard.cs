namespace Checkmate_The_Final_Game.Chess_Mechanics{

using System;
using System.Collections;
using System.Collections.Generic;
public class MasterCard{

    private static List<MasterCard> allCards = new List<MasterCard>();
    private static List<MasterCard> heldCards = new List<MasterCard>();
    private static List<MasterCard> Common = new List<MasterCard>();
    private static List<MasterCard> Uncommon = new List<MasterCard>();
    private static List<MasterCard> Rare = new List<MasterCard>();
    private static List<MasterCard> Epic = new List<MasterCard>();
    private static List<MasterCard> Legendary = new List<MasterCard>();
    private string name;

    private int basecost;
    private int cost;
    private int sellval;
    private int rarity; //0: Common, 1: Uncommon, 2: Rare, 3: Epic, 4: Legendary
    
    public MasterCard(string name, int rarity){
        this.name = name;
        this.rarity = rarity;
        allCards.Add(this);
        if (rarity == 0){
            Common.Add(this);
            basecost = 4;
        } else if (rarity == 1){
            Uncommon.Add(this);
            basecost = 6;
        } else if (rarity == 2){
            Rare.Add(this);
            basecost = 8;
        } else if (rarity == 3){
            Epic.Add(this);
            basecost = 10;
        } else if (rarity == 4){
            Legendary.Add(this);
            basecost = 20;
        }
        cost = basecost;
        sellval = cost/2;
    }



    public static void MasterCardEffect(){

    }

    public static void Main(string[] args){
        Pieces Knight = new Pieces({{0,1,0,1,0},{1,0,0,0,1},{0,0,0,0,0,},{1,0,0,0,1},{0,1,0,1,0}}, "Knight");
        WriteLine(Knight);
    }
}
}
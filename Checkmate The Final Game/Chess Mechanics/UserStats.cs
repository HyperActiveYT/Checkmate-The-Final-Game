namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
public class UserStats{
    //Consumables
    private static int consumableslots = 2; public static int getConsumableSlots() => consumableslots;
    private static List<> heldConsumables = new List<>(); public static List<> getHeldConsumables() => heldConsumables;
    private static Consumables lastUsed; public static Consumables getLastUsed() => lastUsed;
    public static void setLastUsed(Consumables consumable) => lastUsed = consumable;

    public static void incConsSlot() => consumableslots++;
        public static void useConsumable(Consumable consumable){
        if (heldConsumables.Contains(consumable)){
            consumable.effect();/*MAKE SURE THE METHOD IS THE CORRECT ONE*/
            heldConsumables.Remove(consumable);
        } else {
            Console.WriteLine("You do not have that consumable");
        }
    }
    public static void addConsumable(Consumable consumable){
        if (heldConsumables.Count<consumableslots){
            heldConsumables.Add(consumable);
        } else {
            Console.WriteLine("You do not have enough slots for that consumable");
        }
    }
    //Purchase Slots
    private static slot = 2; public static int getShopSlots() => slot; //number of slots available in shop
    public static void incShopSlot() => slot++;

    //Interest calculations
    private static int inHandMoney = 0; public static int getInHandMoney() => inHandMoney;
    public static void addMoney(int money){
        inHandMoney += money;
    }
    public static void removeMoney(int money){
        inHandMoney -= money;
    }
    public static void setMoney(int money){
        inHandMoney = money;
    }
    private static int interest = 1; /*+1 in interest every 5 dollars*/ public static int getInterest() => interest;
    private static int maxinterest = 5; public static int getMaxInterest() => maxinterest;
    public static void setinterest(int interest){
        this.interest = interest;
    }
    public static int setmaxinterest(int maxinterest){
        this.maxinterest = maxinterest;
    }
    public static void calcInterest(){
        
    }

    //Checks and Moves stats
    private static int baseChecks = 4; public static int getBaseChecks() => baseChecks;
    private static int baseMoves = 100; public static int getBaseMoves() => baseMoves;

}
public class Checks:UserStats{
    
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
        
        viewableChecks.Add(Direct);
        viewableChecks.Add(Skewer);
        viewableChecks.Add(Fork);
        viewableChecks.Add(Double);
        viewableChecks.Add(Discover);
        viewableChecks.Add(Promotion);
        viewableChecks.Add(Castle);
        viewableChecks.Add(Cross);
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

}
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
}
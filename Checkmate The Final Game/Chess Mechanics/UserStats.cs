namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
public class UserStats{
    private static int consumableslots = 2; public static int getConsumableSlots() => consumableslots;
    private static slot = 2; //number of slots available in shop
    private static List<> heldConsumables = new List<>(); public static List<> getHeldConsumables() => heldConsumables;

    private static Consumables lastUsed; public static Consumables getLastUsed() => lastUsed;
    public static void setLastUsed(Consumables consumable) => lastUsed = consumable;

    public static incConsSlot() => consumableslots++;
    public static incShopSlot() => slot++;

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
}
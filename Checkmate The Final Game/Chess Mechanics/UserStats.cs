namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserStatsVisualizer : MonoBehaviour
{
    public Text moneyText; // UI Text for displaying money
    public Text consumableSlotsText; // UI Text for displaying consumable slots
    public Text interestText; // UI Text for displaying interest
    public Text maxInterestText; // UI Text for displaying max interest

    public void UpdateStatsDisplay()
    {
        moneyText.text = "Money: " + UserStats.getInHandMoney();
        consumableSlotsText.text = "Consumable Slots: " + UserStats.getConsumableSlots();
        interestText.text = "Interest: " + UserStats.getInterest();
        maxInterestText.text = "Max Interest: " + UserStats.getMaxInterest();
    }
}
public class ConsumablesManager : MonoBehaviour
{
    public GameObject consumablePrefab; // Prefab for consumable items (UI or 3D model)
    public Transform consumablesParent; // Parent transform for consumables UI objects

    public void AddConsumable(Consumable consumable)
    {
        // Add the consumable to the list and instantiate it in the UI
        if (UserStats.getHeldConsumables().Count < UserStats.getConsumableSlots())
        {
            UserStats.addConsumable(consumable);
            UpdateConsumableUI(consumable);
        }
        else
        {
            Debug.LogWarning("No available slot for the consumable.");
        }
    }

    public void UseConsumable(Consumable consumable, Pieces piece)
    {
        UserStats.useConsumable(consumable, piece);
        UpdateConsumableUI(consumable); // Update UI after using
    }

    private void UpdateConsumableUI(Consumable consumable)
    {
        // Instantiate or update the UI element for the consumable
        GameObject newConsumableUI = Instantiate(consumablePrefab, consumablesParent);
        // Set the name or icon for the consumable in the UI
        newConsumableUI.GetComponentInChildren<Text>().text = consumable.Name;
    }
}
public class ChecksVisualizer : MonoBehaviour
{
    public GameObject checkItemPrefab; // Prefab for displaying check information
    public Transform checksParent; // Parent transform for check UI elements

    public void UpdateCheckList(List<Checks> checksList)
    {
        // Clear existing check UI elements
        foreach (Transform child in checksParent)
        {
            Destroy(child.gameObject);
        }

        // Create UI elements for each check
        foreach (var check in checksList)
        {
            GameObject checkItemUI = Instantiate(checkItemPrefab, checksParent);
            checkItemUI.GetComponentInChildren<Text>().text = check.name + ": Score = " + check.score[0];
        }
    }
}
public class ChecksManager : MonoBehaviour
{
    public ChecksVisualizer checksVisualizer; // Reference to the ChecksVisualizer

    public void LevelUpCheck(Checks check, int levelIncrease)
    {
        check.levelchange(levelIncrease); // Update check level
        checksVisualizer.UpdateCheckList(UserStats.viewableChecks); // Update UI
    }
}
public class UserStats{
    private static bool hasFAILED = false; public static void changeHASFAILED() => hasFAILED = !hasFAILED;
    //Consumables
    private static int consumableslots = 2; public static int getConsumableSlots() => consumableslots;
    private static List<> heldConsumables = new List<>(); public static List<> getHeldConsumables() => heldConsumables;
    private static Consumables lastUsed; public static Consumables getLastUsed() => lastUsed;
    public static void setLastUsed(Consumables consumable) => lastUsed = consumable;

    public static void incConsSlot() => consumableslots++;
        public static void useConsumable(Consumable consumable, Pieces p){
        if (heldConsumables.Contains(consumable)){
            consumable.effect(p);
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
    private static int interest = 1; /*+1 in interest every 10 dollars*/ public static int getInterest() => interest;
    private static int maxinterest = 10; public static int getMaxInterest() => maxinterest;
    public static void setinterest(int interest){
        this.interest = interest;
    }
    public static int setmaxinterest(int maxinterest){
        this.maxinterest = maxinterest;
    }
    public static void calcInterest(){
        money += interest*(int)(0.1*Math.min(money,maxinterest*10));
    }

    //Checks and Moves stats
    private static int baseChecks = 4; public static int getBaseChecks() => baseChecks;
    private static int baseMoves = 100; public static int getBaseMoves() => baseMoves;
    private static int maxMasterCardslots = 5; public static int getMaxMasterCardSlots() => maxMasterCardslots;

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
        //Checks Skewer = new Checks("Skewer Check", new int[]{10,2}, new int[]{15,1});
        //Checks Fork = new Checks("Fork Check", new int[]{20,2}, new int[]{20,1});
        Checks Capture = new Checks("Capture Check", new int[]{20,2}, new int[]{15,1});
        Checks Double = new Checks("Double Check", new int[]{30,3}, new int[]{20,2});
        Checks Discover = new Checks("Discovered Check", new int[]{30,4}, new int[]{30,3});
        Checks Promotion = new Checks("Promotion Check", new int[]{35,4}, new int[]{15,2});
        Checks Castle = new Checks("Castling Check", new int[]{60,7}, new int[]{30,3});
        //Secret Checks Below: SCRATCH THE SECRET CHECKS NEVER MIND
        Checks Cross = new Checks("Cross Check", new int[]{100,8}, new int[]{40,4});
        Checks EnPassant = new Checks("En Passant Check", new int[]{120,12}, new int[]{35,3});
        //Checks OneDisambig = new Checks("Singly Disambiguated Check", new int[]{140,14}, new int[]{40,4});
        //Checks TwoDisambig = new Checks("Doubly Disambiguated Check", new int[]{160,16}, new int[]{50,3});
        
        viewableChecks.Add(Direct);
        //viewableChecks.Add(Skewer);
        //viewableChecks.Add(Fork);
        viewableChecks.Add(Capture);
        viewableChecks.Add(Double);
        viewableChecks.Add(Discover);
        viewableChecks.Add(Promotion);
        viewableChecks.Add(Castle);
        viewableChecks.Add(Cross);
        viewableChecks.Add(EnPassant);
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
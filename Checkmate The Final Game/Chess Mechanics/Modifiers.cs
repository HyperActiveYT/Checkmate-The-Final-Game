namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
public class Editions{

    private string name;
    private int addcost; public int getEditiionCost() => addcost;

    private static List<Editions> AllEditions = new List<Editions>();
    public Editions(string name, int addcost){
        this.name = name;
        AllEditions.Add(this);
        this.addcost = addcost;
    }

    public static void createEditions(){
        Editions Ancient = new Editions("Ancient",3);
        Editions Gold = new Editions("Gold",3);
        Editions Glass = new Editions("Glass",4);
        Editions Metal = new Editions("Metal",4);
        Editions Plastic = new Editions("Plastic",3);
        Editions Magnetic = new Editions("Magnetic",4);
        Editions Glitched = new Editions("Glitched",5);
    }
    public string effects(string timeframe){
        if (timeframe.equals("On Check")){
            if (name.equals("Ancient")){
                Score.modifyScore(new int[]{0,2,0,1});
                Random rand = new Random();
                int val = rand.Next(5);
                if (val==0){
                    return "shatter";
                }
            }
        }
        return "";


    }

}

public class Aura{

    private string name;

    private int addcost; public int getAuraCost() => addcost;
    private static List<Aura> AllAuras = new List<Aura>();
    public Aura(string name,int addcost){
        this.name = name;
        this.addcost = addcost;
        AllAuras.Add(this);
    }
}

public class Heads{

    private string name;
    private int addcost; public int getHeadCost() => addcost;
    private static List<Heads> AllHeads = new List<Heads>(); public static List<Heads> getAllHeads() => AllHeads;
    public Heads(string name, int addcost){
        this.name = name;
        this.addcost = addcost;
        AllHeads.Add(this);
    }

    public static void createHeads(){
        Heads purp = new Heads("Purple", 3);
        Heads blue = new Heads("Blue", 3);
        Heads red = new Heads("Red", 5);
        Heads gold = new Heads("Gold", 4);
    }

    public string HeadEffects(string timeframe){
        if (timeframe.equals("On Capture")){
            if (name.equals("Purple")){
                if (UserStats.getheldConsumables().Count<UserStats.getConsumableSlots()){
                    Random rand = new Random();
                    int val = rand.Next(getAllChaturangaCards().Count);
                    UserStats.addheldConsumable(getAllChaturangaCards().get(val));
                    return "Consumable Added";
                }
            }
        } else if (timeframe.equals("On Check")){
            if (name.equals("Red")){
                //how the hell are we supposed to do retrigger effects...
            }
        } else if (timeframe.equals("Game End")){
            if (name.equals("Blue")){

            }

        }
        return "";

}
}
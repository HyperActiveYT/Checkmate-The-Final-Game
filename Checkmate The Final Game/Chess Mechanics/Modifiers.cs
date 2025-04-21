namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;
public class Editions{

    private string name;
    private int addcost;

    private static List<Editions> AllEditions = new List<Editions>();
    public Editions(string name, int addcost){
        this.name = name;
        AllEditions.Add(this);
        this.addcost = addcost;
    }

    public static void createEditions(){
        Editions Ancient = new Editions("Ancient",3);
        Editions Gold = new Editions("Gold",3);
        Editions Glass = new Editions("Glass",3);
        Editions Metal = new Editions("Metal",3);
        Editions Plastic = new Editions("Plastic",3);
        Editions Magnetic = new Editions("Magnetic",3);
        Editions Glitched = new Editions("Glitched",3);
    }

    public static void effects(){
        if (name.equals("Ancient")){
            
        }
    }

}

public class Aura:PiecesBetza{

    private string name;
    private static List<Aura> AllAuras = new List<Aura>();
    public Aura(string name){
        this.name = name;
        AllAuras.Add(this);
    }

    
}

public class Heads{

    private string name;
    private List<Heads> AllHeads = new List<Heads>();
    public Heads(string name){
        this.name = name;
        AllHeads.Add(this);
    }

}
}
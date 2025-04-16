namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;
public class Editions{

    private string name;

    private static List<Editions> AllEditions = new List<Editions>();
    public Editions(string name){
        this.name = name;
        AllEditions.Add(this);
    }

    public static void effects(){
        
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
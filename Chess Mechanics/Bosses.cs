namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;

public class Bosses:Game{

    private static List<Bosses> RegularBoss = new List<Bosses>();
    private static List<Bosses> FinalBoss = new List<Bosses>();
    private static List<Bosses> seenRegularBoss = new List<Bosses>();
    private static List<Bosses> unseenRegularBoss = new List<Bosses();
    private static List<Bosses> seenFinalBoss = new List<Bosses>();
    private static List<Bosses> unseenFinalBoss = new List<Bosses>();

    private string name;

    public Bosses(string name, int type){
        this.name = name;
        if (type == 0){
            RegularBoss.Add(this);
            unseenRegularBoss.Add(this);
        } else if (type == 1){
            FinalBoss.Add(this);
            unseenFinalBoss.Add(this);
        }
    }
    public static void createBosses(){
        createRegBosses();
        createFinBosses();
    }
    public static void createRegBosses(){
        Bosses Clock = new Bosses("The Clock",0);
        Bosses Wise = new Bosses("The Wise",0);
        Bosses Punisher = new Bosses("The Punisher",0);
        Bosses Creator = new Bosses("The Creator",0);
        Bosses Volcano = new Bosses("The Volcano",0);
        Bosses Atomizer = new Bosses("The Atomizer",0);
        Bosses Crusader = new Bosses("The Crusader",0);
        Bosses Inquisition = new Bosses("The Inquisition",0);
        Bosses OneCheck = new Bosses("One-Check",0);
        Bosses FiftyMove = new Bosses("The Fifty-Move Rule",0);
        Bosses KotH = new Bosses("The High Ground",0);
        Bosses Stalingrad = new Bosses("Stalingrad",0):
        Bosses Revolution = new Bosses("Viva la Revolution",0);
        Bosses RoyalCoup = new Bosses("Royal Coup",0);
        Bosses Botez = new Bosses("Botez",0);
        Bosses Stubborn = new Bosses("The Stubborn",0);
        Bosses Various = new Bosses("The Various",0);
        Bosses Taunter = new Bosses("The Taunter",0);
        Bosses Medusa = new Bosses("Medusa",0);
        Bosses DoubleAgent = new Bosses("Double Agent",0);
    }

    public static void createFinBosses(){
        Bosses AI = new Bosses("AI",1);
        Bosses Cheater = new Bosses("The Cheater",1);
        Bosses Press = new Bosses("The Press",1);
        Bosses ForceJedi = new Bosses("The Force of the Jedi",1);
        Bosses Invincible = new Bosses("The Invincible",1);
        Bosses Bossemony = new Bosses("Boss-emony",1);
    }

    public static void effect(){
        
    }

}
}
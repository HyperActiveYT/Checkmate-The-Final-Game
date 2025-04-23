/*namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
//using System.Timers;
using System.Collections;
using System.Collections.Generic;

public class Bosses:Tournament{

    private static List<Bosses> RegularBoss = new List<Bosses>();
    private static List<Bosses> FinalBoss = new List<Bosses>();
    private static List<Bosses> seenRegularBoss = new List<Bosses>();
    private static List<Bosses> unseenRegularBoss = new List<Bosses();
    private static List<Bosses> seenFinalBoss = new List<Bosses>();
    private static List<Bosses> unseenFinalBoss = new List<Bosses>();

    private string name;
    //private static Timer time;
    private static int moveselapsed;
    private static int bosseffectActive = false;
    private static int wasELO;

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
        //Bosses Clock = new Bosses("The Clock",0);
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
        //Bosses Bossemony = new Bosses("Boss-emony",1);
    }

    public static void decMovesElapse(){
        moveselapsed--;
    }

    public void Bosseffect(string timeframe){
        if (timeframe.Equals("Boss Select")){
            /*if (name.Equals("The Clock")){
                time = 
            } else */if (name.Equals("The Wise")){
                ComputerSettings.modifyELO(1.5);
            } else if (name.Equals("The Crusader")){
                
            } else if (name.Equals("The Inquisition")){
            }
        }
        if (timeframce.equals("On Move")){
            if (name.Equals("The Punisher")){
                if (bosseffectActive){
                    if (moveselapsed == 0){
                        ComputerSettings.setELO(wasELO);
                        bosseffectActive = false;
                    }
                } else {
                    wasELO = ComputerSettings.getELO();
                    ComputerSettings.setELO(3200);
                    bosseffectActive = true;
                }
            } else if (name.Equals("The Creator")){
                Random rand = new Random();
                int num = rand.Next(6);
                Pieces p = Pieces.getAllPieces()[num];
                for (int i=0; i<8, i++){
                    
                }
            /*} else if (name.Equals("The Volcano")){*/
        if (timeframe.equals("On Captured")){}
            if (name.Equals("The Atomizer")){

            } else if (name.Equals("The Crusader")){
            } else if (name.Equals("The Inquisition")){
            }
        }
    }


}
}
}
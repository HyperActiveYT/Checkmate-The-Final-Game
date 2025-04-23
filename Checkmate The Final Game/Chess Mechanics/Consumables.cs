namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
public class Consumables{
    private string name; public string getName() => name;
    public Consumables(string name){
        this.name = name;
    }
}
public class TheCardsofChess:Consumables{//Equivalent of Spectral Cards

    private static List<TheCardsofChess> AllCoCCards = new List<TheCardsofChess>(); public static List<TheCardsofChess> getAllCoCCards() => AllCoCCards;

    public TheCardsofChess(string name){
        base.Consumables(name);
        AllCoCCards.Add(this);
    }

    public static void createCoCCards()[
        TheCardsofChess Sac = new TheCardsofChess("Sacrifice!");
        TheCardsofChess Deja = new TheCardsofChess("Deja Vu");
        TheCardsofChess Tal = new TheCardsofChess("Talent");
        TheCardsofChess Gold = new TheCardsofChess("Gold");
        TheCardsofChess Apoc = new TheCardsofChess("Apcoalypse");
        TheCardsofChess Royal = new TheCardsofChess("Royalty");
        TheCardsofChess Greed = new TheCardsofChess("Greed");
        TheCardsofChess Double = new TheCardsofChess("Double Trouble");
        TheCardsofChess Cassia = new TheCardsofChess("Cassia the God of Chess");
        TheCardsofChess Ascen = new TheCardsofChess("Ascension");
    ]

    public void effect(Pieces p){
        if (name.equals("Sacrifice!")){
            p.setHeads(Heads.getAllHeads().get(0));
        } else if name.equals("Talent"){
            p.setHeads(Heads.getAllHeads().get(1));
        } else if name.equals("Deja Vu"){
            p.setHeads(Heads.getAllHeads().get(2));
        } else if name.equals("Gold"){
            p.setHeads(Heads.getAllHeads().get(3));
        } else if name.equals("Apcoalypse"){
            Pieces p1 = copypiece(p);
            Pieces.
            Pieces p2 = copypiece(p);
        }
    }

}

public class ChaturangaCards:Consumables{ //Equivalent of Tarot Cards

    private static List<ChaturangaCards> AllChaturangaCards = new List<ChaturangaCards>(); public static List<ChaturangaCards> getAllChaturangaCards() => AllChaturangaCards;

    public ChaturangaCards(string name){//
        base.Consumables(name);
        AllChaturangaCards.Add(this);
    }

    public static void createChaturangaCards(){
        ChaturangaCards Copy = new ChaturangaCards("The Copier");
        ChaturangaCards Prod = new ChaturangaCards("The Prodigy");
        ChaturangaCards WaCBp = new ChaturangaCards("The Wheat and Chessboard Problem");
        ChaturangaCards Sissa = new ChaturangaCards("Sissa the Inventor");
    }


}
public class ChessvolutionCards:Consumables{
    private static List<ChessvolutionCards> allCVCards = new List<ChessvolutionCards>();
    private static List<ChessvolutionCards> visibleCVCards = new List<ChessvolutionCards>();
    Checks check;

    public ChessvolutionCards(string name, Checks check){
        base.Consumables(name);
        this.check = check;
        allCVCards.Add(this);
    }

    public Checks getCheck() => check;

    public static void consumeCVCard(ChessvolutionCards card){
        card.check.levelchange(1);
        UserStats.setLastUsed(card);
    }

}

public class Tickets{
    
    private static List<Tickets> T1all = new List<Tickets>();
    private static List<Tickets> T1available = new List<Tickets>();
    private static List<Tickets> T1bought = new List<Tickets>();

    private static List<Tickets> T2all = new List<Tickets>();
    private static List<Tickets> T2available = new List<Tickets>();
    private static List<Tickets> T2bought = new List<Tickets>();
    private string name;
    private Tickets upgraded; //for t1 tickets only

    public Tickets(string name,Tickets upgraded){//T1
        this.name = name;
        this.upgraded = upgraded;
        T1all.Add(this);
        T1available.Add(this);
    }

    public Tickets(string name){//T2
        this.name = name;
        upgraded = null;
        T2all.Add(this);
    }

    public static string CreateT2Tickets(){
        Tickets Comm = new Tickets("Commissioner");
        Tickets Emul = new Tickets("Emulator");
        Tickets Skynet = new Tickets("Skynet's Time Displacement Equipment");
        Tickets IceAge = new Tickets("Ice Age");
        Tickets Hack = new Tickets("Hacker");
        Tickets Manufac = new Tickets("Manufacturer");
        Tickets Stash = new Tickets("Stasher");
        Tickets Theory = new Tickets("Check Theorist");
        Tickets Mateth = new Tickets("Mate-thusiast");
        Tickets Pawnth = new Tickets("Pawn-thusiast");
        Tickets ProdAsh = new Tickets("Prodigy from the Ashes");
        Tickets Corp = new Tickets("Corporate");
        Tickets Crip = new Tickets("The Crippler");
    }

    public static string CreateTickets(){
        CreateT2Tickets();
        Tickets Coll = new Tickets("Collector",Comm);
        Tickets Copy = new Tickets("Copier",Emul);
        Tickets Time = new Tickets("Time Machine",Skynet);
        Tickets Cryo = new Tickets("Cryogenics",IceAge)
        Tickets BkEnd = new Tickets("Backend", Hack);
        Tickets Dist = new Tickets("Distributor",Manufac);
        Tickets Gult = new Tickets("Glutton",Stash);
        Tickets Psych = new Tickets("Chess Psychic",Theory);
        Tickets Checkth = new Tickets("Check-thusiast",Mateth);
        Tickets Moveth = new Tickets("Move-thusiast",Pawnth);
        Tickets Empty = new Tickets("Empty Score Sheet",ProdAsh);
        Tickets Trad = new Tickets("Trader",Corp);
        Tickets Disab = new Tickets("The Disabler",Crip);
    }

    public void effects(){
        
    }



}

}
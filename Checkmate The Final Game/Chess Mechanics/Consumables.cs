namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
public class Consumables{
    private string name; public string getName() => name;
    private int buycost=3;
    private int sellval=buycost/2;

    //private static int AscensionCounter = 0;
    public Consumables(string name){
        this.name = name;
    }
    public Consumables(string name, int sellval){
        this.name = name;
        this.buycost = sellval;
    }
    public static void setSellVal(){
        sellval = buycost/2;
    }
}
public class TheCardsofChess:Consumables{//Equivalent of Spectral Cards

    private static List<TheCardsofChess> AllCoCCards = new List<TheCardsofChess>(); public static List<TheCardsofChess> getAllCoCCards() => AllCoCCards;

    public TheCardsofChess(string name){
        base.Consumables(name,4);
        setSellVal();
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

    public void CoCeffect(Pieces p){
        if (getName().equals("Sacrifice!")){
            p.setHeads(Heads.getAllHeads().get(0));
        } else if getName().equals("Talent"){
            p.setHeads(Heads.getAllHeads().get(1));
        } else if getName().equals("Deja Vu"){
            p.setHeads(Heads.getAllHeads().get(2));
        } else if getName().equals("Gold"){
            p.setHeads(Heads.getAllHeads().get(3));
        } else if getName().equals("Apcoalypse"){
            Pieces p1 = copypiece(p);
            Pieces p2 = copypiece(p);
            Pieces.addYourPiece(p1);
            Pieces.addYourPiece(p2);
        /*} else if getName().equals("Royalty"){//Destroy a random non-King piece and add one of each: a randomly modified queen and rook to the board
        */} else if getName().equals("Greed"){//Greed: Destroy 3 random non-King pieces and gain $25
            for (int i=0; i<3; i++){
                int rand = roll(Pieces.getYourPieces().Count);
                Pieces p = Pieces.getYourPieces().get(rand);
                if (p.getName().equals("King")){
                    i--;
                    continue;
                }
                Pieces.removeYourPiece(p);
                UserStats.addMoney(25);
            }
        } else if getName().equals("Double Trouble"){//Duplicate one random master card and destroy the others
            int rand = roll(getHeldCards().Count);
            MasterCard original = getHeldCards().get(rand);
            MasterCard clone = MasterCard.clone(getHeldCards().get(rand));
            List<MasterCard> newHand = new List<MasterCard>();
            MasterCard.Add(original);
            MasterCard.Add(clone);
            MasterCard.setHand(newHand);
        } else if getName().equals("Cassia the God of Chess"){//Increases the level of all checks by 1
            for (int i=0; i<Checks.getAllChecks().Count; i++){
                Checks.getAllChecks().get(i).levelchange(1);
            }
        }/* else if getName().equals("Ascension"){

        }*/
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
        ChaturangaCards Shirham = new ChaturangaCards("King Shirham");
        ChaturangaCards Turk = new ChaturangaCards("The Turk");
        ChaturangaCards Coffers = new ChaturangaCards("Spanish Royal Coffers");
        ChaturangaCards Swiss = new ChaturangaCards("Swiss Gold Reserves");
        ChaturangaCards Gambler = new ChaturangaCards("The Gambler");
        ChaturangaCards Princess = new ChaturangaCards("The Princess");
        ChaturangaCards Time = new ChaturangaCards("Time");
        ChaturangaCards Pollution = new ChaturangaCards("Pollution");
        ChaturangaCards Magnetic = new ChaturangaCards("Magnetic");
    }


}
public class ChessvolutionCards:Consumables{
    private static List<ChessvolutionCards> allCVCards = new List<ChessvolutionCards>(); public static List<ChessvolutionCards> getAllCVCards() => allCVCards;
    private static List<ChessvolutionCards> visibleCVCards = new List<ChessvolutionCards>(); public static List<ChessvolutionCards> getVisibleCVCards() => visibleCVCards;
    Checks check;

    public ChessvolutionCards(string name, Checks check){
        base.Consumables(name);
        this.check = check;
        allCVCards.Add(this);
    }

    public Checks getCheck() => check;

    public static void consumeCVCard(ChessvolutionCards card){
        card.getCheck().levelchange(1);
        UserStats.setLastUsed(card);
    }

}

/*public class Tickets{Simply don't have time to implement this in the current time frame
    
    private static List<Tickets> T1all = new List<Tickets>();
    private static List<Tickets> available = new List<Tickets>();
    private static List<Tickets> T1bought = new List<Tickets>();

    private static List<Tickets> T2all = new List<Tickets>();
    private static List<Tickets> T2bought = new List<Tickets>();
    private string name;
    private Tickets upgraded; //for t1 tickets only

    public Tickets(string name,Tickets upgraded){//T1
        this.name = name;
        this.upgraded = upgraded;
        T1all.Add(this);
        available.Add(this);
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



}*/
/*public class SkipTag{ FOR THE SAKE OF GETTING THIS GAME DONE, I AM NOT IMPLEMENTING THIS RIGHT NOW
    string name;
    public SkipTag(string name){
        this.name = name;
    }
    public string effects(){

    }
}*/
public class Pack{ //Booster Packs Yay
    private string name="";
    private string item;
    private int type=0; //0: 1 of 3; 1: 1 of 5; 2: 2 of 5
    private int size=0; //size of pack
    private int choose=0; //number of cards chosen
    private int cost=0;
    private List<Consumables> inPack = new List<Consumables>(); 
    public Pack(string item, int type){
        this.item = item;
        this.type = type;

        if (type==0){
            name += "Normal ";
            cost = 4;
            size = 3;
            choose = 1;
        } else if (type==1){
            name += "Jumbo ";
            cost = 6;
            size = 5;
            choose = 1;
        } else if (type==2){
            name += "Mega ";
            cost = 8;
            size = 5
            choose = 2;
        }

        if (item.equals("MC")){
            name += "Master Pack";
        } else if (item.equals("CC")){
            name += "The Cards of Chess";
        } else if (item.equals("Chaturanga")){
            name += "Chaturanga Pack";
        } else if (item.equals("Piece")){
            name += "Piece Pack";
        } else if (item.equals("CV")){
            name += "Evolution Pack";
        }
        stuffPack();
    }
    public void stuffPack(){
        if (item.equals("MC")){
            for (int i=0; i<size; i++){
                inPack.Add(MasterCard.getAllCards().get(roll(MasterCard.getAllCards().Count)));
            }
        } else if (item.equals("CC")){
            for (int i=0; i<size; i++){
                inPack.Add(TheCardsofChess.getAllCoCCards().get(roll(TheCardsofChess.getAllCoCCards().Count)));
            }
        } else if (item.equals("Chaturanga")){
            for (int i=0; i<size; i++){
                inPack.Add(ChaturangaCards.getAllChaturangaCards().get(roll(ChaturangaCards.getAllChaturangaCards().Count)));
            }
        } else if (item.equals("Piece")){
            for (int i=0; i<size; i++){
                inPack.Add(Pieces.getAllPieces().get(roll(Pieces.getAllPieces().Count)));
            }
        } else if (item.equals("CV")){
            for (int i=0; i<size; i++){
                inPack.Add(ChessvolutionCards.getAllCVCards().get(roll(ChessvolutionCards.getAllCVCards().Count)));
            }
        }
    }
    public void openPack(){
        //display the consumables in pack
    }
    public void useInPack(int i){
        inPack[i].effects();
        inPack.RemoveAt(i);
        choose--;
        if (choose==0){
            closePack();
        }
    }
    public void closePack(){
        //close the menu
    }
}
}
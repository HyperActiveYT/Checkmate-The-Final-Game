namespace Checkmate_The_Final_Game.Chess_Mechanics{

using System;
using System.Collections;
using System.Collections.Generic;
public class MasterCard{

    private static List<MasterCard> allCards = new List<MasterCard>(); public static List<MasterCard> getAllCards() => allCards;
    private static List<MasterCard> heldCards = new List<MasterCard>(); public static List<MasterCard> getHeldCards() => heldCards;
    private static List<MasterCard> Common = new List<MasterCard>(); public static List<MasterCard> getCommon() => Common;
    private static List<MasterCard> Uncommon = new List<MasterCard>(); public static List<MasterCard> getUncommon() => Uncommon;
    private static List<MasterCard> Rare = new List<MasterCard>(); public static List<MasterCard> getRare() => Rare;
    private static List<MasterCard> Epic = new List<MasterCard>(); public static List<MasterCard> getEpic() => Epic;
    private static List<MasterCard> Legendary = new List<MasterCard>(); public static List<MasterCard> getLegendary() => Legendary;
    private string name; public string getName() => name;
    private bool disabled = false; public bool isDisabled() => disabled;

    private int basecost; public int getBaseCost() => basecost;
    private int cost; public int getCost() => cost;
    private int sellval; public int getSellVal() => sellval;
    private int rarity; /*0: Common, 1: Uncommon, 2: Rare, 3: Legendary*/ public int getRarity() => rarity;
    private Aura aura; public Aura getAura() => aura;
    private double[] scaling = new double[]{0,1,0,1}; public double[] getScaling() => scaling;
    
    public MasterCard(string name, int rarity, Aura aura){
        this.name = name;
        this.rarity = rarity;
        this.aura = aura;
        allCards.Add(this);
        if (rarity == 0){
            Common.Add(this);
            basecost = 4;
        } else if (rarity == 1){
            Uncommon.Add(this);
            basecost = 6;
        } else if (rarity == 2){
            Rare.Add(this);
            basecost = 10;
        } else if (rarity == 3){
            Legendary.Add(this);
            basecost = 20;
        }
        cost = basecost;
        sellval = cost/2;
    }

    public MasterCard(string name, int rarity){
        MasterCard(name, rarity, null);
    }
    
    public MasterCard(string name, int rarity, double scaling){
        MasterCard(name, rarity, null);
        this.scaling = scaling;
    }

    public static void createmasterCards(){
        createCommon();
        createUncommon();
        createRare();
        createLegendary();
    }

    public static void createCommon(){
        MasterCard FalN = new MasterCard("The False Knight", 0);
        MasterCard FalB = new MasterCard("The False Bishop", 0);
        MasterCard FalP = new MasterCard("The False Pawn", 0);
        MasterCard FalR = new MasterCard("The False Rook", 0);
        MasterCard FalQ = new MasterCard("The False Queen", 0);
        MasterCard TrueN = new MasterCard("The True Knight", 0);
        MasterCard TrueB = new MasterCard("The True Bishop", 0);
        MasterCard TrueP = new MasterCard("The True Pawn", 0);
        MasterCard TrueR = new MasterCard("The True Rook", 0);
        MasterCard TrueQ = new MasterCard("The True Queen", 0);
        //MasterCard NewHei = new MasterCard("New Heights", 0);
        MasterCard Ripped = new MasterCard("Ripper Card", 0);
        MasterCard OverT = new MasterCard("Overtime", 0);
        //MasterCard SacPie = new MasterCard("Sacrificial Piece", 0);
        MasterCard MinRule = new MasterCard("Minority Rule", 0, new double[]{0,1,0,1});
        MasterCard Choc = new MasterCard("Chocolate", 0, new double[]{100,1,0,1});//+points
        MasterCard TDL = new MasterCard("To Do List", 0);
        MasterCard MV75 = new MasterCard("75-Move Rule", 0);
        MasterCard Rep4 = new MasterCard("4-Move Repetition", 0);
        MasterCard Trophy = new MasterCard("The Trophy", 0);
        MasterCard CasDef = new MasterCard("Castle Defense", 0);
        MasterCard CasFort = new MasterCard("Castle Fortress", 0);
        MasterCard OneTwo = new MasterCard("One-Two", 0);
    }

    public static void createUncommon(){
        MasterCard TDofGG = new MasterCard("The Dagger of the Greater Good", 1);
        //MasterCard Student = new MasterCard("The Student", 1);
        MasterCard MonCom = new MasterCard("Monarcho-Communism", 1); 
        MasterCard JeanGate = new MasterCard("JeansGate", 1);
        MasterCard Darwin = new MasterCard("Charles Darwin", 1);
        //MasterCard EC = new MasterCard("Extra Check", 1);
        MasterCard Midas = new MasterCard("Midas", 1);
        //MasterCard Horde = new MasterCard("Horde", 1);
    }
    
    public static void createRare(){
        MasterCard ChessBook = new MasterCard("The Chess Books", 2); //copy ability of MC to its right
        MasterCard ChessTheory = new MasterCard("Chess Theory", 2); //copy ability of leftmost MC; MAKE SURE IT DOESN'T INFINILOOP
        /*MasterCard Harmon = new MasterCard("Beth Harmon", 2);//Increasee xmult by .5 for every Queen check you give
       // MasterCard Phiona = new MasterCard("Phiona Mutesi", 2);
       // MasterCard Waitzkin = new MasterCard("Josh Waitzkin", 2);
        MasterCard Petrosian = new MasterCard("Tigran Petrosian", 2);//exchange sac specifically*/
    }

    public static void createLegendary(){
        /*MasterCard Magnus = new MasterCard("Magnus Carlsen", 3);
        //Magnus: disable effect of every boss blind
        MasterCard Kasparov = new MasterCard("Garry Kasparov", 3);
        //Kasparov: Increase xmult by .025 for every "best move" you make
        MasterCard Fischer = new MasterCard("Bobby Fischer", 3);
        //Fischer: Increase xmult by .75 for every exchange sacrifice you make
       // MasterCard Nakamura = new MasterCard("Hikaru Nakamura", 3);
       // MasterCard Karpov = new MasterCard("Anatoly Karpov", 3);
       // MasterCard Capablanca = new MasterCard("Jose Capablanca", 3);
        MasterCard Alekhine = new MasterCard("Alexander Alekhine", 3, 1);//xmult
        //Alekhine: Increase xmult by .5 every time you give a check while down in evaluation
       // MasterCard Anand = new MasterCard("Viswanathan Anand", 3);*/
    }
    public static MasterCard clone(MasterCard m){
        MasterCard newcard = new MasterCard(m.getName(), m.getRarity(), m.getAura());
        newcard.disabled = m.isDisabled();
        newcard.basecost = m.getBaseCost();
        newcard.cost = m.getCost();
        newcard.sellval = m.getSellVal();
        newcard.scaling = m.getScaling();
        return newcard;
    }

    public static void setHand(List<MasterCard> hand){
        heldCards = hand;
    }

    public static void removeCard(MasterCard card){
        if (heldCards.Contains(card)){
            heldCards.Remove(card);
        } else {
            Console.WriteLine("You do not have that card");
        }
    }

    public static void addCard(MasterCard card){
        if (heldCards.Count<UserStats.getMaxMasterCardSlots()){
            heldCards.Add(card);
        } else {
            Console.WriteLine("You do not have enough slots for that card");
        }
    }

    public static int CardLocation(MasterCard card){
        for (int i=0; i<heldCards.Count; i++){
            if (heldCards[i].getName().equals(card.getName())){
                return i;
            }
        }
        return -1;
    }

    public string void MasterCardEffect(string timeframe, Pieces p){
        if (timeframe.equals("On Boss Select")){
            if (name.equals("75-Move Rule")){
                modifynumMoves(75);
            } else if (name.equals("4-Move Repetition")){
                modifynumMoves(4);
            } else if (name.equals("The Dagger of the Greater Good")){
                if (CardLocation(this)+1==heldCards.Count){
                } else {
                    scaling[2] += heldCards.get(CardLocation(this)+1).getSellVal()/2
                    removeCard(heldCards.get(CardLocation(this)+1));
                }
            }
        }
        if (timeframe.Equals("On Check")){
            if (name.equals("The False Knight")){
                if (p.getName().equals("Knight")){
                    Score.modifyscore(new int[]{0,1,6,1});
                }
            } else if (name.equals("The False Bishop")){
                if (p.getName().equals("Bishop")){
                    Score.modifyscore(new int[]{0,1,6,1});
                }
            } else if (name.equals("The False Pawn")){
                if (p.getName().equals("Pawn")){
                    Score.modifyscore(new int[]{0,1,10,1});
                }
            } else if (name.equals("The False Rook")){
                if (p.getName().equals("Rook")){
                    Score.modifyscore(new int[]{0,1,4,1});
                }
            } else if (name.equals("The False Queen")){
                if (p.getName().equals("Queen")){
                    Score.modifyscore(new int[]{0,1,3,1});
                }
            } else if (name.equals("The True Knight")){
                if (p.getName().equals("Knight")){
                    Score.modifyscore(new int[]{30,1,0,1});
                }
            } else if (name.equals("The True Bishop")){
                if (p.getName().equals("Bishop")){
                    Score.modifyscore(new int[]{30,1,0,1});
                }
            } else if (name.equals("The True Pawn")){
                if (p.getName().equals("Pawn")){
                    Score.modifyscore(new int[]{50,1,0,1});
                }
            } else if (name.equals("The True Rook")){
                if (p.getPieceName().equals("Rook")){
                    Score.modifyscore(new int[]{20,1,0,1});
                }
            } else if (name.equals("The True Queen")){
                if (p.getName().equals("Queen")){
                    Score.modifyscore(new int[]{15,1,0,1});
                }
            } else if (name.equals("New Heights")){
            } else if (name.equals("Ripped Card")){
                Random random = new Random();
                int val = random.Next(25);
                Score.modifyscore(new int[]{0,1,val,1});
            } else if (name.equals("Overtime")){
            } else if (name.equals("Sacrificial Piece")){
            } else if (name.equals("Minority Rule")){
                if (p.getPieceType()==1 || hasMonarchoCommunism()){
                    scaling = new double[]{0,1,0,1};
                } else if (p.getPieceType()==0){
                    scaling[2] ++;
                }       
                modifyscore(scaling)      
            } else if (name.equals("Chocolate")){
                modifyscore(scaling)
            } else if (name.equals("To Do List")){
            } else if (name.equals("The Trophy")){
            } else if (name.equals("Castle Defense")){
                if (p.getPieceType()==1 || hasMonarchoCommunism()){
                    modifyScore(new int[]{0,1,5,1});
                }
            } else if (name.equals("Castle Fortress")){
                if (p.getPieceType()==1 || hasMonarchoCommunism()){
                    modifyScore(new int[]{25,1,0,1});
                }
            } else if (name.equals("One-Two")){
            } else if (name.equals("Charles Darwin")){
                Random random = new Random();
                int val = random.Next(4);
                if (val==0){}
                    Checks.allChecks.get(willbeCheckType()).levelchange(1);
                }
            } else if (name.equals("Midas")){
                if (p.getPieceType()==1 || hasMonarchoCommunism()){
                    p.setEdition(Modifiers.AllEditions.get(1));
                }
            } else if (name.equals("The Dagger of the Greater Good")){
                modifyScore(scaling);
            } else if (name.equals("The Chess Books")){
                heldCards.get(CardLocation(this)+1).MasterCardEffect(timeframe,p);
            } else if (name.equals("Chess Theory")){
                heldCards.get(0).MasterCardEffect(timeframe,p);
            }
        return "";
    }

    public static void hasMonarchoCommunism(){
        for (int i=0; i<heldCards.Count; i++){
            if (heldCards[i].getName().equals("Monarcho-Communism")){
                return true;
            }
        }
    }

    

    public static void Main(string[] args){
        Pieces Knight = new Pieces({{0,1,0,1,0},{1,0,0,0,1},{0,0,0,0,0,},{1,0,0,0,1},{0,1,0,1,0}}, "Knight");
        WriteLine(Knight);
    }
}
}
namespace Checkmate_The_Final_Game.Chess_Mechanics{

/*public class Checks:Score{
    
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
        Checks Skewer = new Checks("Skewer Check", new int[]{10,2}, new int[]{15,1});
        Checks Fork = new Checks("Fork Check", new int[]{20,2}, new int[]{20,1});
        Checks Double = new Checks("Double Check", new int[]{30,3}, new int[]{20,2});
        Checks Discover = new Checks("Discovered Check", new int[]{30,4}, new int[]{30,3});
        Checks Promotion = new Checks("Promotion Check", new int[]{35,4}, new int[]{15,2});
        Checks Castle = new Checks("Castling Check", new int[]{60,7}, new int[]{30,3});
        Checks Cross = new Checks("Cross Check", new int[]{100,8}, new int[]{40,4});
        //Secret Checks Below:
        Checks EnPassant = new Checks("En Passant Check", new int[]{120,12}, new int[]{35,3});
        Checks OneDisambig = new Checks("Singly Disambiguated Check", new int[]{140,14}, new int[]{40,4});
        Checks TwoDisambig = new Checks("Doubly Disambiguated Check", new int[]{160,16}, new int[]{50,3});
        
        viewableChecks.Add(Direct);
        viewableChecks.Add(Skewer);
        viewableChecks.Add(Fork);
        viewableChecks.Add(Double);
        viewableChecks.Add(Discover);
        viewableChecks.Add(Promotion);
        viewableChecks.Add(Castle);
        viewableChecks.Add(Cross);
    }

    public void levelchange(int change){
        if (lvl+change<=0){
            change = 1-lvl;
        }
        lvl += change;
        score[0]+=change*addition[0];
        score[1]+=change*addition[1];
    }

}*/

public class Score{

    /*
Hand Sequence
When a hand is played, effects will activate in the following orders. (Some Jokers may have different parts trigger at different stages: for example,  Wee Joker gain chips 'on scored' and adds chips to total 'independently').

Boss blind effects: Boss blinds such as The Flint or The Arm will activate.

'On played' Jokers: Jokers that activate when a hand is played, and before any scoring happens. Examples include  Green Joker's scaling,  DNA, and  To Do List.
Played cards scoring: Cards played and scored activate from left to right. For each card, its effects activate in the following order:
Base effect (Chips): The card activates its base effect, giving the accorded amount of Chips. Bonus chips are included in this value.
Card Modifiers: Card modifiers activate in the following order: enhancements, then seals (currently only gold seal), then editions.

'On scored' Jokers: Jokers that activate on a played and scored card will activate their effects. When multiple Jokers are triggered by the same card, they activate from left to right. Examples include  Wee Joker's scaling,  Smiley Face, and  Triboulet.
Retriggers: Each retrigger repeats the previous activation sequence (from base effects to scored card dependent Jokers) one more time. Multiple retriggers stack additively. Red seal would go first, followed by retriggering Jokers from left to right.
Held in hand abilities: Cards in hand are checked from left to right if they can activate in-hand abilities. The sequence for each card is similar to scored cards.
Enhancement (Steel card): Currently Steel is the only card modifier to activate in-hand for each hand.

'On held' Jokers: Jokers that activate on cards still held in hand will activate their effects. When multiple Jokers are triggered by a single card, they activate from left to right. Examples include  Raised Fist,  Shoot the Moon, and  Baron.
Retriggers: Same as those of scored cards, retriggers of cards in hand stack additively. Red seal will activate first, then  Mime and any other Joker copying its effect from left to right.
Joker Editions and 'Independent' Jokers: Jokers are checked from left to right to score any Edition (foil, holographic and polychrome) and activate Independent abilities:
Foil or holographic bonus.

'Independent' Jokers: Jokers that trigger after all the playing cards are scored will activate their base ability. These do not get affected by retriggers. Examples include  Fortune Teller,  The Duo, and  Blackboard.
Jokers dependent on other Jokers (currently, only  Baseball Card).
Polychrome bonus.

Consumables: When the  Observatory Voucher has been purchased, planet cards give X1.5 Mult, activating from left to right.
Plasma Deck balance: Lastly, if using the  Plasma Deck, Chips and Mult are balanced.
    */
private static int[] score = new int[2];
private static int finalscore = 0;
private static List<Pieces> involvedPieces = new List<Pieces>(); public static List<Pieces> getInvolvedPieces() => involvedPieces;
public static void addInvolvedPiece(Pieces p){
    involvedPieces.Add(p);
}
public static void clearInvolvedPieces(){
    involvedPieces.Clear();
}

public static void CalculateScore(){
    //Played Check
    Bosses.getCurrentBoss().Bosseffect("On Check");
    for (int i=0; i<getInvolvedPieces().Count; i++){
        mofidyScore(getInvolvedPieces()[i].getPtscore());
        getInvolvedPieces()[i].EditionEffects("On Check");
        getInvolvedPieces()[i].AuraEffects("On Check");
        for (int j=0; j<MasterCard.getHeldCards().Count; j++){
            MasterCard.getHeldCards()[j].MasterCardEffect("On Check", getInvolvedPieces()[i]);
        }
        getInvolvedPieces()[i].PieceEffect("On Check");
    }
    for (int i=0; i<Pieces.getYourPieces().Count; i++){
        Pieces.getYourPieces()[i].PieceEffect("On Check: In Hand");
        getInvolvedPieces()[i].PieceEffect("On Check");
    }
    finalscore += score;
    score = 0;
}

public static void modifyScore(int[] modify){
    score[0] += modify[0];
    score[0] *= modify[1];
    score[1] += modify[2];
    score[1] *= modify[3];
}
}
}
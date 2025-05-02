namespace Checkmate_The_Final_Game.Chess_Mechanics{
public class Main{

    public static void initializeGame(){
        Bosses.createBosses();
        Consumables.createCoCCards();
        Consumables.createChaturangaCards();
        Consumables.createCVCards();
        MasterCard.createMasterCards();
        Modifiers.createHeads();
        Modifiers.createEditions();
        Modifiers.createAuras();
        Modifiers.createPieces();
        Bosses.randomselectBoss();
        Game.initiateGame();
    }
    public static void Main(string[] args){

    }
}
}
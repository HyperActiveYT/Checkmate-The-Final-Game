namespace CtFG{
public class MasterCard{
    private string name;
    /*
    When Do Cards Trigger?
    On Opponent Select
    Pre-Scoring
    Scoring Pieces
    Effects on Board
    Master Card Scoring
        Split: Edition, then Card
    End of Game Select
    */
    private int[] effects;
    /*
    0: On Boss Select
    1: On Discard/Capture
    2: On Scoring/Checking
    3: On End of Game
    */ 
    
    public MasterCard(string name, int[] effects){
        this.name = name;
        this.effects = effects;
    }

    public static void Main(string[] args){
        Pieces Knight = new Pieces({{0,1,0,1,0},{1,0,0,0,1},{0,0,0,0,0,},{1,0,0,0,1},{0,1,0,1,0}}, "Knight");
        WriteLine(Knight);
    }
}
}
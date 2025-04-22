namespace Checkmate_The_Final_Game.Chess_Mechanics{
public class Tournament{

    private static final long[] baseptreq = new long[]{50, 100, 250, 750, 3000, 7500, 15000
    , 40000, 125000, 375000, 1500000, 150000000, 1000000000};

    private static int Tourneynum = 1;
    private static long basept = 50;

    public static void setptbase(){
        basept = baseptreq[Tourneynum];
    }

    private static int gamenum = 1;

}
}
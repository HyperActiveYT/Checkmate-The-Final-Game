namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
//using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVisualizer : MonoBehaviour
{
    public Bosses boss; // Reference to the Boss object
    public GameObject bossModel; // The 3D model or sprite for visualization

    // Initialize with a boss
    public void Initialize(Bosses boss)
    {
        this.boss = boss;
        SetBossModel();
    }

    // Set the corresponding boss model
    private void SetBossModel()
    {
        string bossName = boss.name; // Assuming you have models or sprites named after the boss (e.g., "The Punisher")
        bossModel = Resources.Load<GameObject>("Bosses/" + bossName); // Assuming models are stored under Resources/Bosses/

        if (bossModel != null)
        {
            Instantiate(bossModel, transform.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogError("Boss model not found for: " + bossName);
        }
    }

    // Update position (for movement)
    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
public class PieceVisualizer : MonoBehaviour
{
    public Pieces piece; // Reference to the corresponding Piece object
    public GameObject pieceModel; // The 3D model or sprite for visualization

    public void Initialize(Pieces piece)
    {
        this.piece = piece;
        SetPieceModel();
    }

    private void SetPieceModel()
    {
        string pieceAbbreviation = piece.getAbv(); 
        pieceModel = Resources.Load<GameObject>("Pieces/" + pieceAbbreviation); 

        if (pieceModel != null)
        {
            Instantiate(pieceModel, transform.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogError("Piece model not found for: " + pieceAbbreviation);
        }
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
public class TournamentManager : MonoBehaviour
{
    private static int tournNumber = 1;
    private static int gameNumber = 1;
    public static int getGameNumber() => gameNumber;
    
    private void Start()
    {
        InitializeTournament();
    }

    public static void opponentDefeated()
    {
        gameNumber++;
    }

    public static void opponentSkipped()
    {
        gameNumber++;
    }

    public static void bossDefeated()
    {
        gameNumber = 1;
        tournNumber++;
        UpdateBasePt();
        Bosses.randomSelectBoss();
    }

    private static void UpdateBasePt()
    {
        // Update the base points based on tournament number
        long basePt = Tournament.getBasePt();
        // Further logic to update the base points if necessary
    }

    private void InitializeTournament()
    {
        // Set up tournament and bosses at the start
        Bosses.createBosses(); // Initialize bosses
    }
}
public class PieceSpawner : MonoBehaviour
{
    public GameObject piecePrefab; // Reference to the piece prefab

    // Function to add a new piece to the board
    public void SpawnPiece(Pieces piece, Vector3 position)
    {
        GameObject pieceObject = Instantiate(piecePrefab, position, Quaternion.identity);
        PieceVisualizer visualizer = pieceObject.AddComponent<PieceVisualizer>();
        visualizer.Initialize(piece); // Link the visualizer to the piece
    }

    // Example function to add pieces based on boss effects
    public void AddPiecesForBossEffect(string bossName, int move, int[] square)
    {
        if (bossName == "The Crusader" && move % 10 == 0)
        {
            // Add Knights as per the effect
            Game.addPiece(new Knight(-1), square);
            Game.addPiece(new Knight(-1), new int[]{2, 1});
        }
    }
}
public class Tournament{

    private static final long[] baseptreq = new long[]{50, 100, 250, 750, 3000, 7500, 15000
    , 40000, 125000, 375000, 1500000, 150000000, 1000000000}; //there can exist a round 0, so first index is for round 0
    private static final int[] baseELO = new int[]{500, 700, 900, 1100, 1400, 1700, 2100, 2500, 3000}

    private static int Tourneynum = 1;
    private static long basept = baseptreq[Tourneynum]; public static long getBasePt() => basept;
    private static int baseELOnum = baseElonum[Tourneynum]; public static int getBaseELOnum() => baseELOnum;

    public static void setptbase(){
        basept = baseptreq[Tourneynum];
    }

    private static int gamenum = 1; public static int getGameNum() => gamenum;

    public static void opponentdefeated(){
        gamenum++;
    }
    public static void opponentskipped(){
        gamenum++;
    }
    public static void Bossdefeated(){
        gamenum=1;
        Tourneynum++;
        setptbase();
        Bosses.randomselectBoss();
    }

    public static boolean ActivateFailState(){
        for (int i=0; i<MasterCard.getHeldCards().Count; i++){
            if (MasterCard.getHeldCards()[i].getName().Equals("JeansGate")){
                if (4*getCurrentScore()>getScoreReq()){}
                    MasterCard.removeCard(MasterCard.getHeldCards()[i]);
                    return false;
                }
            }
        }
        HasFailed();
        return true;
    }
    public static void HasFailed(){
        UserStats.changeHASFAILED();
        //create the menu that pops up saying game over basically
    }

}

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
    private int defeatPrize; //amount of money given when defeated; 25 for final boss

    private static Bosses currentBoss; public static Bosses getCurrentBoss() => currentBoss;
    public static void randomselectBoss(){
        Random rand = new Random();
        int val = rand.Next(unseenRegularBoss.Count);
        currentBoss=unseenRegularBoss.get(val);
        makeBossSeen(currentBoss);
    }
    public static void makeBossSeen(Bosses boss){
        if (unseenRegularBoss.Contains(boss)){
            unseenRegularBoss.Remove(boss);
        }
        seenRegularBoss.Add(boss);
    }

    public Bosses(string name, int type){
        this.name = name;
        if (type == 0){
            RegularBoss.Add(this);
            unseenRegularBoss.Add(this);
            defeatPrize = 15;
        } else if (type == 1){
            FinalBoss.Add(this);
            unseenFinalBoss.Add(this);
            defeatPrize = 25;
        }
    }
    public static void createBosses(){
        createRegBosses();
        createFinBosses();
    }
    public static void createRegBosses(){
        //Bosses Clock = new Bosses("The Clock",0);
        //Bosses Wise = new Bosses("The Wise",0);
        Bosses Punisher = new Bosses("The Punisher",0);
        Bosses Creator = new Bosses("The Creator",0);
        Bosses Volcano = new Bosses("The Volcano",0);
        Bosses Atomizer = new Bosses("The Atomizer",0);
        Bosses Crusader = new Bosses("The Crusader",0);
        Bosses Inquisition = new Bosses("The Inquisition",0);
       // Bosses OneCheck = new Bosses("One-Check",0);
       // Bosses FiftyMove = new Bosses("The Fifty-Move Rule",0);
       // Bosses KotH = new Bosses("The High Ground",0);
        Bosses Stalingrad = new Bosses("Stalingrad",0):
        Bosses Revolution = new Bosses("Viva la Revolution",0);
       // Bosses RoyalCoup = new Bosses("Royal Coup",0);
       // Bosses Botez = new Bosses("Botez",0);
       // Bosses Stubborn = new Bosses("The Stubborn",0);
       // Bosses Various = new Bosses("The Various",0);
       // Bosses Taunter = new Bosses("The Taunter",0);
       // Bosses Medusa = new Bosses("Medusa",0);
       // Bosses DoubleAgent = new Bosses("Double Agent",0);
    }

    public static void createFinBosses(){
       // Bosses AI = new Bosses("AI",1);
       // Bosses Cheater = new Bosses("The Cheater",1);
       // Bosses Press = new Bosses("The Press",1);
       // Bosses ForceJedi = new Bosses("The Force of the Jedi",1);
       // Bosses Invincible = new Bosses("The Invincible",1);
        //Bosses Bossemony = new Bosses("Boss-emony",1);
    }

    public static void decMovesElapse(){
        moveselapsed--;
    }

    public void Bosseffect(string timeframe, int[] square, Pieces piece, int move){
        if (MasterCard.CardLocationstr("Magnus Carlsen")!=-1){
            break;
        }
        if (timeframe.Equals("On Boss Select")){
            /*if (name.Equals("The Clock")){
                time = 
            } else */if (currentBoss.name.Equals("The Wise")){
            } else if (currentBoss.name.Equals("The Crusader")){
                Game.addPiece(new Knight(-1),new int[]{2,0});
                Game.addPiece(new Knight(-1),new int[]{2,1});
                Game.addPiece(new Knight(-1),new int[]{2,6});
                Game.addPiece(new Knight(-1),new int[]{2,7});
            } else if (currentBoss.name.Equals("The Inquisition")){
                Game.addPiece(new Bishop(-1),new int[]{2,0});
                Game.addPiece(new Bishop(-1),new int[]{2,1});
                Game.addPiece(new Bishop(-1),new int[]{2,6});
                Game.addPiece(new Bishop(-1),new int[]{2,7});
            }
        } else if (timeframce.equals("On Move")){
            if (currentBoss.name.Equals("The Punisher")){
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
            } else if (currentBoss.name.Equals("The Creator" && move%10 == 0)){
                Random rand = new Random();
                int num = rand.Next(6);
                Pieces p = Pieces.getAllPieces()[num];
                while (true){
                int rank = rand.Next(8);
                int file = rand.Next(8);
                if (getBoard()[rank][file] == null){
                    Board.AddPiece(p, new int[]{rank,file});
                    break;
                }
            } else if (currentBoss.name.equals("Stalingrad") && 15<move && move<=25){
                if (getBoard()[square[0]][square[1]] == null || getBoard()[square[0]][square[1]].getColor() == -1){
                    ActivateFailState();
                }
            }
            /*} else if (currentBoss.name.Equals("The Volcano")){*/
        } else if (timeframe.equals("On Captured")){
            if (currentBoss.name.Equals("The Atomizer")){
                for (int i=Math.min(0,square[0]-1); i<=Math.max(7,square[0]+1); i++){
                    for (int j=Math.min(0,square[1]-1); j<=Math.max(7,square[1]+1); j++){
                        if (i!=square[0] && j!=square[1]){
                            Pieces p = futureboard[i][j];
                            if (p != null || !p.getPieceType.equals("Pawn")){
                                Pieces.Captured(p);
                                futureboard[i][j] = null;
                            }
                        }
                    }
                }
            } else if (currentBoss.name.Equals("The Press")){
                //welp
            }
        } else if (timeframe.equals("On Check")){
            //welp didn't get to this in time. It's fine...
        }
    }

}
}
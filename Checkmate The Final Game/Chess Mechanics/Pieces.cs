namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceVisualizer : MonoBehaviour
{
    public Pieces piece; // Reference to the corresponding Piece object
    public GameObject pieceModel; // The 3D model or sprite for visualization

    // Initialize with a piece
    public void Initialize(Pieces piece)
    {
        this.piece = piece;
        SetPieceModel();
    }

    // Set the corresponding piece model
    private void SetPieceModel()
    {
        // Load the model or sprite for the piece
        string pieceAbbreviation = piece.getAbv(); // Assuming you have models or sprites named after the abbreviation (e.g., "P" for Pawn)
        pieceModel = Resources.Load<GameObject>("Pieces/" + pieceAbbreviation); // Assuming models are stored under Resources/Pieces/

        if (pieceModel != null)
        {
            Instantiate(pieceModel, transform.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogError("Piece model not found for: " + pieceAbbreviation);
        }
    }

    // Update position (for movement)
    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}

public class ChessManager : MonoBehaviour
{
    private Dictionary<string, GameObject> pieceObjects = new Dictionary<string, GameObject>();
    public GameObject piecePrefab; // Base prefab for pieces (an empty GameObject or model to instantiate)

    // Start is used to create the initial pieces (e.g., at game start)
    void Start()
    {
        CreateAllPieces(); // Call your existing function to create pieces in the game logic
    }

    // Create a piece and visualize it using GameObject
    public void CreatePiece(Pieces piece, Vector3 position)
    {
        // Create a new GameObject for the piece (this will hold the visual representation)
        GameObject pieceObj = Instantiate(piecePrefab, position, Quaternion.identity);
        pieceObjects.Add(piece.getName(), pieceObj);

        // Add the PieceVisualizer component to the GameObject
        PieceVisualizer visualizer = pieceObj.AddComponent<PieceVisualizer>();
        visualizer.Initialize(piece); // Link the visualizer to the piece logic
    }

    // Update piece position on the board
    public void MovePiece(Pieces piece, Vector3 newPosition)
    {
        if (pieceObjects.ContainsKey(piece.getName()))
        {
            GameObject pieceObj = pieceObjects[piece.getName()];
            PieceVisualizer visualizer = pieceObj.GetComponent<PieceVisualizer>();
            visualizer.UpdatePosition(newPosition); // Update the visual position in Unity
        }
    }

    // Example function to create all pieces (called from the Pieces class)
    private void CreateAllPieces()
    {
        // You already have this in your existing code, but we will now call CreatePiece for Unity
        // Example: Create a white pawn at position (0, 0, 0)
        foreach (var piece in Pieces.getAllPieces())
        {
            Vector3 initialPosition = new Vector3(0, 0, 0); // Position this however you like (e.g., based on chessboard coordinates)
            CreatePiece(piece, initialPosition);
        }
    }
}

public class PieceMovement : MonoBehaviour
{
    private ChessManager chessManager;

    void Start()
    {
        chessManager = FindObjectOfType<ChessManager>(); // Find the ChessManager in the scene
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to move pieces
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                Vector3 clickedPosition = hit.point;

                // Move the piece if it's selected
                if (clickedObject.GetComponent<PieceVisualizer>() != null)
                {
                    Pieces selectedPiece = clickedObject.GetComponent<PieceVisualizer>().piece;
                    chessManager.MovePiece(selectedPiece, clickedPosition); // Move piece to new position
                }
            }
        }
    }
}

public class Pieces{
    private string name; public string getName() => name;
    private string moves; public string getMoves() => moves; //Unnecessary for now since we abaondoned fairy-stockfish
    private string abv; public string getAbv() => abv;
    private string color;/*1=white, -1=black*/ public string getColor() => color;
    private double[] ptscore = new double[4]; public string getPtscore() => ptscore;
    //0: +pts; 1: xpts; 2: +mult; 3: xmult

    private int piecetype; public int getPieceType() => piecetype;
    
    private int buycost=0; public int getBuyCost() => buycost;
    private int rebuycost=0; public int getRebuyCost() => rebuycost;

    private Heads head; public string getHead() => head;
    private Editions edition; public string getEdition() => edition;
    private Aura aura; public string getAura() => aura;
    private static List<Pieces> YourPieces = new List<Pieces>(); public static List<Pieces> getYourPieces() => YourPieces;
    public static void addYourPiece(Pieces p){
        YourPieces.Add(p);
    }
    public static void removeYourPiece(Pieces p){
        YourPieces.Remove(p);
    }
    private static List<Pieces> YourCapturedPieces = new List<Pieces>(); public static List<Pieces> getYourCapturedPieces() => YourCapturedPieces;
    public static void addYourCapturedPiece(Pieces p){
        YourCapturedPieces.Add(p);
    }
    public static void removeYourCapturedPiece(Pieces p){
        YourCapturedPieces.Remove(p);
    }

    public static void Captured(Pieces p){
        YourCapturedPieces.Add(p);
        YourPieces.Remove(p);
    }
    public static void Rebought(Pieces p){
        YourPieces.Add(p);
        YourCapturedPieces.Remove(p);
    }
    private static List<Pieces> AllPieces = new List<Pieces(); public static List<Pieces> getAllPieces() => AllPieces;


    public Pieces(string name, string moves, string abv, string color, int piecetype, double[] ptscore, Heads head, Editions edition, Aura aura){
        this.name = name;
        this.moves = moves;
        this.abv = abv;
        this.color = color;
        this.piecetype = piecetype;
        this.ptscore = ptscore;
        //Modifiers
        this.head = head;
        this.edition = edition;
        this.aura = aura;
        buycost = ptscore[0];
        rebuycost = buycost/2;
    }

    public static Pieces copyPiece(Pieces p){
        Pieces newpiece = new Pieces(p.getName(), p.getMoves(), p.getAbv(), p.getColor(), p.getPieceType(), p.getPtscore(), p.getHead(), p.getEdition(), p.getAura());
        return newpiece;
    }
    //Modifiers
    public void setHead(Heads head){
        if (this.head != null){
            buycost -= this.head.getHeadCost();
        }
        this.head = head;
        buycost += head.getHeadCost();
        changeRebuyCost();
    }
    public void setEdition(Editions edition){
        if (this.edition != null){
            buycost -= this.edition.getEditiionCost();
        }
        this.edition = edition;
        buycost += edition.getEditiionCost();
        changeRebuyCost();
    }
    public void setAura(Aura aura){
        if (this.aura != null){
            buycost -= this.aura.getAuraCost();
        }
        this.aura = aura;
        buycost += aura.getAuraCost();
        changeRebuyCost();
    }

    public void changeRebuyCost(){
        rebuycost = buycost/2;;
    }

    //Rebuy Mechanics
    

    public static void createAllPieces(){
        Pawn p = new Pawn(1);
        Knight n = new Knight(1);
        Bishop b = new Bishop(1);
        Rook r = new Rook(1);
        Queen q = new Queen(1);
        King k = new King(1);
        /*Crusader c = new Crusader(1);
        Viking v = new Viking(1);
        RoyalGuard g = new RoyalGuard(1);
        Cannon o = new Cannon(1);
        Musketeer m = new Musketeer(1);
        Unicorn u = new Unicorn(1);
        Archbishop a = new Archbishop(1);
        Cardinal d = new Cardinal(1);
        MountedKing o = new MountedKing(1);
        Pegasus s = new Pegasus(1);
        WarWagon w = new WarWagon(1);
        Templar t = new Templar(1);
        Beserker e = new Beserker(1);
        Dragon f = new Dragon(1);*/
        AllPieces.Add(p);
        AllPieces.Add(n);
        AllPieces.Add(b);
        AllPieces.Add(r);
        AllPieces.Add(q);
        AllPieces.Add(k);
        /*AllPieces.Add(c);
        AllPieces.Add(v);
        AllPieces.Add(g);
        AllPieces.Add(o);
        AllPieces.Add(m);
        AllPieces.Add(u);
        AllPieces.Add(a);
        AllPieces.Add(d);
        AllPieces.Add(o);
        AllPieces.Add(s);
        AllPieces.Add(w);
        AllPieces.Add(t);
        AllPieces.Add(e);
        AllPieces.Add(f);*/
    }

}

public class Pawn:Pieces{
    public Pawn(string color, double[] ptscore){
        base.("Pawn","fmWfceFifmnD", "P", color, 0, ptscore,null,null,null)
    }
    public Pawn(string color){
        Pawn(color, new double[]{1,0,0,0});
    }
}

public class Knight:Pieces{
    public Knight(string color, double[] ptscore){
        base.("Knight","N", "N", color, 0, ptscore,null,null,null);
    }
    public Knight(string color){
        Knight(color, new double[]{3,0,0,0});
    }
}

public class Bishop:Pieces{
    public Bishop(string color, double[] ptscore){
        base.("Bishop","B", "B", color, 0, ptscore,null,null,null);
    }
    public Bishop(string color){
        Bishop(color, new double[]{3,0,0,0});
    }
}

public class Rook:Pieces{
    public Rook(string color, double[] ptscore){
        base.("Rook","R", "R", color, 1, ptscore,null,null,null);
    }
    public Rook(string color){
        Rook(color, new double[]{5,0,0,0});
    }
}

public class Queen:Pieces{
    public Queen(string color, double[] ptscore){
        base.("Queen","Q", "Q", color, 1, ptscore,null,null,null);
    }
    public Queen(string color){
        Queen(color, new double[]{9,0,0,0});
    }
}

public class King:Pieces{
    public King(string color, double[] ptscore){
        base.("King","K", "K", color, 1, ptscore,null,null,null);
    }
    public King(string color){
        King(color, new double[]{4,0,0,0});
    }
}

/*public class Crusader:Pieces{
    public Crusader(string color, double[] ptscore){
        base.("Crusader","fBbR", "C", color, "bishop", ptscore,null,null,null);
    }
    public Crusader(string color){
        Crusader(color, new double[]{3.5,0,0,0});
    }
}
public class Viking:Pieces{
    public Viking(string color, double[] ptscore){
        base.("Viking","R2B1", "V", color, "king", ptscore, null, null, null);
    }
    public Viking(string color){
        Viking(color, new double[]{4.75,0,0,0});
    }
}
public class RoyalGuard:Pieces{
    public RoyalGuard(string color, double[] ptscore){
        base.("Royal Guard","cQmK","G",color,"queen",ptscore,null,null,null);
    }
    public RoyalGuard(string color){
        Viking(color, new double[]{8,0,0,0});
    }
}

public class Cannon:Pieces{//I believe that this is already included in fairy stockfish
    public Cannon(string color, double[] ptscore){
        base.("Cannon","mRcpR","O",color,"rook",ptscore,null,null,null);
    }
    public Cannon(string color){
        Cannon(color, new double[]{5.5,0,0,0});
    }
}
public class Musketeer:Pieces{
    public Musketeer(string color, double[] ptscore){
        base.("Musketeer", "sRB1","M",color,"rook",ptscore,null,null,null);
    }
    public Musketeer(string color){
        Musketeer(color, new double[]{4.5,0,0,0});
    }
}
public class Unicorn:Pieces{//I believe that this is already included in fairy stockfish
    public Unicorn(string color, double[] ptscore){
        base.("Unicorn", "RN", "U",color,"rook",ptscore,null,null,null);
    }
    public Unicorn(string color){
        Unicorn(color, new double[]{8,0,0,0});
    }
}
public class Archbishop:Pieces{//I believe that this is already included in fairy stockfish
    public Archbishop(string color, double[] ptscore){
        base.("Archbishop","BN","A",color,"bishop",ptscore,null,null,null);
    }
    public Archbishop(string color){
        Archbishop(color, new double[]{7.5,0,0,0});
    }
}
public class Cardinal:Pieces{
    public Cardinal(string color,double[] ptscore){
        base.("Cardinal","BK","C",color,"bishop",ptscore,null,null,null);
    }
    public Cardinal(string color){
        Cardinal(color,new double[]{3.5,0,0,0});
    }
}
public class MountedKing:Pieces{
    public MountedKing(string color, double[] ptscore){
        base.("Mounted King","NK","M",color,"king",ptscore,null,null,null);
    }
    public MountedKing(string color){
        MountedKing(color, new double[]{5,0,0,0})
    }
}
public class Pegasus:Pieces{
    public Pegasus(string color, double[] ptscore){
        base.("Pegasus Rider","N2","S",color,"knight",ptscore,null,null,null);
    }
    public Pegasus(string color){
        Pegasus(color,new double[]{5,0,0,0});
    }
}
public class WarWagon:Pieces{
    public WarWagon(string color, double[] ptscore){
        base.("War Wagon","RK","W",color,"rook",ptscore,null,null,null);
    }
    public WarWagon(string color){
        WarWagon(color,new double[]{6,0,0,0});
    }
}
public class Templar:Pieces{
    public Templar(string color, double[] ptscore){
        base.("Templar","BvR","T",color,"bishop",ptscore,null,null,null);
    }
    public Templar(string color){
        Templar(color,new double[]{6,0,0,0});
    }
}
public class Beserker:Pieces{
    public Beserker(string color, double[] ptscore){
        base.("Beserker","R3NK","B",color,"rook",ptscore,null,null,null);
    }
    public Beserker(string color){
        Beserker(color,new double[]{5,0,0,0});
    }
}
public class Dragon:Pieces{
    public Dragon(string color, double[] ptscore){
        base.("Dragon","BR3","F",color,"bishop",ptscore,null,null,null);
    }
    public Dragon(color){
        Dragon(color,new double[]{4,0,0,0})
    }
}*/



}


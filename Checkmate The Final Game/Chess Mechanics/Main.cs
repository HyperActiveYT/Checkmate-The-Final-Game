namespace Checkmate_The_Final_Game.Chess_Mechanics{
public class Main{
    public static void Main(string[] args){
        // Create a new game
        Game game = new Game();
        
        // Create pieces
        Pieces knight = new Knight(1, 3.0);
        Pieces bishop = new Bishop(1, 3.0);
        Pieces pawn = new Pawn(1, 1.0);
        
        // Add pieces to the game
        game.AddPiece(knight);
        game.AddPiece(bishop);
        game.AddPiece(pawn);
        
        // Display the game state
        game.Display();
    }
}
}
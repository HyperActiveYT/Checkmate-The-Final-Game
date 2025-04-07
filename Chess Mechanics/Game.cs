namespace CtFG{
public class Game:Tournament{

    public Game(){
        Board board = new Board();
    }

    public Game(Pieces[][] p){
        Board board = new Board(p);
    }

    public void move(){
        P/invoke StateMachine::ponder();
    }


}
}
namespace CtFG{
public class Game:Tournament{

    private 

    public Game(){
        createBoardBase()
    }

    public Game(Pieces[][] p){
        createBoard(p);
    }

    public void move(){
        P/invoke StateMachine::ponder();
    }


}
}
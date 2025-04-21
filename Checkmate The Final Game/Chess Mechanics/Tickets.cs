/*namespace CtFG{

using System;
using System.Collections;
using System.Collections.Generic;
public class Tickets{
    
    private static List<Tickets> T1all = new List<Tickets>();
    private static List<Tickets> T1available = new List<Tickets>();
    private static List<Tickets> T1bought = new List<Tickets>();

    private static List<Tickets> T2all = new List<Tickets>();
    private static List<Tickets> T2available = new List<Tickets>();
    private static List<Tickets> T2bought = new List<Tickets>();
    private string name;
    private Tickets upgraded; //for t1 tickets only

    public Tickets(string name,Tickets upgraded){//T1
        this.name = name;
        this.upgraded = upgraded;
        T1all.Add(this);
        T1available.Add(this);
    }

    public Tickets(string name){//T2
        this.name = name;
        upgraded = null;
        T2all.Add(this);
    }

    public static string CreateT2Tickets(){
        Tickets Comm = new Tickets("Commissioner");
        Tickets Emul = new Tickets("Emulator");
        Tickets Skynet = new Tickets("Skynet's Time Displacement Equipment");
        Tickets IceAge = new Tickets("Ice Age");
        Tickets Hack = new Tickets("Hacker");
        Tickets Manufac = new Tickets("Manufacturer");
        Tickets Stash = new Tickets("Stasher");
        Tickets Theory = new Tickets("Check Theorist");
        Tickets Mateth = new Tickets("Mate-thusiast");
        Tickets Pawnth = new Tickets("Pawn-thusiast");
        Tickets ProdAsh = new Tickets("Prodigy from the Ashes");
        Tickets Corp = new Tickets("Corporate");
        Tickets Crip = new Tickets("The Crippler");
    }

    public static string CreateTickets(){
        CreateT2Tickets();
        Tickets Coll = new Tickets("Collector",Comm);
        Tickets Copy = new Tickets("Copier",Emul);
        Tickets Time = new Tickets("Time Machine",Skynet);
        Tickets Cryo = new Tickets("Cryogenics",IceAge)
        Tickets BkEnd = new Tickets("Backend", Hack);
        Tickets Dist = new Tickets("Distributor",Manufac);
        Tickets Gult = new Tickets("Glutton",Stash);
        Tickets Psych = new Tickets("Chess Psychic",Theory);
        Tickets Checkth = new Tickets("Check-thusiast",Mateth);
        Tickets Moveth = new Tickets("Move-thusiast",Pawnth);
        Tickets Empty = new Tickets("Empty Score Sheet",ProdAsh);
        Tickets Trad = new Tickets("Trader",Corp);
        Tickets Disab = new Tickets("The Disabler",Crip);
    }

    public void effects(){
        
    }



}
}
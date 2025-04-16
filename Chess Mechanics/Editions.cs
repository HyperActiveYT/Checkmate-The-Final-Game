namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;
public class Editions{

    private string name;

    private static List<Editions> AllEditions = new List<Editions>();
    public Editions(string name){
        this.name = name;
        AllEditions.Add(this);
    }

    public static void effects(){
        
    }

}
}
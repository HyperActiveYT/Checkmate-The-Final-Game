/*namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;
public class ChaturangaCards{ //Equivalent of Tarot Cards

    private string name;
    private static int consumableslots = 2;

    private static List<ChaturangaCards> AllChaturangaCards = new List<ChaturangaCards>();

    public ChaturangaCards(string name){//
        this.name = name;
        AllChaturangaCards.Add(this);
    }


}
}
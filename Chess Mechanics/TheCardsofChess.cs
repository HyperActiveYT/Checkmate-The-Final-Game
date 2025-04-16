namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;
public class TheCardsofChess{

    private static List<TheCardsofChess> AllCoCCards = new List<TheCardsofChess>();

    private string name;

    public TheCardsofChess(string name){ //Equivalent of Spectral Cards
        this.name = name;
        AllCoCCards.Add(this);
    }

    public static void createCoCCards()[
        TheCardsofChess Sac = new TheCardsofChess("Sacrifice!");
        TheCardsofChess Skip = new TheCardsofChess("Skipper");
        TheCardsofChess Tal = new TheCardsofChess("Talent");
        TheCardsofChess Gold = new TheCardsofChess("Gold");
        TheCardsofChess Apoc = new TheCardsofChess("Apcoalypse");
        TheCardsofChess Royal = new TheCardsofChess("Royalty");
        TheCardsofChess Greed = new TheCardsofChess("Greed");
        TheCardsofChess Double = new TheCardsofChess("Double Trouble");
        TheCardsofChess Cassia = new TheCardsofChess("Cassia the God of Chess");
        TheCardsofChess Ascen = new TheCardsofChess("Ascension");
    ]

}
}
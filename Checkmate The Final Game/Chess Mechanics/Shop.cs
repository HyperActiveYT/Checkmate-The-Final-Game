namespace Checkmate_The_Final_Game.Chess_Mechanics{
using System;
using System.Collections;
using System.Collections.Generic;
public class Shop{
    
    private static double PieceWeight=4; //0
    private static double MasterCardWeight = 20; //1
    private static double ChessEVWeight = 4; //2
    private static double ChatarangaCardWeight = 4; //3
    private static List<> InShop = new List<>();
    private static List<Pack> BoosterPacks = new List<Pack>();


    private static int basererollcost=5;

    private static int rerollcost=basererollcost;

    public static void createShop(){
        Random rand = new Random();
        double TotWeight = PieceWeight+MasterCardWeight+ChessEVWeight+ChatarangaCardWeight;
        for (int i=0; i<slot;i++){
            int item = roll(TotWeight);
            if (item==0){
                int val = rand.Next(Pieces.getAllPieces().Count);
                InShop.Add(Pieces.getAllPieces()[val]);
            } else if (item==1){
                int val = rand.Next(MasterCard.getAllCards().Count);
                InShop.Add(MasterCard.getAllCards()[val]);
            } else if (item==2){
                int val = rand.Next(ChessEV.getAllCards().Count);
                InShop.Add(ChessEV.getAllCards()[val]);
            } else if (item==3){
                int val = rand.Next(ChaturangaCard.getAllCards().Count);
                InShop.Add(ChaturangaCard.getAllCards()[val]);
            }
        }
        BoosterPacks.Add(Pack.createRandomPack());
        BoosterPacks.Add(Pack.createRandomPack());
    }
    public static void reroll(){
        Random rand = new Random();
        double TotWeight = PieceWeight+MasterCardWeight+ChessEVWeight+ChatarangaCardWeight;
        for (int i=0; i<slot;i++){
            int item = roll(TotWeight);
            if (item==0){
                int val = rand.Next(Pieces.getAllPieces().Count);
                InShop.Add(Pieces.getAllPieces()[val]);
            } else if (item==1){
                int val = rand.Next(MasterCard.getAllCards().Count);
                InShop.Add(MasterCard.getAllCards()[val]);
            } else if (item==2){
                int val = rand.Next(ChessEV.getAllCards().Count);
                InShop.Add(ChessEV.getAllCards()[val]);
            } else if (item==3){
                int val = rand.Next(ChaturangaCard.getAllCards().Count);
                InShop.Add(ChaturangaCard.getAllCards()[val]);
            }
        }
    }
    public static void closeShop(){
        InShop.Clear();
        BoosterPacks.Clear();
    }

    public static int roll(double TotWeight){
        Random rand = new Random();
        int val = rand.Next(TotWeight);
        if (val<PieceWeight){
            return 0;
        } else if (PieceWeight<=val && val<MasterCardWeight+PieceWeight){
            return 1;
        } else if (MasterCardWeight+PieceWeight<=val && val<MasterCardWeight+PieceWeight+ChessEVWeight){
            return 2;
        } else if (MasterCardWeight+PieceWeight+ChessEVWeight<=val && val<TotWeight){
            return 3;
        }
    }

    public static void setweight(string type, double weight){
        if (type.equals("Piece")){
            PieceWeight = weight;
        } else if (type.equals("MasterCard")){
            MasterCardWeight = weight;
        } else if (type.equals("ChessEV")){
            ChessEVWeight = weight;
        } else if (type.equals("ChaturangaCard")){
            ChatarangaCardWeight = weight;
        }
    }


}
}
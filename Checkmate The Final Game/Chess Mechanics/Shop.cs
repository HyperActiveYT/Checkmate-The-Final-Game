namespace CtFG{
using System;
using System.Collections;
using System.Collections.Generic;
public class Shop{
    

    private static slot = 2; //number of slots available in shop
    private static double PieceWeight=0; //0
    private static double MasterCardWeight = 20; //1
    private static double ChessEVWeight = 4; //2
    private static double ChatarangaCardWeight = 4; //3
    private static double 
    private static List<> InShop = new List<>();


    private static int basererollcost=5;

    private static int rerollcost=basererollcost;

    public static void createShop(){
        double TotWeight = PieceWeight+MasterCardWeight+ChessEVWeight+ChatarangaCardWeight;
        for (int i=0; i<slot;i++){
            if (roll(TotWeight)==0){
                
            }
        }
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


}
}
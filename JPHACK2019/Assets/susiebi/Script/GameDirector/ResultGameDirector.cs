using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultGameDirector : MonoBehaviour
{
    public string winnerName;
    
    // Update is called once per frame
    void Update()
    {
        DetermineWinner();
    }

    //  誰が勝ったか判定。
     void DetermineWinner()
     {
         int winner=PlayerPrefs.GetInt("winner");
         if(winner==0) winnerName="PlayerA"; //  Aの勝利
         else{winnerName="PlayerB";}  //  Bの勝利
     }
}

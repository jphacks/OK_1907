using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenB_Target : ParentTarget
{
    public ChildrenA_Player childrenA_Player;
   
    //  Aプレイヤーの剣が当たったらAプレイヤーに１ポイント。
   public void OnCollisionEnter(Collision collision)
    {   
        Debug.Log("hitA");
        if(gameDirector.countIsFinished==false&&gameDirector.tutorialIsFinished==false) {
             targetIsCrashd = true;
             meshRenderer.enabled = false;
             return;//  カウントダウン中の処理。
        } 
        if(collision.gameObject.tag=="SwordA" && !targetIsCrashd) 
        {
            //  ポイント加算
            targetIsCrashd=true;
            meshRenderer.enabled=false; //ターゲット破壊（ターゲットを見えなくしてるだけでDestroyしてない。）
            collider.enabled = false;
            childrenA_Player.playerPoints++;
            
            // エフェクト生成。
            GameObject cloneEffect;
            cloneEffect=Instantiate(effectPrefab,transform.position,transform.rotation); 
            Debug.Log("poitn");
            Destroy(cloneEffect,3f);
        }
    }
}

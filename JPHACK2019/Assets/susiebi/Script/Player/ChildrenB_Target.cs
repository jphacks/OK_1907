using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenB_Target : ParentTarget
{
    public ChildrenA_Player childrenA_Player;
   
    // Update is called once per frame
    void Update()
    {
        
    }
    //  Aプレイヤーの剣が当たったらAプレイヤーに１ポイント。
    public override void OnCollisionEnter(Collision collision)
    {
        if(gameDirector.countIsFinished==false&&gameDirector.tutorialIsFinished==true) return;
        if(collision.gameObject.tag=="SwordA") 
        {
            //  ポイント加算
            targetIsCrashd=true;
            meshRenderer.enabled=false; //ターゲット破壊（ターゲットを見えなくしてるだけでDestroyしてない。）
            childrenA_Player.playerPoints++;

            // エフェクト生成。
            GameObject cloneEffect;
            cloneEffect=Instantiate(effectPrefab,transform.position,transform.rotation); 
            Destroy(cloneEffect,3f);
        }
    }
}

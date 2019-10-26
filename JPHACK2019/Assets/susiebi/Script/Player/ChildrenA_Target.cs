using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenA_Target : ParentTarget
{
    public ChildrenB_Player childrenB_Player;

    // Update is called once per frame
    void Update()
    {
        
    }
    //  Bプレイヤーの剣が当たったらBプレイヤーに１ポイント。
    public override void OnCollisionEnter(Collision collision)
    {
        if(gameDirector.countIsFinished==false&&gameDirector.tutorialIsFinished==true) return;//  カウントダウン中の処理。
        if(collision.gameObject.tag=="SwordB") 
        {
            //  ポイント加算
            targetIsCrashd=true;
            meshRenderer.enabled=false; //ターゲット破壊（ターゲットを見えなくしてるだけでDestroyしてない。）
            childrenB_Player.playerPoints++;
            
            // エフェクト生成。
            GameObject cloneEffect;
            cloneEffect=Instantiate(effectPrefab,transform.position,transform.rotation); 
            Destroy(cloneEffect,3f);
        }
    }
}

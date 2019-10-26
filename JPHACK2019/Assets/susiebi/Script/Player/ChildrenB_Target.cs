using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenB_Target : ParentTarget
{
    public ChildrenA_Player childrenA_Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //  Aプレイヤーの剣が当たったらAプレイヤーに１ポイント。
    public override void OnCollisionEnter(Collision collision)
    {
        //if(gameDirector.countIsFinished==false) return;
        if(collision.gameObject.tag=="SwordA") 
        {
            targetIsCrashd=true;
            //meshRenderer.enabled=false; //ターゲット破壊（ターゲットを見えなくしてるだけでDestroyしてない。）
            Instantiate(effectPrefab,transform.position,transform.rotation); // エフェクト生成。
            childrenA_Player.playerPoints++;
            Destroy(gameObject);
        }
    }
}

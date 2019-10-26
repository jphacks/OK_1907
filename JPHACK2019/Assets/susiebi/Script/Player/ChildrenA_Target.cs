using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenA_Target : ParentTarget
{
    public ChildrenB_Player childrenB_Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //  Bプレイヤーの剣が当たったらBプレイヤーに１ポイント。
    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="SwordB") 
        {
            targetIsCrashd=true;
            //meshRenderer.enabled=false; //ターゲット破壊（ターゲットを見えなくしてるだけでDestroyしてない。）
            Instantiate(effectPrefab,transform.position,transform.rotation); // エフェクト生成。
            childrenB_Player.playerPoints++;
            Destroy(gameObject);

        }
    }
}

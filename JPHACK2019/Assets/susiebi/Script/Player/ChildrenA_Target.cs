using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenA_Target : ParentTarget {
    public ChildrenB_Player childrenB_Player;

    //  Bプレイヤーの剣が当たったらBプレイヤーに１ポイント。
    public void OnCollisionEnter (Collision collision) {
        Debug.Log ("hitB");
        if (gameDirector.countIsFinished == false && gameDirector.tutorialIsFinished == false) {
            targetIsCrashd = true;
            meshRenderer.enabled = false;
            return; //  カウントダウン中の処理。
        }
        if (collision.gameObject.tag == "SwordB" && !targetIsCrashd) {
            //  ポイント加算
            targetIsCrashd = true;
            meshRenderer.enabled = false; //ターゲット破壊（ターゲットを見えなくしてるだけでDestroyしてない。）
            collider.enabled = false;
            childrenB_Player.playerPoints++;

            // エフェクト生成。
            GameObject cloneEffect;
            cloneEffect = Instantiate (effectPrefab, transform.position, transform.rotation);
            Debug.Log ("poitn");
            Destroy (cloneEffect, 3f);
        }
    }
}
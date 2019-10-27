using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    public bool tutorialIsFinished = false;
    public bool countIsFinished = false; //  カウントダウンの判定用変数。
    public bool a_Point, b_Point;
    public TextMeshProUGUI CountDownText;
    public float toatleTime;
    public float CoundDownSeconds;

    [SerializeField] private int winPoints;
    [SerializeField] private Vector3 a_TargetAjuster;
    [SerializeField] private Vector3 b_TargetAjuster;
    public float countDownSeconds;

    public ParentPlayer A_Player; //  プレイヤー型のポイント変数
    public ParentPlayer B_Player; //  プレイヤー型のポイント変数

    public ParentTarget a_Target;
    public ParentTarget b_Target;
    private float countDown;
    void Start () {

    }

    void Update () {
        PlaysTutorialScene ();
        if (tutorialIsFinished == false) return;
        PlaysPlayScene ();
    }

    //  ゲームの開始判定。チュートリアルを終えたらスタート。
    void PlaysTutorialScene () {
        if (tutorialIsFinished == true) return;
        //  チュートリアル
        if (a_Target.targetIsCrashd && b_Target.targetIsCrashd) {
            //OnPlayScene=true;
            tutorialIsFinished = true;
            a_Target.targetIsCrashd = false;
            b_Target.targetIsCrashd = false;
        }
    }

    //  マッチの終了判定。
    void PlaysPlayScene () {
        if (countIsFinished == false) {
            CountDown ();
            return;
        }
        if (a_Target.targetIsCrashd || b_Target.targetIsCrashd) {
            a_Target.targetIsCrashd = false;
            b_Target.targetIsCrashd = false;
            EndsMatch ();
        }
    }

    //  
    void EndsMatch () {
        Debug.Log ("on");

        if (A_Player.playerPoints >= winPoints || B_Player.playerPoints >= winPoints) {
            // リザルトシーンに誰が勝ったかを伝える。
            if (A_Player.playerPoints >= winPoints) PlayerPrefs.SetInt ("winner", 0); //  Aの勝利
            else { PlayerPrefs.SetInt ("winner", 1); } //  Bの勝利

            SceneManager.LoadScene (1); //  リザルトシーンに移動。
        } else {

            // まだ３本先取されてないならPlaysPlayScene()へ
            countIsFinished = false;
        }
    }

    void CountDown () {
        countDown += Time.deltaTime;
        Debug.Log (countDown);

        if (countDown > countDownSeconds) {
            a_Target.meshRenderer.enabled = true;
            b_Target.meshRenderer.enabled = true;

            // カウンドダウンリセット。
            countIsFinished = true;
            countDown = 0;

            //  ターゲットを生成。
            //GameObject game1,game2;
            //Instantiate(a_Target,A_Player.transform.position+a_TargetAjuster,A_Player.transform.rotation);
            //Instantiate(b_Target,B_Player.transform.position+b_TargetAjuster,B_Player.transform.rotation);
            // カウンドダウンリセット。
        }
    }
}
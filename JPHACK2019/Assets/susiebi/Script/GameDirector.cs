using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [HideInInspector] public bool OnPlayScene, tutorialIsFinished;
    private bool countIsFinished;//  カウントダウンの判定用変数。
    float countDown; 
     private int A_PlayerPoints=0;//  プレイヤー型のポイント変数
     private int B_PlayerPoints=0;//  プレイヤー型のポイント変数
    public bool A_TragetIsCrashd;//  ターゲット型のターゲットbool
    public bool B_TragetIsCrashd;//  ターゲット型のターゲットbool
    void Start()
    {
        OnPlayScene=false;
        tutorialIsFinished=false;
        countIsFinished=false;
    }

    void Update()
    {
        PlaysTutorialScene();
        PlaysPlayScene();
    }

    //  ゲームの開始判定。チュートリアルを終えたらスタート。
    void PlaysTutorialScene()
    {
        if(tutorialIsFinished==true) {return;}

        //  チュートリアル
        if(A_TragetIsCrashd&&B_TragetIsCrashd)
        {
            //OnPlayScene=true;
            tutorialIsFinished=true;
            A_TragetIsCrashd=false;
            B_TragetIsCrashd=false;
        }
    }

    //  マッチの終了判定。
    void PlaysPlayScene()
    {
        if(countIsFinished==false) 
        {
            CountDown();
            return;
        }
        if(A_TragetIsCrashd||B_TragetIsCrashd)
        {
            A_TragetIsCrashd=false;
            B_TragetIsCrashd=false;
            EndsMatch();
        }
    }

    void EndsMatch()
    {

        if(A_PlayerPoints>=3||B_PlayerPoints>=3)
        {
            SceneManager.LoadScene(1);
        }
        else {
            // PlaysPlaySceneメソッドへ
            countIsFinished=false;
        }
    }

    void CountDown()
    {
        countDown+=Time.deltaTime;
        Debug.Log(countDown);
        if(countDown>3.0f) 
        {
            countIsFinished=true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitileInStartScene : MonoBehaviour
{
    public GameDirector gameDirector;
    public TextMeshProUGUI TitleText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameDirector.tutorialIsFinished==true){ TitleText.text="";}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIParent : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public ResultGameDirector resultGameDirector;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        winText.text=resultGameDirector.winnerName;
    }
}

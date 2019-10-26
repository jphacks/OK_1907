using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [HideInInspector] public bool isBrokenTarget;
    [HideInInspector] public bool gameFiniehd;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void DetectsTarget()
    {
        if(isBrokenTarget!=false) gameFiniehd=true;
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTarget : MonoBehaviour
{
    public bool targetIsCrashd=false;
    public GameObject effectPrefab;
    public MeshRenderer meshRenderer;
    public GameDirector gameDirector;

    void Start()
    {
        meshRenderer=GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        
    }
}

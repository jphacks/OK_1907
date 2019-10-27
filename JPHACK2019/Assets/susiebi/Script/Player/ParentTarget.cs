using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTarget : MonoBehaviour
{
    public bool targetIsCrashd=false;
    public GameObject effectPrefab;
    public MeshRenderer meshRenderer;
    public GameDirector gameDirector;
    public SphereCollider collider;

    void Start()
    {
        meshRenderer=GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // public virtual void OnCollisionEnter(Collision collision)
    // {
        
    // }
}

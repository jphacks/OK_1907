using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public bool A_TragetIsCrashd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
/*   void Update()
        Destroy (this.gameObject, 1.0f);
    }
*/
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Sword") 
        {
        A_TragetIsCrashd = true;
        Debug.Log(A_TragetIsCrashd);
        Destroy(this.gameObject);
        }
    } 
   
}
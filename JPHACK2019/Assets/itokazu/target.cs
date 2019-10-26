using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
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
        Destroy(this.gameObject);
        }
    } 
   
}
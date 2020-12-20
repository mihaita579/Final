using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour
{
    
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
     {

        if (other.CompareTag("Player")) {
            Destroy(obj: gameObject);
            Destroy(other.gameObject);
        }
        

    }
            
                


    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadAura : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collided) 
    {
        if (collided.tag == "People") {
            Debug.Log("Near !");
            collided.BroadcastMessage("EnterAura");
        }
    }

    private void OnTriggerExit2D(Collider2D collided) 
    {
        if (collided.tag == "People") {
            Debug.Log("Far enough");
            collided.BroadcastMessage("ExitAura");
        }
    }
}

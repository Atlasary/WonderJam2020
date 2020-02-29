using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadVision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D obj) 
    {
        if (obj.tag == "People") {
            if (peopleInVision(obj)) {
                seeSomeone(obj);
            }
        }
    }

    bool peopleInVision(Collider2D aim) 
    {
         int layerMask = ~(1 << 2); // all except 2
        RaycastHit2D hit = Physics2D.Linecast(transform.position, aim.transform.position, layerMask , -Mathf.Infinity, Mathf.Infinity);
        // If it hits something...
        if (hit.collider != null) 
        {
            if (hit.collider.gameObject.GetInstanceID() == aim.gameObject.GetInstanceID())
            {
                return true;
            }
        }

        return false; 
    }

    private void seeSomeone(Collider2D people)
    {
        Debug.Log("See someone");
        people.BroadcastMessage("EnterVision");
    }

    private void OnTriggerExit2D(Collider2D obj) 
    {
        if (obj.tag == "People") {
            Debug.Log("Don't see anymore");
            obj.BroadcastMessage("ExitVision");
        }
    }


}

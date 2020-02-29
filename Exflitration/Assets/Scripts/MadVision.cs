using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadVision : MonoBehaviour
{

    private GameObject focus = null;
    //private List<GameObject> enVision = new List<GameObject>;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "People") {
            if (peopleInVision(col)) {
                seeSomeone(col.gameObject);
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
            if (hit.collider.tag == "Hiding")
            {
                layerMask = 1 << 10; // hiding
                //RaycastHit2D hit = Physics2D.Linecast(transform.position, aim.transform.position, layerMask , -Mathf.Infinity, Mathf.Infinity);
            }
        }

        return false; 
    }

    private void seeSomeone(GameObject people)
    {

        Debug.Log("See someone");
        people.BroadcastMessage("EnterVision");
        estEnFocus(people);
        /*
        if (!estEnVision(people)) 
        {
            people.BroadcastMessage("EnterVision");
        }*/
    }

    private void estEnVision() 
    {
        //return enVision.Contains(people);
    }

    private void estEnFocus(GameObject target)
    {
        focus = target;
        gameObject.BroadcastMessage("updateFocus", target);
    }

    private void OnTriggerExit2D(Collider2D obj) 
    {
        if (obj.tag == "People") {
            Debug.Log("Don't see anymore");
            obj.BroadcastMessage("ExitVision");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadVision : MonoBehaviour
{
    private List<GameObject> inVision = new List<GameObject>();
    private GameObject nearestPeopleVisible = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateNearest();
    }

    private void updateNearest()
    {
        GameObject newNearest = nearest(inVision);
        if (nearestPeopleVisible != newNearest) 
        {
            if (newNearest == null) // && nearestPeopleVisible == newNearest
            {
                nearestPeopleVisible = null;
                transform.parent.gameObject.BroadcastMessage("removeNearestVisible");
            } else {
                nearestPeopleVisible = newNearest;
                transform.parent.gameObject.BroadcastMessage("setNearestVisible", nearestPeopleVisible);
            }

        }
        
    }

    bool isPeopleVisible(GameObject aim) 
    {
        int layerMask = ~(1 << 2); // all except 2
        RaycastHit2D hit = Physics2D.Linecast(transform.position, aim.transform.position, layerMask , -Mathf.Infinity, Mathf.Infinity);
        Collider2D col = hit.collider;

        // If it hits something...
        if (col != null) 
        {
            if (col.gameObject.GetInstanceID() == aim.gameObject.GetInstanceID())
            {
                if (isHidden(aim.gameObject) || isDead(aim.gameObject)) 
                {
                    return false;
                }
                return true;
            }
            
        }
        return false; 
    }

    private void fromVisionToMemory(GameObject people) 
    {
        
        exitVision(people);
    }

    private void seeSomeone(GameObject people)
    {
        if (!isAlreadyVisible(people)) 
        {
            enterInVision(people);
        } else {
            stayInVision(people);
        }
    }
    
    private GameObject nearest(IEnumerable<GameObject> list) 
    {
        float minDistance = Mathf.Infinity;
        float distance;
        GameObject nearest = null;
        foreach (GameObject obj in list) 
        {
            if (obj != null) {
                distance = Vector3.Distance(transform.parent.position, obj.transform.position);
                if (distance < minDistance) 
                {
                    minDistance = distance;
                    nearest = obj;
                }
            }
        }
        return nearest;
    }

    private bool isAlreadyVisible(GameObject people) 
    {
        return inVision.Contains(people);
    }

    private void enterInVision(GameObject people)
    {
        inVision.Add(people);
        //transform.parent.gameObject.BroadcastMessage("setNearestVisible",people);
        people.BroadcastMessage("EnterVision");
    }

    private void stayInVision(GameObject people)
    {
        //transform.parent.gameObject.BroadcastMessage("setNearestVisible",people);
    }

    private void exitVision(GameObject people) 
    {
        if (isHidden(people.gameObject) && isAlreadyVisible(people.gameObject) 
            || isAlreadyVisible(people.gameObject) && !isDead(people.gameObject))
        {
            transform.parent.gameObject.BroadcastMessage("addInMemory",people);
        }
        inVision.Remove(people);
        people.BroadcastMessage("ExitVision");
    }
/*
    private void OnTriggerEnter2D(Collider2D obj) 
    {
        if (obj.tag == "Survivor") {
            if (isPeopleVisible(obj.gameObject)) {
                seeSomeone(obj.gameObject);
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == "Survivor") {
            if (isPeopleVisible(obj.gameObject)) {
                seeSomeone(obj.gameObject);
            } else {
                exitVision(obj.gameObject);
            }
        }
    }

    private bool isHidden(GameObject people) 
    {
        return people.GetComponent<CharacterControl>().IsHidden;
    }

    private bool isDead(GameObject people) 
    {
        return people.GetComponent<CharacterControl>().IsDead;
    }

    private void OnTriggerExit2D(Collider2D obj) 
    {
        if (obj.tag == "Survivor") 
        {
            exitVision(obj.gameObject);
        }
    }
}

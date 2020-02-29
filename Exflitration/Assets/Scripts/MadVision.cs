using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadVision : MonoBehaviour
{
    private List<GameObject> inVision = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
                if (isHidden(col.gameObject) && isAlreadyVisible(col.gameObject))
                {
                    exitVision(col.gameObject);
                } 
                return true;
            }
            
        }

        return false; 
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
                    Debug.Log("trouvé");
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
        transform.parent.gameObject.BroadcastMessage("setNearestVisible",people);
        people.BroadcastMessage("EnterVision");
    }

    private void stayInVision(GameObject people)
    {
        transform.parent.gameObject.BroadcastMessage("setNearestVisible",people);
    }

    private void exitVision(GameObject people) 
    {
        Debug.Log("Don't see anymore");
        inVision.Remove(people);
        if (isHidden(people)) {
            transform.parent.gameObject.BroadcastMessage("addInMemory",people);
            transform.parent.gameObject.BroadcastMessage("removeNearestVisible");
        }
        people.BroadcastMessage("ExitVision");
    }

    private void OnTriggerEnter2D(Collider2D obj) 
    {
        if (obj.tag == "Survivor") {
            if (isPeopleVisible(obj.gameObject)) {
                seeSomeone(obj.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == "Survivor") {
            if (isPeopleVisible(obj.gameObject) && !isHidden(obj.gameObject)) {
                seeSomeone(obj.gameObject);
            }
        }
    }

    private bool isHidden(GameObject people) 
    {
        // return people.GetComponent<CharacterControl>().IsHidden;
        return true;
    }

    private void OnTriggerExit2D(Collider2D obj) 
    {
        if (obj.tag == "Survivor") 
        {
            exitVision(obj.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadVision : MonoBehaviour
{

    private GameObject focus = null;
    private List<GameObject> enVision = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chooseFocus();
    }

    private void chooseFocus() 
    {
        changeFocus(nearest(enVision));
    }

    private GameObject nearest(List<GameObject> list) 
    {
        float minDistance = Mathf.Infinity;
        float distance;
        GameObject nearest = null;
        foreach (GameObject obj in list) 
        {
            distance = Vector3.Distance(transform.parent.position, obj.transform.position);
            if (distance < minDistance) 
            {
                minDistance = distance;
                nearest = obj;
                Debug.Log("trouvé");
            }
        }
        return nearest;
    }
    
    private void changeFocus(GameObject target)
    {
        focus = target;
        Debug.Log(target);
        transform.parent.gameObject.BroadcastMessage("updateFocus", target);
    }


    bool isPeopleVisible(GameObject aim) 
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
        if (!enVision.Contains(people)) 
        {
            enterVision(people);
        }
    }

    private void enterVision(GameObject people)
    {
        enVision.Add(people);
        people.BroadcastMessage("EnterVision");
    }

    private void exitVision(GameObject people) 
    {
        Debug.Log("Don't see anymore");
        enVision.Remove(people);
        people.BroadcastMessage("ExitVision");
    }

    private void OnTriggerEnter2D(Collider2D obj) 
    {
        if (obj.tag == "People") {
            if (isPeopleVisible(obj.gameObject)) {
                seeSomeone(obj.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == "People") {
            if (isPeopleVisible(obj.gameObject)) {
                seeSomeone(obj.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj) 
    {
        if (obj.tag == "People") 
        {
            exitVision(obj.gameObject);
        }
    }


}

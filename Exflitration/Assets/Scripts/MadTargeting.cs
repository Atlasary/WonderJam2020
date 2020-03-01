using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadTargeting : MonoBehaviour
{
    private Dictionary<GameObject, float> inMemory = new Dictionary<GameObject, float>();
    private GameObject focus = null;
    private GameObject nearestVisible = null;
    
    private float memoryHiddenTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chooseFocus();
        updateMemory();
    }

    private void updateMemory() 
    {
        foreach (GameObject obj in inMemory.Keys) {
            inMemory[obj] = inMemory[obj] - Time.deltaTime;
            
            if (inMemory[obj] < 0) 
            {
                inMemory.Remove(obj); // forgot
            }
        }
    }
    
    
    private void chooseFocus() 
    {
        changeFocus(nearestPeople());
    }

    private GameObject nearestPeople() 
    {
        GameObject nearestPeopleM;
        GameObject[] arr;

        nearestPeopleM = nearest(inMemory.Keys);

        if (nearestVisible == null) {
            return nearestPeopleM;
        }
        arr = new GameObject[] {nearestVisible, nearestPeopleM};
        return nearest(arr);
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

    private void changeFocus(GameObject target)
    {
        if (!GameObject.ReferenceEquals(focus, target)) {
            focus = target;
            if (target is null) {
                transform.parent.gameObject.BroadcastMessage("looseFocus");
            } else {
                Debug.Log("Send focus");
                transform.parent.gameObject.BroadcastMessage("updateFocus", target);
            }
        }
        
    }

    
    private void addInMemory(GameObject people)
    {
        if (!inMemory.ContainsKey(people)) {
            inMemory.Add(people, memoryHiddenTime);
        } else {
            inMemory[people] = memoryHiddenTime;
        }
        
    }

    private void setNearestVisible(GameObject people) 
    {
        nearestVisible = people;
    }

    private void removeNearestVisible() 
    {
        nearestVisible = null;
    }
}

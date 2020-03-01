using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickManager : MonoBehaviour
{
    //
    private List<Vector3> linePoints = new List<Vector3>();
    private GameObject previousObject;
    private GameObject previousCharacter;
    private int layerMask = ~(1 << 2);

    void Start()
    {
        //
    }


    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, layerMask);


        if (Input.GetMouseButtonDown(0))
        {      
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject);
                //Check if the ray has hit a character
                if (hit.collider.gameObject.tag == "Survivor")
                {
                    Debug.Log("Survivor hit");
                    // Unselect if you click on the same character twice
                    if (hit.collider.gameObject == previousObject)
                    {
                        previousObject.GetComponent<CharacterControl>().CharacterUnClicked();
                        previousObject = null;
                    }
                    else
                    {
                        if (previousObject != null)
                        {
                            previousObject.gameObject.GetComponent<CharacterControl>().CharacterUnClicked();
                            previousObject = hit.collider.gameObject;
                            previousObject.gameObject.GetComponent<CharacterControl>().CharacterClicked();

                        }
                        else
                        {
                            previousObject = hit.collider.gameObject;
                            previousObject.gameObject.GetComponent<CharacterControl>().CharacterClicked();
                        }

                    }
                    previousCharacter = hit.collider.gameObject;
                } 
                else if(hit.collider.gameObject.tag == "Distraction")
                {
                    if (previousCharacter != null)
                    {
                        float distance = Vector2.Distance(previousCharacter.GetComponent<Transform>().position, mousePos2D);
                        Debug.Log(distance);
                        //previousObject = hit.collider.gameObject;
                        if (distance <= 1.3f)
                        {
                            hit.collider.gameObject.GetComponent<Distraction>().Distract();
                        }
                        else
                        {
                            previousObject.GetComponent<CharacterControl>().MoveToPosition(mousePos2D);
                        }
                    }

                }
                //else  // Obselete?
                //{
                //    if (previousObject != null)
                //    {
                //        if (previousObject.tag == "Survivor")
                //        {
                //            //Debug.Log("test");
                //            //previousObject.GetComponent<CharacterControl>().CharacterUnClicked();
                //            previousObject.GetComponent<CharacterControl>().MoveToPosition(mousePos2D);
                //        }
                //    }
                //}
            }
            else
            {
                if (previousObject != null)
                {
                    if (previousObject.tag == "Survivor")
                    {
                        //Debug.Log("test");
                        //previousObject.GetComponent<CharacterControl>().CharacterUnClicked();
                        previousObject.GetComponent<CharacterControl>().MoveToPosition(mousePos2D);
                    }
                }

            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (previousCharacter != null)
            {
                previousCharacter.GetComponent<CharacterControl>().CharacterUnClicked();
                previousCharacter = null;
                previousObject = null;
            }
        }
        else if (previousObject != null && previousCharacter == previousObject)
        {
            previousCharacter.GetComponent<CharacterControl>().MoveToPosition(mousePos2D);
        }
    }
}
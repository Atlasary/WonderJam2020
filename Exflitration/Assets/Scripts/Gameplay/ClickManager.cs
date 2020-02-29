﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickManager : MonoBehaviour
{
    //
    private List<Vector3> linePoints = new List<Vector3>();
    private GameObject previousObject;
    private GameObject previousCharacter;

    void Start()
    {
        //
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {      
            if (hit.collider != null)
            {
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
                        if (distance <= 1f)
                        {
                            hit.collider.gameObject.GetComponent<Distraction>().Distract();
                        }
                        else
                        {
                            previousObject.GetComponent<CharacterControl>().MoveToPosition(mousePos2D);
                        }
                    }

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
    }
}
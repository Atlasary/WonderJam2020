using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* /!\ ONLY FOR TEST */

public class Stress : MonoBehaviour
{
    
    // Jauge de Stress du survivant
    public float newStress = 0f;

    // Insertion des GameObject
    public GameObject Killer;
    public GameObject StressBar;

    // Position du Survivant et du Tueur
    private Vector3 PositionKiller;
    private Vector3 PositionSurvivor;


    // Start is called before the first frame update
    void Start()
    {
        if (Killer = null)
            Killer = GameObject.Find("Mad");
        PositionKiller = Killer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnterVision()
    {
        Debug.Log("EnterVision (people)");
    }

    void ExitVision()
    {
        Debug.Log("ExitVision (people)");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    // Start is called before the first frame update
    //private int useCpt = 0;
    private AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Distract()
    {
        //if (useCpt > 0)
        //{
        //   Debug.Log("Discration has already been used");
        //    return;
        //}
        //Debug.Log("Discration used");
        sound.PlayOneShot(sound.clip);
        // TODO: Send a message to the killer to change trajectory
        //useCpt++;
    }
}

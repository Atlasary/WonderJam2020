using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable : MonoBehaviour
{
public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up*Time.deltaTime*speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down*Time.deltaTime*speed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right*Time.deltaTime*speed);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
    }
}

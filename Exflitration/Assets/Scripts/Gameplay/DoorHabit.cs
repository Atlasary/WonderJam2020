using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHabit : MonoBehaviour
{
    public bool canBeOpen;
    public GameObject captor;

    private bool isTurning;
    private Quaternion iniRot;
    // Start is called before the first frame update
    void Start()
    {
        isTurning = false;
        iniRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator RotateDoorPlus()
    {
        isTurning = true;
        Quaternion current = transform.rotation;
        for (int i = 0; i < 9; i++)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * 10);
            yield return new WaitForSeconds(0.03f);
        }
        transform.rotation = Quaternion.Euler(current.eulerAngles + Vector3.forward * 90);
        isTurning = false;
    }

    private IEnumerator RotateDoorMinus()
    {
        isTurning = true;
        Quaternion current = transform.rotation;
        for (int i = 0; i < 9; i++)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - Vector3.forward * 10);
            yield return new WaitForSeconds(0.03f);
        }
        transform.rotation = Quaternion.Euler(current.eulerAngles - Vector3.forward * 90);
        isTurning = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTurning)
        {
            if (((int)(transform.rotation.eulerAngles.z - iniRot.eulerAngles.z) == 90 || (int)(transform.rotation.eulerAngles.z - iniRot.eulerAngles.z) == 0) &&
                Vector3.SignedAngle(collision.gameObject.transform.position - this.transform.position, captor.transform.position-transform.position,Vector3.forward) < 0)
            {
                StartCoroutine("RotateDoorMinus");
            }
            else if(((int)(transform.rotation.eulerAngles.z - iniRot.eulerAngles.z) == 270 || (int)(transform.rotation.eulerAngles.z - iniRot.eulerAngles.z) == -90 || (int)(transform.rotation.eulerAngles.z - iniRot.eulerAngles.z) == 0) &&
                Vector3.SignedAngle(collision.gameObject.transform.position - this.transform.position, captor.transform.position - transform.position, Vector3.forward) > 0)
            {
                StartCoroutine("RotateDoorPlus");
            }
        }

    }
    
}

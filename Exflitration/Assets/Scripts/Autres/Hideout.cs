using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Survivor"))
        {
            collision.gameObject.GetComponent<CharacterControl>().IsHidden = true;           
        }
        Debug.Log("Enter hideout");
        sr.color = new Color(1f, 1f, 1f, .5f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Survivor"))
        {
            collision.gameObject.GetComponent<CharacterControl>().IsHidden = false;
        }
        Debug.Log("Exit hideout");
        sr.color = new Color(1f, 1f, 1f, 1f);
    }
}

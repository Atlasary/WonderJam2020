using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{

    private SpriteRenderer sr;
    private int cpt;
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
            cpt++;
        }
        Debug.Log("Enter hideout");
        if (cpt != 0)
        {
            sr.color = new Color(1f, 1f, 1f, .5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Survivor"))
        {
            collision.gameObject.GetComponent<CharacterControl>().IsHidden = false;
            cpt--;
        }
        Debug.Log("Exit hideout");
        if (cpt == 0)
        {
            sr.color = new Color(1f, 1f, 1f, 1f);
        }

    }
}

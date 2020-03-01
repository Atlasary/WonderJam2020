using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
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
            collision.gameObject.GetComponent<CharacterControl>().Won = true;
            collision.gameObject.GetComponent<CharacterControl>().CharacterUnClicked();
            collision.gameObject.SetActive(false);
        }
        Debug.Log("Player won");
    }
}

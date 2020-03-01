using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequired : MonoBehaviour
{

    private BoxCollider2D bc2;
    private SpriteRenderer sr;
    public string NeededItemName { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        bc2 = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        NeededItemName = "Key";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void receiveItem()
    {
        bc2.size = new Vector2(0f, 0f);
        sr.sprite = null;
        Debug.Log("ItemReceived");
        return;
    }
}

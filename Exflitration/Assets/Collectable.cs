using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool IsTaken { get; set; }
    public bool HasBeenUsed { get; set; }
    public string ItemName { get; set; }
    private BoxCollider2D bc2;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        IsTaken = false;
        HasBeenUsed = false;
        bc2 = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        ItemName = "Key";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Take()
    {
        if (IsTaken)
            return;

        IsTaken = true;
        bc2.size = new Vector2(0f, 0f);
        sr.sprite = null;
        Debug.Log("taken");
    }

    public void Use()
    {
        if (HasBeenUsed)
            return;

        HasBeenUsed = true;
        Debug.Log("used");
    }
}

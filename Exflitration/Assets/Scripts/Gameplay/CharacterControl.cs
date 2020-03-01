using UnityEngine;
using System.Collections.Generic;

public class CharacterControl : MonoBehaviour
{
    private Transform tr;
    private SpriteRenderer sr;
    private Rigidbody2D rb2;
    private BoxCollider2D bc2;
    private List<GameObject> itemList = new List<GameObject>(); 

    public float speed = 3f;
    public Sprite deadSprite;
    private Vector2 velocity;
    private bool selected = false;
    private Vector3 target;
    private Vector2 position;
    bool hasReachedTarget = false;
    private Vector2 dir;
    private Vector3 target3;
    Quaternion qTo;
    public bool IsHidden { get; set; }
    public bool IsDead { get; set; }

    // Stress Part //
    public float StressLevel;
    public GameObject stressBar;
    // End of Stress part //

   
    void Start()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();
        bc2 = GetComponent<BoxCollider2D>();
        velocity = new Vector2(1.0f, 1.0f);
        target = tr.position;
        IsHidden = false;
        IsDead = false;
        StressLevel = 0.9f;
        if (this.stressBar != null)
        {
            Vector3 temp = new Vector3(0.7f, 0f, 0);
            this.stressBar.transform.position = this.transform.position + temp;
            this.stressBar.GetComponent<StressBar>().setProgress(StressLevel);
            // taille de l'élément UI
            this.stressBar.transform.localScale = new Vector3(0.01f, 0.01f, 0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.stressBar != null)
        {
            Vector3 temp = new Vector3(0.7f, 0.7f, 0);
            this.stressBar.transform.position = this.transform.position + temp;
            updateStressBar(0.05f);
        }
        // If The character is dead, Do nothing
        if (IsDead)
        {
            return;
        }
        float step = speed * Time.deltaTime;

        if (tr.position.x == target.x && tr.position.y == target.y)
        {
            hasReachedTarget = true;
        }

        if (hasReachedTarget == false)
        {

            //tr.position = Vector2.MoveTowards(tr.position, target, step);

            Vector2 newPosition = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
            rb2.MovePosition(newPosition);

            Vector3 aimDir = target - transform.position;
            float targetAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            Vector3 curAngle = transform.eulerAngles;
            Vector3 target2 = curAngle;
            target2.z = targetAngle;
            //Debug.Log(targetAngle);
            if (targetAngle != 0)
            {
                transform.rotation = Quaternion.Euler(target2);
            }


        }
    }

    public void CharacterClicked()
    {
        if (!IsDead)
        {
            selected = true;
            sr.color = Color.cyan;
        }
    }
    public void CharacterUnClicked()
    {
        selected = false;
        sr.color = Color.white;
        //StopMoving();
    }
    
    public void MoveToPosition(Vector2 target)
    {
        hasReachedTarget = false;
        position = tr.position;
        this.target = target;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Touched");
            StopMoving();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");
        bc2.isTrigger = false;
        rb2.velocity = Vector3.zero;
        rb2.angularVelocity = 0;
    }

    public void StopMoving()
    {
        target = tr.position;
        hasReachedTarget = true;
        rb2.velocity = Vector3.zero;
        rb2.angularVelocity = 0;
        Debug.Log(target);

    }
    public void Die()
    {
        IsDead = true;
        CharacterUnClicked();
        sr.sprite = deadSprite;
        // Score (lose points)
        Destroy(this.stressBar);

    }
    public void updateStressBar(float progress)
    {
        this.stressBar.GetComponent<StressBar>().LessProgress(progress);
    }

    public GameObject getItemNamed(string itemName)
    {
        foreach (GameObject item in itemList)
        {
            if (item.GetComponent<Collectable>().ItemName == itemName)
            {
                return item;
            }
        }
        return null;
    }

    public GameObject UseItem(string itemName)
    {
        GameObject item = getItemNamed(itemName);
        if (item == null)
        {
            return null;
        }

        itemList.Remove(item);
        return item;
    }

    public void AddItem(GameObject item)
    {
        itemList.Add(item);
    }
}

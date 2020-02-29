using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Transform tr;
    private SpriteRenderer sr;
    private Rigidbody2D rb2;
    private BoxCollider2D bc2;

    public float speed = 3f;
    private Vector2 velocity;
    private bool selected = false;
    private Vector3 target;
    private Vector2 position;
    bool hasReachedTarget = false;
    private Vector2 dir;
    private Vector3 target3;
    Quaternion qTo;
    public bool IsHidden { get; set; }

    void Start()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();
        bc2 = GetComponent<BoxCollider2D>();
        velocity = new Vector2(1.0f, 1.0f);
        target = tr.position;
        IsHidden = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            target2.z = targetAngle - 90;
            //Debug.Log(targetAngle);
            if (targetAngle != 0)
            {
                transform.rotation = Quaternion.Euler(target2);
            }


        }
    }

    public void CharacterClicked()
    {
        selected = true;
        sr.color = Color.cyan;
    }
    public void CharacterUnClicked()
    {
        selected = false;
        sr.color = Color.white;
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
            stopMoving();
        }
        if (collision.gameObject.CompareTag("Hideout"))
        {
            Debug.Log("Hideout");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");
        bc2.isTrigger = false;
        rb2.velocity = Vector3.zero;
        rb2.angularVelocity = 0;
    }

    private void stopMoving()
    {
        target = tr.position;
        hasReachedTarget = true;
        rb2.velocity = Vector3.zero;
        rb2.angularVelocity = 0;
    }
}

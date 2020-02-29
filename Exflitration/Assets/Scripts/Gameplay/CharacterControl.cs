using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Transform tr;
    private SpriteRenderer sr;
    private Rigidbody2D rb2;

    private bool selected = false;
    private float speed = 3f;
    private Vector3 target;
    private Vector2 position;
    bool hasReachedTarget = false;
    private Vector2 dir;
    private Vector3 target3;
    Quaternion qTo;

    void Start()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();

        target = tr.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (tr.position.x == target.x && tr.position.y == target.y)
        {
            hasReachedTarget = true;
        }

        if (hasReachedTarget == false)
        {

            tr.position = Vector2.MoveTowards(tr.position, target, step);

            Vector3 aimDir = target - transform.position;
            float targetAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            Vector3 curAngle = transform.eulerAngles;
            Vector3 target2 = curAngle;
            target2.z = targetAngle - 90;
            Debug.Log(targetAngle);
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
}

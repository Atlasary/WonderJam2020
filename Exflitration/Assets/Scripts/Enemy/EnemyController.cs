using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Display")]
    public SpriteRenderer body = null;

    [Header("Movement")]
    [Tooltip("Speed of the enemy")]
    [Range(0, 10)]
    public float speed = 0.3f;

    [Header("Path")]
    [Tooltip("Reference to the game object containing the path points")]
    public GameObject pathContainer;
    [Tooltip("Did the enemy follow the path")]
    public bool followingPath = true;

    [Header("Chase")]
    [Tooltip("Reference to the default target (by default : null)")]
    public GameObject target = null;
    [Tooltip("Does the Enemy follows a target")]
    public bool followingTarget = false;

    private Rigidbody2D rigidbody2;

    Component[] pathPoints;
    int currentPoint = 0;
    int maxPoint;

    Queue<Vector3> track;

    float smoothRotation = 5.0f;
    float closeEnoughFactor = 0.1f;
    float distantEnoughFactor = 1f;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        
        track = new Queue<Vector3>();
        
        if (pathContainer != null)
        {
            pathPoints = pathContainer.GetComponentsInChildren<PathPoint>();
            maxPoint = pathPoints.GetLength(0);
        }
        else
        {
            Debug.LogError("Enemy doesn't have default path");
        }
    }

    void Update()
    {
        Vector3 targetPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            getClosestPoint();
        }

        if (followingTarget && track.Count > 0 && target != null)
        {
            // targetPosition = target.transform.position;

            // if (closeEnough(targetPosition, transform.position))
            // {
            //     Debug.Log(target.name + " is dead");
            //     target.GetComponent<CharacterControl>().Die();
            //     target = null;
            // }

            targetPosition = track.Dequeue();
        }
        else if (followingPath)
        {
            targetPosition = pathPoints[currentPoint].transform.position;

            if (closeEnough(targetPosition, transform.position))
            {
                currentPoint ++;
                if (currentPoint >= maxPoint) currentPoint = 0;
            }
        }
        else
        {
            // Default case ; DEBUG ONLY
            targetPosition = transform.position;
        }

        Vector3 vectorToTarget = targetPosition - transform.position;

        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion angleTarget = Quaternion.AngleAxis(angle, Vector3.forward);

        rigidbody2.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));
        transform.rotation = Quaternion.Slerp(transform.rotation, angleTarget, smoothRotation * Time.deltaTime);

        // if (angle > 90 && body != null) body.flipY = true;
        // else if (angle <= 90 && body != null && body.flipY) body.flipY = false;
    }

    bool closeEnough(Vector3 alfred, Vector3 billy)
    {
        return Vector3.Distance(alfred, billy) < closeEnoughFactor;
    }
    
    void updateFocus(GameObject target)
    {
        this.target = target;
        InvokeRepeating("getTargetPosition", 0, 2);
    }

    void looseFocus()
    {
        target = null;
        track.Clear();
        CancelInvoke("getTargetPosition");
        // currentPoint = getClosestPoint();
    }

    int getClosestPoint()
    {
        RaycastHit2D hit2D;
        int i = 0, r = 0;
        int layerMask =~ LayerMask.GetMask("Characters");
        float dist = Mathf.Infinity;
        while (i < maxPoint)
        {
            hit2D = Physics2D.Linecast(transform.position, pathPoints[i].transform.position, layerMask , -Mathf.Infinity, Mathf.Infinity);
            if (hit2D.collider != null && hit2D.collider.gameObject.tag == "PathPoint")
            {
                float tmp = Vector3.Distance(pathPoints[i].transform.position, transform.position);
                if (dist > tmp) { dist = tmp; r = i; }
            }
            i ++;
        }

        Debug.DrawLine(transform.position, pathPoints[r].transform.position, Color.red, 1f);
        Debug.Log(pathPoints[r].tag + " " +pathPoints[r].name);
        return r;
    }

    void getTargetPosition()
    {
        Vector3 trg = target.transform.position;
        if (target)
        {
            if (track.Count > 0 && Vector3.Distance(track.Peek(), trg) >= distantEnoughFactor)
            {
                track.Enqueue(trg);
            } else if (track.Count == 0)
            {
                track.Enqueue(trg);
            }
        }
    }
}

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

    Component[] pathPoints;
    int currentPoint = 0;
    int maxPoint;

    float smoothRotation = 5.0f;
    float closeEnoughFactor = 0.01f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

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

        if (followingTarget && target != null)
        {
            targetPosition = target.transform.position;

            if (closeEnough(targetPosition, transform.position))
            {
                Debug.Log(target.name + " is dead");
                target = null;
            }
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
            targetPosition = new Vector3(0f, 0f, 0f);
        }

        Vector3 vectorToTarget = targetPosition - transform.position;

        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion angleTarget = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleTarget, smoothRotation * Time.deltaTime);

        if (angle > 90 && body != null) body.flipY = true;
        else if (angle <= 90 && body != null && body.flipY) body.flipY = false;
    }

    bool closeEnough(Vector3 alfred, Vector3 billy)
    {
        return Vector3.Distance(alfred, billy) < closeEnoughFactor;
    }
    
    void updateFocus(GameObject target)
    {
        this.target = target;
    }

    void looseFocus()
    {
        target = null;
    }
}

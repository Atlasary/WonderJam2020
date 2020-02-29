using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Speed of the enemy")]
    [Range(0, 10)]
    public float speed = 0.3f;

    [Header("Path")]
    [Tooltip("Reference to the game object containing the path points")]
    public GameObject pathContainer;
    [Tooltip("Did the enemy follow the path")]
    public bool followingPath = true;

    Component[] pathPoints;
    int currentPoint = 0;
    int maxPoint;

    float smoothRotation = 5.0f;

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
        if (followingPath)
        {
            Vector3 point = pathPoints[currentPoint].transform.position;
            Vector3 vectorToTarget = point - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion target = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smoothRotation);

            if (Vector3.Distance(transform.position, point) < 0.01f)
            {
                currentPoint ++;
                if (currentPoint >= maxPoint) currentPoint = 0;
            }
        }
    }
}

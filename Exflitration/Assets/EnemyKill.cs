using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Survivor")
        {
            collision.gameObject.GetComponent<CharacterControl>().Die();
        }
    }
}

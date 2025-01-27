using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool collided;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Bullet") && !other.CompareTag("Player") && !collided && !other.CompareTag("Floor"))
        {
            collided = true;
            Destroy(gameObject);
        }
    }
}

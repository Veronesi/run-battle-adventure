using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool isAllySpawned = true;
    public float damadge = 2f;
    public bool destroyOnHit = true;
    public GameObject particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAllySpawned && collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Champion>().Hurt(damadge);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
            
        }
    }
    public void SetDestination(Vector3 destination)
    {
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce((destination - transform.position).normalized * 800f);
    }
}

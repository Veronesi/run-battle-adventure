using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionMovement : MonoBehaviour
{
    public bool isAlly;
    public float moveVelocity = 20f;
    private Rigidbody2D rb2d;
    void Start()
    {
        isAlly = gameObject.CompareTag("Ally");

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (isAlly)
        {
            rb2d.AddForce(Vector3.right * moveVelocity);
        }
        else
        {
            rb2d.AddForce(Vector3.left * moveVelocity);
        }
    }
    public void Stop()
    {
        rb2d.velocity = Vector3.zero;
    }
    public void Walk()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (isAlly)
        {
            rb2d.AddForce(Vector3.right * moveVelocity);
        }
        else
        {
            rb2d.AddForce(Vector3.left * moveVelocity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ally"))
        {
            Debug.Log("u win");
        }
    }
}

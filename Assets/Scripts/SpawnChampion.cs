using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChampion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("spawn " + collision.gameObject.layer + " " + collision.gameObject.tag);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("stay " + collision.gameObject.layer + " " + collision.gameObject.tag);
    }
}

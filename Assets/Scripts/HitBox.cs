using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public string parentTag;
    public List<GameObject> enemies;
    private void Start()
    {
        if (gameObject.GetComponentInParent<ChampionMovement>().isAlly)
        {
            parentTag = "Ally";
            return;
        }
        parentTag = "Enemy";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(parentTag))
        {
            enemies.Add(collision.gameObject);
            gameObject.GetComponentInParent<ChampionMovement>().Stop();
            gameObject.GetComponentInParent<Attack>().AttackChampion(collision.gameObject, this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(parentTag))
        {
            enemies.Remove(collision.gameObject);
        }
    }
}

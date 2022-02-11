using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Champion : MonoBehaviour
{
    public float life = 10f;
    public float maxLife = 10f;
    public int energy = 1;
    public GameObject hitIndicator;

    private void Start()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = !gameObject.CompareTag("Ally");
        life = maxLife;
    }
    public bool Hurt(float damadge)
    {
        life -= damadge;
        Quaternion rotation = new Quaternion(0f, 0f, Random.Range(-15f, 15f), 90f);
        GameObject hitIndicatorI = Instantiate(hitIndicator, transform.position, rotation);
        hitIndicatorI.GetComponent<TextMeshPro>().text = damadge.ToString();
        Destroy(hitIndicatorI, 0.5f);
        if(life <= 0)
        {
            Invoke("Kill", 0.1f);
        }
        return life > 0;
    }
    public void Kill()
    {
        Destroy(gameObject);
    }
}
